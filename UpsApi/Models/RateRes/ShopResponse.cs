using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static UpsApi.Models.RateRes.BaseResponse;

namespace UpsApi.Models.RateRes
{
    public class ShopResponse
    {
        public Response Response { get; set; }
        public List<RatedShipment> RatedShipment { get; set; }
    }
}