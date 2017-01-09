
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Owin.Infrastructure;
using Newtonsoft.Json;
using GSTN.API;
using System.Threading.Tasks;
using System.Net.Security;

public abstract class GSTNApiClientBase : IDisposable
{
    protected internal string path;
    protected internal string url2;

    TimeSpan timeout = TimeSpan.FromSeconds(100);
    public GSTNApiClientBase(string path)
    {
        this.path = path;
        url2 = GSTNConstants.base_url + path;
    }
    public TimeSpan RequestTimeout
    {
        get { return timeout; }
        set { timeout = value; }
    }
    public string PrepareQueryString(string path, IDictionary<string, string> Params)
    {
        url2 = WebUtilities.AddQueryString(path, Params);
        return url2;
    }
    public string PrepareQueryString(IDictionary<string, string> Params)
    {
        return this.PrepareQueryString(GSTNConstants.base_url + path, Params);
    }
    #region "Async Methods"

    public async Task<GSTNResult<TOutput>> GetAsync<TOutput>()
    {
        using (var client = GetHttpClient())
        {
            System.Console.WriteLine("GET:" + url2);
            HttpResponseMessage response = await client.GetAsync(url2);
            return BuildResponse<TOutput>(response);
        }

    }

    public async Task<GSTNResult<TOutput>> PostAsync<TInput, TOutput>(TInput data)
    {
        using (var client = GetHttpClient())
        {
            System.Console.WriteLine("POST:" + url2);
            HttpResponseMessage response;
            if (typeof(TInput) == typeof(string))
            {
                var content = new StringContent((string)(object)data, System.Text.Encoding.UTF8, "text/plain");
                response = await client.PostAsync(url2, content);
            }
            else
            {
                response = await client.PostAsJsonAsync(url2, data);
            }
            return BuildResponse<TOutput>(response);
        }

    }

    public async Task<GSTNResult<TOutput>> PutAsync<TInput, TOutput>(TInput data)
    {
        using (var client = GetHttpClient())
        {
            System.Console.WriteLine("PUT:" + url2);
            HttpResponseMessage response = await client.PutAsJsonAsync(url2, data);
            return BuildResponse<TOutput>(response);
        }

    }

    public async Task<GSTNResult<TOutput>> PatchAsync<TInput, TOutput>(TInput data)
    {
        using (var client = GetHttpClient())
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), url2);
            request.Content = new StringContent(JsonConvert.SerializeObject(data));
            HttpResponseMessage response = await client.SendAsync(request);
            return BuildResponse<TOutput>(response);
        }

    }

    public async Task<GSTNResult<bool>> DeleteAsync()
    {
        using (var client = GetHttpClient())
        {
            HttpResponseMessage response = await client.DeleteAsync(url2);
            return BuildResponse<bool>(response);
        }

    }

    #endregion

    public GSTNResult<TOutput> Get<TOutput>()
    {


        var _task = Task.Run(() => { return GetAsync<TOutput>(); });

        _task.Wait();
        var result = _task.Result;
        return result;
    }

    public GSTNResult<TOutput> Post<TInput, TOutput>(TInput data)
    {


        var _task = Task.Run(() => { return PostAsync<TInput, TOutput>(data); });

        _task.Wait();
        var result = _task.Result;
        return result;
    }

    public GSTNResult<TOutput> Put<TInput, TOutput>(TInput data)
    {

        var _task = Task.Run(() => { return PutAsync<TInput, TOutput>(data); });

        _task.Wait();
        var result = _task.Result;
        return result;
    }

    public GSTNResult<TOutput> Patch<TInput, TOutput>(TInput data)
    {


        var _task = Task.Run(() => { return PatchAsync<TInput, TOutput>(data); });

        _task.Wait();
        var result = _task.Result;
        return result;
    }

    public GSTNResult<bool> Delete()
    {


        var _task = Task.Run(() => { return DeleteAsync(); });

        _task.Wait();
        var result = _task.Result;
        return result;
    }

    protected HttpClient GetHttpClient()
    {
        var client = new HttpClient();
        client.Timeout = timeout;
        BuildHeaders(client);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return client;
    }

    protected internal abstract void BuildHeaders(HttpClient client);

    protected virtual GSTNResult<TOutput> BuildResponse<TOutput>(HttpResponseMessage response)
    {
        //This function can be used to convert simple API result to ResultInfo based API result
        GSTNResult<TOutput> resultInfo = new GSTNResult<TOutput>();
        resultInfo.HttpStatusCode = Convert.ToInt32(response.StatusCode.ToString("D"));
        var str1 = response.Content.ReadAsStringAsync().Result;
        System.Console.WriteLine("Obtained Result:" + str1 + System.Environment.NewLine);
        if (resultInfo.HttpStatusCode == (int)HttpStatusCode.OK)
        {
            if (typeof(TOutput) == typeof(String))
            {
                var result = (TOutput)(Object)str1;
                resultInfo.Data = result;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<TOutput>(str1);
                resultInfo.Data = result;
            }
        }
        else
        {
            resultInfo.Message = str1;
        }
        return resultInfo;
    }





    public void Dispose()
    {
    }

}

