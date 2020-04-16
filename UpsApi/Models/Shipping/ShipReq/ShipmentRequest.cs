using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ShippingServiceRestApi.Models.Ups.Shipping.ShipReq.ShipmentRequestElements;

namespace ShippingServiceRestApi.Models.Ups.Shipping.ShipReq
{
    public class ShipmentRequest
    {
        public Shipment Shipment { get; set; }
        public LabelSpecification LabelSpecification { get; set; }
    }
}