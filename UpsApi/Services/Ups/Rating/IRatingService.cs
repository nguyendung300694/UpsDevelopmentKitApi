using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UpsApi.Models.RateRes;

namespace UpsApi.Services.Ups.Rating
{
    interface IRatingService
    {
        RateResponse GetRate(string requestUrl, HttpContent httpContent);
    }
}
