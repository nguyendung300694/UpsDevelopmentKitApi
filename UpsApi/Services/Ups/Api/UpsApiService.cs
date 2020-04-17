using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace UpsApi.Services.Ups.Api
{
    public class UpsApiService : IUpsApiService
    {
        public UpsApiResult GetResultFromUpsApi(string requestUrl, HttpContent httpContent)
        {
            UpsApiResult result = null;
            using (var client = new HttpClient())
            {
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("AccessLicenseNumber", AppSettings.UpsConfiguration.AccessLicenseNumberUps);
                client.DefaultRequestHeaders.Add("Username", AppSettings.UpsConfiguration.UserNameUps);
                client.DefaultRequestHeaders.Add("Password", AppSettings.UpsConfiguration.PasswordUps);

                // List data response.
                var getTask = client.PostAsync(requestUrl, httpContent);// Blocking call! Program will wait here until a response is received or a timeout occurs.
                getTask.Wait();
                var response = getTask.Result;
                //response.EnsureSuccessStatusCode();
                if (response != null)
                {
                    // Parse the response body.
                    var readTask = response.Content.ReadAsAsync<JObject>();//Make sure to add a reference to System.Net.Http.Formatting.dll
                    readTask.Wait();
                    if (readTask.Result != null)
                    {
                        result = new UpsApiResult
                        {
                            IsSuccessStatusCode = response.IsSuccessStatusCode,
                            JObject = readTask.Result
                        };
                    }
                }

                client.Dispose();
            }
            return result;
        }
    }

    public class UpsApiResult
    {
        public bool IsSuccessStatusCode { get; set; }
        public JObject JObject { get; set; }
    }
}