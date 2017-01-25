using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace GSTN.API
{


	public class EncryptionUtils
	{

		public static X509Certificate2 getPublicKey()
		{
			RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
			X509Certificate2 cert2 = new X509Certificate2("Resources\\GSTN_PublicKey.cer");
			return cert2;
		}

		public static string HMAC_Encrypt(string message, string secret)
		{
			secret = secret ?? "";
			var encoding = new System.Text.ASCIIEncoding();
			byte[] keyByte = encoding.GetBytes(secret);
			byte[] messageBytes = encoding.GetBytes(message);
            using (var HMACSHA256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = HMACSHA256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }


		}
		public static string GenerateHMAC(string message, byte[] EK)
		{
            using (var HMACSHA256 = new HMACSHA256(EK))
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(message);
                byte[] hashmessage = HMACSHA256.ComputeHash(data);
                return Convert.ToBase64String(hashmessage);
            }
		}
		public static string HMAC_Encrypt(byte[] EK)
		{
            using (var HMACSHA256 = new HMACSHA256())
            {
                byte[] hashmessage = HMACSHA256.ComputeHash(EK);
                return Convert.ToBase64String(hashmessage);
            }
		}

		public static string Encrypt(string plainText, byte[] keyBytes)
		{
			byte[] dataToEncrypt = UTF8Encoding.UTF8.GetBytes(plainText);

			AesManaged tdes = new AesManaged();

			tdes.KeySize = 256;
			tdes.BlockSize = 128;
			tdes.Key = keyBytes;
			// Encoding.ASCII.GetBytes(key);
			tdes.Mode = CipherMode.ECB;
			tdes.Padding = PaddingMode.PKCS7;

			ICryptoTransform crypt = tdes.CreateEncryptor();
			byte[] cipher = crypt.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
			tdes.Clear();
			return Convert.ToBase64String(cipher, 0, cipher.Length);
		}

		public static string Encrypt(string plainText, string key)
		{
			byte[] data = UTF8Encoding.UTF8.GetBytes(plainText);
			byte[] keyBytes = Encoding.UTF8.GetBytes(key);
			return EncryptionUtils.Encrypt(data, keyBytes);

		}


		public static string Encrypt(byte[] data, byte[] keys)
		{
			AesManaged tdes = new AesManaged();
			tdes.KeySize = 256;
			tdes.BlockSize = 128;
			tdes.Mode = CipherMode.ECB;
			tdes.Padding = PaddingMode.PKCS7;
			tdes.Key = keys;
			ICryptoTransform crypt = tdes.CreateEncryptor();
			byte[] cipher = crypt.TransformFinalBlock(data, 0, data.Length);
			return Convert.ToBase64String(cipher, 0, cipher.Length);
		}

		public static byte[] Decrypt(string encryptedText, string key)
		{

			byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
			byte[] keyBytes = Encoding.UTF8.GetBytes(key);

			return Decrypt(dataToDecrypt, keyBytes);

		}

		public static byte[] Decrypt(string encryptedText, byte[] keys)
		{
			byte[] dataToDecrypt = Convert.FromBase64String(encryptedText);
			return Decrypt(dataToDecrypt, keys);
		}



		public static byte[] Decrypt(byte[] dataToDecrypt, byte[] keys)
		{

			AesManaged tdes = new AesManaged();
			tdes.KeySize = 256;
			tdes.BlockSize = 128;
			tdes.Key = keys;
			tdes.Mode = CipherMode.ECB;
			tdes.Padding = PaddingMode.PKCS7;

			ICryptoTransform decrypt__1 = tdes.CreateDecryptor();
			byte[] deCipher = decrypt__1.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
			tdes.Clear();

			return deCipher;
		}




		public static string EncryptTextWithPublicKey(string input)
		{
			byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
			return EncryptTextWithPublicKey(bytesToBeEncrypted);
		}

		private static readonly byte[] Salt = new byte[] {
			10,
			20,
			30,
			40,
			50,
			60,
			70,
			80
		};
		public static byte[] CreateKey()
		{

			System.Security.Cryptography.AesCryptoServiceProvider crypto = new System.Security.Cryptography.AesCryptoServiceProvider();
			crypto.KeySize = 256;
			crypto.GenerateKey();
			byte[] key = crypto.Key;
			return key;
		}

		public static string EncryptTextWithPublicKey(byte[] bytesToBeEncrypted)
		{
			X509Certificate2 certificate = getPublicKey();
			RSACryptoServiceProvider RSA = (RSACryptoServiceProvider)certificate.PublicKey.Key;

			byte[] bytesEncrypted = RSA.Encrypt(bytesToBeEncrypted, false);

			string result = Convert.ToBase64String(bytesEncrypted);
			return result;
		}

        public static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        /// <summary>
        /// Generate Hash value from given string value
        /// </summary>
        /// <param name="text"></param>
        /// <returns>A managed SHA 256 hash value</returns>
        public static byte[] Generatehash256(string text)
        {
            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA256Managed hashString = new SHA256Managed();
            hashValue = hashString.ComputeHash(message);
            return hashValue;
        }


        public static byte[] convertStringToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }
    }

}



