using System;
using System.Collections;
using System.IO;


using Org.BouncyCastle.Bcpg.OpenPgp;

namespace Org.BouncyCastle.Bcpg.OpenPgp.Examples
{
    /**
    * A simple utility class that creates seperate signatures for messages and verifies them.
    * <p>
    * To sign a file: DetachedSignatureProcessor -s [-a] fileName secretKey passPhrase.<br/>
    * If -a is specified the output file will be "ascii-armored".</p>
    * <p>
    * To decrypt: DetachedSignatureProcessor -v  fileName signatureFile publicKeyFile.</p>
    * <p>
    * Note: this example will silently overwrite files.
    * It also expects that a single pass phrase
    * will have been used.</p>
    */
    public sealed class DetachedSignatureProcessor
    {
        private DetachedSignatureProcessor()
        {
        }

		public  static bool VerifySignature(
			string	OriginalMessage,
			string	EncodedMessage,
			string	keyFileName)
		{
			using (Stream keyIn = File.OpenRead(keyFileName))
			{
				return VerifySignature(OriginalMessage, EncodedMessage, keyIn);
			}
		}

		/**
        * verify the signature in in against the file fileName.
        */
        private static bool VerifySignature(
            string	OriginalMessage,
            string EncodedMessage,
            Stream	keyIn)
        {
            byte[] bytes = Convert.FromBase64String(EncodedMessage);
            using (Stream inputStream = new MemoryStream(bytes))
            {
                PgpObjectFactory pgpFact = new PgpObjectFactory(PgpUtilities.GetDecoderStream(inputStream));
                PgpSignatureList p3 = null;
                PgpObject o = pgpFact.NextPgpObject();
                if (o is PgpCompressedData)
                {
                    PgpCompressedData c1 = (PgpCompressedData)o;
                    pgpFact = new PgpObjectFactory(c1.GetDataStream());

                    p3 = (PgpSignatureList)pgpFact.NextPgpObject();
                }
                else
                {
                    p3 = (PgpSignatureList)o;
                }

                PgpPublicKeyRingBundle pgpPubRingCollection = new PgpPublicKeyRingBundle(
                    PgpUtilities.GetDecoderStream(keyIn));
                PgpSignature sig = p3[0];
                PgpPublicKey key = pgpPubRingCollection.GetPublicKey(sig.KeyId);
                sig.InitVerify(key);
                sig.Update(System.Text.Encoding.UTF8.GetBytes(OriginalMessage));

                return sig.Verify();

            }

        }

		public static string CreateSignature(
			string	message,
			string	keyFileName,
			string	outputFileName,
			char[]	pass,
			bool	armor)
		{
			using (Stream keyIn = File.OpenRead(keyFileName),
				output = File.OpenWrite(outputFileName))
			{
				return CreateSignature(message, keyIn, output, pass, armor);
			}
		}

		private static string CreateSignature(
			string	message,
			Stream	keyIn,
			Stream	outputStream,
			char[]	pass,
			bool	armor)
        {
            if (armor)
            {
                outputStream = new ArmoredOutputStream(outputStream);
            }

            PgpSecretKey pgpSec = PgpExampleUtilities.ReadSecretKey(keyIn);
            PgpPrivateKey pgpPrivKey = pgpSec.ExtractPrivateKey(pass);
            PgpSignatureGenerator sGen = new PgpSignatureGenerator(
				pgpSec.PublicKey.Algorithm, HashAlgorithmTag.Sha1);

			sGen.InitSign(PgpSignature.BinaryDocument, pgpPrivKey);

			BcpgOutputStream bOut = new BcpgOutputStream(outputStream);
            sGen.Update(System.Text.Encoding.UTF8.GetBytes(message));
            PgpSignature sig = sGen.Generate();
            sig.Encode(bOut);

			if (armor)
			{
				outputStream.Close();
			}

            MemoryStream ms = new MemoryStream();
            sig.Encode(ms);
            byte[] bytes = ms.ToArray();
            return Convert.ToBase64String(bytes);
        }

    }
}
