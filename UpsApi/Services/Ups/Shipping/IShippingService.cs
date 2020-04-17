using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UpsApi.Models.Ups.Shipping.ShipReq;
using UpsApi.Models.Ups.Shipping.ShipRes;

namespace UpsApi.Services.Ups.Shipping
{
    public interface IShippingService
    {
        ShipmentResponse ProcessShipment(string requestUrl, HttpContent httpContent);
    }
}
