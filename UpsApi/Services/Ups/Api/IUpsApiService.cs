using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UpsApi.Services.Ups.Api
{
    public interface IUpsApiService
    {
        UpsApiResult GetResultFromUpsApi(string requestUrl, HttpContent httpContent);
    }
}
