using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using UpsApi.Models.RateReq;
using UpsApi.Models.RateRes;
using UpsApi.Models.Ups.Shipping.ShipReq;
using UpsApi.Models.Ups.Shipping.ShipRes;
using UpsApi.Models.ViewModel;
using UpsApi.Services.Ups.Rating;
using UpsApi.Services.Ups.Shipping;
using static UpsApi.Models.RateRes.BaseResponse;

namespace UpsApi.Controllers
{
    public class HomeController : Controller
    {
        //Rating
        private const string _rateRequestUri = "https://onlinetools.ups.com/ship/v1/rating/Rate";
        private const string _shopRequestUri = "https://onlinetools.ups.com/ship/v1/rating/Shop";
        //End Rating

        //Shipping
        private const string _shipRequestUriCIE = "https://wwwcie.ups.com/ship/v1807/shipments?additionaladdressvalidation=city";
        private const string _shopRequestUriPoduction = "";
        //End Shipping

        private readonly IRatingService _ratingService;
        private readonly IShippingService _shippingService;

        public HomeController()
        {
            _ratingService = new RatingService();
            _shippingService = new ShippingService();
        }

        public ActionResult Rate()
        {
            return View();
        }

        public ActionResult Ship()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetShop(RateRequestViewModel model, string requestUrl = _rateRequestUri)
        {
            try
            {
                Shipper shipper = new Shipper
                {
                    Name = model.RateRequest.Shipment.ShipFrom.Name,
                    ShipperNumber = "132R1V",
                    Address = new ShipperAddress
                    {
                        AddressLine = model.RateRequest.Shipment.ShipFrom.Address.AddressLine,
                        City = model.RateRequest.Shipment.ShipFrom.Address.City,
                        CountryCode = model.RateRequest.Shipment.ShipFrom.Address.CountryCode,
                        StateProvinceCode = model.RateRequest.Shipment.ShipFrom.Address.StateProvinceCode,
                        PostalCode = model.RateRequest.Shipment.ShipFrom.Address.PostalCode
                    }
                };

                model.RateRequest.Shipment.Shipper = shipper;

                model.RateRequest.Shipment.Shipper.Address.PostalCode = model.RateRequest.Shipment.Shipper.Address.PostalCode.Replace(" ", String.Empty);
                model.RateRequest.Shipment.ShipFrom.Address.PostalCode = model.RateRequest.Shipment.ShipFrom.Address.PostalCode.Replace(" ", String.Empty);
                model.RateRequest.Shipment.ShipTo.Address.PostalCode = model.RateRequest.Shipment.ShipTo.Address.PostalCode.Replace(" ", String.Empty);

                HttpContent httContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8);
                RateResponse resData = _ratingService.GetRate(requestUrl, httContent);

                return Json(new { success = true, resData });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.ToString() });
            }
        }

        [HttpPost]
        public JsonResult ProcessShipment(ShipmentRequestRootObject model, string requestUrl = _shipRequestUriCIE)
        {
            try
            {
                var accountNbr = "132R1V";
                ShipmentRequestElements.Shipper shipper = new ShipmentRequestElements.Shipper
                {
                    Name = model.ShipmentRequest.Shipment.ShipFrom.Name,
                    ShipperNumber = accountNbr,
                    AttentionName = model.ShipmentRequest.Shipment.ShipFrom.AttentionName,
                    Phone = new ShipmentRequestElements.Phone
                    {
                        Number = model.ShipmentRequest.Shipment.ShipFrom.Phone.Number
                    },
                    FaxNumber = model.ShipmentRequest.Shipment.ShipFrom.FaxNumber,
                    Address = new ShipmentRequestElements.ShipperAddress
                    {
                        AddressLine = model.ShipmentRequest.Shipment.ShipFrom.Address.AddressLine,
                        City = model.ShipmentRequest.Shipment.ShipFrom.Address.City,
                        CountryCode = model.ShipmentRequest.Shipment.ShipFrom.Address.CountryCode,
                        StateProvinceCode = model.ShipmentRequest.Shipment.ShipFrom.Address.StateProvinceCode,
                        PostalCode = model.ShipmentRequest.Shipment.ShipFrom.Address.PostalCode
                    }
                };

                model.ShipmentRequest.Shipment.Shipper = shipper;
                model.ShipmentRequest.Shipment.PaymentInformation = new ShipmentRequestElements.PaymentInformation
                {
                    ShipmentCharge = new ShipmentRequestElements.ShipmentCharge
                    {
                        Type = "01", //Shipment
                        BillShipper = new ShipmentRequestElements.BillShipper
                        {
                            AccountNumber = accountNbr
                        }
                    }
                };

                model.ShipmentRequest.Shipment.Shipper.Address.PostalCode = model.ShipmentRequest.Shipment.Shipper.Address.PostalCode.Replace(" ", String.Empty);
                model.ShipmentRequest.Shipment.ShipFrom.Address.PostalCode = model.ShipmentRequest.Shipment.ShipFrom.Address.PostalCode.Replace(" ", String.Empty);
                model.ShipmentRequest.Shipment.ShipTo.Address.PostalCode = model.ShipmentRequest.Shipment.ShipTo.Address.PostalCode.Replace(" ", String.Empty);

                HttpContent httContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8);
                ShipmentResponse resData = _shippingService.ProcessShipment(requestUrl, httContent);

                return Json(new { success = true, resData });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.ToString() });
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}