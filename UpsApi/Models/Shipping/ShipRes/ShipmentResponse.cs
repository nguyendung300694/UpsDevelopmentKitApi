using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static UpsApi.Models.Ups.Shipping.ShipRes.ShipmentResponseElements;

namespace UpsApi.Models.Ups.Shipping.ShipRes
{
    public class ShipmentResponse
    {
        public Response Response { get; set; }
        public ShipmentResults ShipmentResults { get; set; }
    }
}