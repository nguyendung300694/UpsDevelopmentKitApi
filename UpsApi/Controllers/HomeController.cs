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
            //string telemetry = "{\"RateRequest\":{\"Request\":{\"SubVersion\":\"1801\",\"TransactionReference\":{\"CustomerContext\":\"\"}},\"Shipment\":{\"ShipmentRatingOptions\":{\"UserLevelDiscountIndicator\":\"\",\"NegotiatedRatesIndicator\":\"\"},\"Shipper\":{\"ShipperNumber\":\"132R1V\",\"Address\":{\"City\":\"Roswell\",\"StateProvinceCode\":\"GA\",\"PostalCode\":\"30076\",\"CountryCode\":\"US\"}},\"ShipTo\":{\"Address\":{\"City\":\"PALM SPRINGS\",\"StateProvinceCode\":\"CA\",\"PostalCode\":\"92262\",\"CountryCode\":\"US\"}},\"ShipFrom\":{\"Address\":{\"City\":\"Roswell\",\"StateProvinceCode\":\"GA\",\"PostalCode\":\"30076\",\"CountryCode\":\"US\"}},\"Service\":{\"Code\":\"02\",\"Description\":\"UPS Second Day Air\"},\"ShipmentTotalWeight\":{\"UnitOfMeasurement\":{\"Code\":\"LBS\",\"Description\":\"Pounds\"},\"Weight\":\"21\"},\"Package\":{\"PackagingType\":{\"Code\":\"02\",\"Description\":\"Package\"},\"Dimensions\":{\"UnitOfMeasurement\":{\"Code\":\"IN\"},\"Length\":\"24\",\"Width\":\"12\",\"Height\":\"12\"},\"PackageWeight\":{\"UnitOfMeasurement\":{\"Code\":\"LBS\"},\"Weight\":\"21\"}}}}}";

            //using (var client = new HttpClient())
            //{
            //    object data = null;
            //    //client.BaseAddress = new Uri(AppSettings.LicenceManagementHostName);
            //    // Add an Accept header for JSON format.
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    client.DefaultRequestHeaders.Add("AccessLicenseNumber", "9D7BE954A85D0935");
            //    client.DefaultRequestHeaders.Add("Username", "i3dvrshipping");
            //    client.DefaultRequestHeaders.Add("Password", "i3DVR9991");

            //    //HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(telemetry), Encoding.UTF8);
            //    HttpContent httpContent = new StringContent(telemetry);
            //    // List data response.
            //    var getTask = client.PostAsync(string.Format("{0}{1}", "https://onlinetools.ups.com", "/ship/v1/rating/Rate"), httpContent);// Blocking call! Program will wait here until a response is received or a timeout occurs.
            //    getTask.Wait();
            //    var response = getTask.Result;
            //    //response.EnsureSuccessStatusCode();
            //    if (response != null && response.IsSuccessStatusCode)
            //    {
            //        // Parse the response body.
            //        var readTask = response.Content.ReadAsAsync<object>();//Make sure to add a reference to System.Net.Http.Formatting.dll
            //        readTask.Wait();
            //        data = readTask.Result;
            //    }
            //    client.Dispose();
            //}

            //try
            //{
            //    #region UPS Security

            //    UPSSecurity upss = new UPSSecurity();
            //    UPSSecurityUsernameToken upssUsrNameToken = new UPSSecurityUsernameToken();
            //    upssUsrNameToken.Username = "i3dvrshipping";
            //    upssUsrNameToken.Password = "i3DVR9991";
            //    upss.UsernameToken = upssUsrNameToken;

            //    UPSSecurityServiceAccessToken upssSvcAccessToken = new UPSSecurityServiceAccessToken();
            //    upssSvcAccessToken.AccessLicenseNumber = "9D7BE954A85D0935";
            //    upss.ServiceAccessToken = upssSvcAccessToken;

            //    #endregion End UPS Security


            //    #region UPS Rate Request

            //    RateRequest rateRequest = new RateRequest();

            //    RequestType request = new RequestType();
            //    String[] requestOption = { "Shop" };
            //    request.RequestOption = requestOption;
            //    rateRequest.Request = request;

            //    ShipmentType shipment = new ShipmentType();

            //    ShipperType shipper = new ShipperType();
            //    shipper.Name = "i3 International Inc.";
            //    shipper.ShipperNumber = "132R1V";
            //    AddressType shipperAddress = new AddressType();
            //    shipperAddress.AddressLine = new string[] { "200 Foster Cr." };
            //    shipperAddress.City = "Mississauga";
            //    shipperAddress.StateProvinceCode = "ON";
            //    shipperAddress.PostalCode = "L5R3Y5";
            //    shipperAddress.CountryCode = "CA";
            //    shipper.Address = shipperAddress;
            //    shipment.Shipper = shipper;

            //    ShipFromType shipFrom = new ShipFromType();
            //    shipFrom.Name = "i3 International Inc.";
            //    ShipAddressType shipFromAddress = new ShipAddressType();
            //    shipFromAddress.AddressLine = new string[] { "200 Foster Cr." };
            //    shipFromAddress.City = "Mississauga";
            //    shipFromAddress.StateProvinceCode = "ON";
            //    shipFromAddress.PostalCode = "L5R3Y5";
            //    shipFromAddress.CountryCode = "CA";
            //    shipFrom.Address = shipFromAddress;
            //    shipment.ShipFrom = shipFrom;

            //    ShipToType shipTo = new ShipToType();
            //    shipTo.Name = "ADT Commercial LLC";
            //    ShipToAddressType shipToAddress = new ShipToAddressType();
            //    shipToAddress.AddressLine = new string[] { "1501 Yamato Road" };
            //    shipToAddress.City = "Boca Raton";
            //    shipToAddress.StateProvinceCode = "FL";
            //    shipToAddress.PostalCode = "33431";
            //    shipToAddress.CountryCode = "US";
            //    shipTo.Address = shipToAddress;
            //    shipment.ShipTo = shipTo;

            //    CodeDescriptionType service = new CodeDescriptionType();
            //    service.Code = "11";
            //    shipment.Service = service;

            //    PackageType package = new PackageType();

            //    CodeDescriptionType packType = new CodeDescriptionType();
            //    packType.Code = "02";
            //    package.PackagingType = packType;

            //    DimensionsType packageDimensions = new DimensionsType();
            //    CodeDescriptionType dimentionUom = new CodeDescriptionType();
            //    dimentionUom.Code = "IN";
            //    dimentionUom.Description = "inches";
            //    packageDimensions.UnitOfMeasurement = dimentionUom;
            //    packageDimensions.Length = "10";
            //    packageDimensions.Height = "7";
            //    packageDimensions.Width = "5";
            //    package.Dimensions = packageDimensions;

            //    PackageWeightType packageWeight = new PackageWeightType();
            //    CodeDescriptionType uom = new CodeDescriptionType();
            //    uom.Code = "LBS";
            //    uom.Description = "pounds";
            //    packageWeight.UnitOfMeasurement = uom;
            //    packageWeight.Weight = "7";
            //    package.PackageWeight = packageWeight;

            //    PackageType[] pkgArray = { package };
            //    shipment.Package = pkgArray;

            //    rateRequest.Shipment = shipment;

            //    ShipmentRatingOptionsType shipmentRatingOptions = new ShipmentRatingOptionsType();
            //    shipmentRatingOptions.UserLevelDiscountIndicator = string.Empty;
            //    shipmentRatingOptions.NegotiatedRatesIndicator = string.Empty;
            //    rateRequest.Shipment.ShipmentRatingOptions = shipmentRatingOptions;

            //    //RatePortTypeClient client = new RatePortTypeClient();
            //    //RateResponse rateResponse = client.ProcessRate(upss, rateRequest);

            //    string serializeObject = "{\"RateRequest\":{\"Request\":{\"SubVersion\":\"1703\",\"TransactionReference\":{\"CustomerContext\":\"          \"}},\"Shipment\":{\"ShipmentRatingOptions\":{\"UserLevelDiscountIndicator\":\"\",\"NegotiatedRatesIndicator\":\"\"},\"Shipper\":{\"Name\":\"Big Dog Security Systems, Inc.\",\"ShipperNumber\":\"132R1V\",\"Address\":{\"AddressLine\":\"8 Shannon Street\",\"City\":\"York\",\"StateProvinceCode\":\"ON\",\"PostalCode\":\"N0A1R0\",\"CountryCode\":\"CA\"}},\"ShipTo\":{\"Name\":\"Advanced Electrical Solutions LLC\",\"Address\":{\"AddressLine\":\"P.O BOX 1956\",\"City\":\"Bristol\",\"StateProvinceCode\":\"CT\",\"PostalCode\":\"06010\",\"CountryCode\":\"US\"}},\"ShipFrom\":{\"Name\":\"Big Dog Security Systems, Inc.\",\"Address\":{\"AddressLine\":\"8 Shannon Street\",\"City\":\"York\",\"StateProvinceCode\":\"ON\",\"PostalCode\":\"N0A1R0\",\"CountryCode\":\"CA\"}},\"Service\":{\"Code\":\"11\",\"Description\":\"UPS Standard\"},\"ShipmentTotalWeight\":{\"UnitOfMeasurement\":{\"Code\":\"LBS\",\"Description\":\"Pounds\"},\"Weight\":\"10\"},\"Package\":{\"PackagingType\":{\"Code\":\"02\",\"Description\":\"Package\"},\"Dimensions\":{\"UnitOfMeasurement\":{\"Code\":\"IN\"},\"Length\":\"10\",\"Width\":\"7\",\"Height\":\"5\"},\"PackageWeight\":{\"UnitOfMeasurement\":{\"Code\":\"LBS\"},\"Weight\":\"7\"}}}}}";

            //    HttpContent httpContent = new StringContent(serializeObject);


            //    //RateViewModel rateModel = GetRate(string.Format("{0}{1}", "https://onlinetools.ups.com", "/ship/v1/rating/Rate"), httpContent);
            //    ShopResponseViewModel shopModel = GetShop(string.Format("{0}{1}", "https://onlinetools.ups.com", "/ship/v1/rating/Shop"), httpContent);

            //    shopModel.RateResponse.RatedShipment.OrderByDescending(m => m.NegotiatedRateCharges.TotalCharge.MonetaryValue);

            //    return View(shopModel);

            //    #endregion End UPS Rate Request
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return View();
        }

        private RateResponseViewModel GetRate(string requestUri, HttpContent httpContent)
        {
            RateResponseViewModel model = null;
            using (var client = new HttpClient())
            {
                object data = null;
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("AccessLicenseNumber", "9D7BE954A85D0935");
                client.DefaultRequestHeaders.Add("Username", "i3dvrshipping");
                client.DefaultRequestHeaders.Add("Password", "i3DVR9991");

                // List data response.
                var getTask = client.PostAsync(requestUri, httpContent);// Blocking call! Program will wait here until a response is received or a timeout occurs.
                getTask.Wait();
                var response = getTask.Result;
                //response.EnsureSuccessStatusCode();
                if (response != null && response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var readTask = response.Content.ReadAsAsync<object>();//Make sure to add a reference to System.Net.Http.Formatting.dll
                    readTask.Wait();
                    data = readTask.Result;
                    if (data != null)
                    {
                        model = JsonConvert.DeserializeObject<RateResponseViewModel>(data.ToString());
                    }
                }
                client.Dispose();
            }
            return model;
        }

        private JObject GetShop(string requestUri, HttpContent httpContent)
        {
            JObject model = null;
            using (var client = new HttpClient())
            {
                object data = null;
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("AccessLicenseNumber", "9D7BE954A85D0935");
                client.DefaultRequestHeaders.Add("Username", "i3dvrshipping");
                client.DefaultRequestHeaders.Add("Password", "i3DVR9991");

                // List data response.
                var getTask = client.PostAsync(requestUri, httpContent);// Blocking call! Program will wait here until a response is received or a timeout occurs.
                getTask.Wait();
                var response = getTask.Result;
                response.EnsureSuccessStatusCode();
                if (response != null && response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var readTask = response.Content.ReadAsAsync<object>();//Make sure to add a reference to System.Net.Http.Formatting.dll
                    readTask.Wait();
                    data = readTask.Result;
                    if (data != null)
                    {
                        //model = JsonConvert.DeserializeObject<ShopResponseViewModel1>(data.ToString());
                        model = JObject.Parse(data.ToString());
                    }
                }
                client.Dispose();
            }
            return model;
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

                HttpContent httContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8);
                JObject resObj = GetShop(requestUrl, httContent);

                ShopResponse resData = new ShopResponse()
                {
                    RatedShipment = new List<RatedShipment>()
                };

                if (resObj != null && !String.IsNullOrEmpty(resObj.ToString()))
                {
                    if (resObj.ContainsKey(typeof(RateResponse).Name))
                    {
                        //Assign Response
                        resData.Response = resObj[typeof(RateResponse).Name][typeof(Response).Name].ToObject<Response>();
                        //End Assign Response

                        //Add Alert
                        var responseObj = resObj[typeof(RateResponse).Name][typeof(Response).Name].ToObject<JObject>();
                        if (responseObj.ContainsKey(typeof(Alert).Name))
                        {
                            resData.Response.ListAlert = new List<Alert>();
                            JToken alerts = responseObj[typeof(Alert).Name];
                            if (alerts.Children().Count() > 1)
                            {
                                resData.Response.ListAlert.AddRange(alerts.ToObject<List<Alert>>());
                            }
                            else
                            {
                                resData.Response.ListAlert.Add(alerts.ToObject<Alert>());
                            }
                        }
                        //End Add Alert

                        RatedShipment ratedShipment;

                        if (requestUrl.Contains("Shop")) //Shop Type
                        {
                            //Add RatedShipment
                            foreach (JObject item in resObj[typeof(RateResponse).Name][typeof(RatedShipment).Name].ToObject<List<JObject>>())
                            {
                                ratedShipment = CreateRatedShipment(item);
                                resData.RatedShipment.Add(ratedShipment);
                            }
                            //End Add RatedShipment
                        }

                        if (requestUrl.Contains("Rate")) //Rate Type
                        {
                            //Add RatedShipment
                            ratedShipment = CreateRatedShipment(resObj[typeof(RateResponse).Name][typeof(RatedShipment).Name].ToObject<JObject>());
                            resData.RatedShipment.Add(ratedShipment);
                            //End Add RatedShipment
                        }
                    }
                }


                //var listShipmentService = new List<ShipmentService>();
                //LoadServiceCodes(listShipmentService);

                //var resData = JsonConvert.DeserializeObject<ShopResponseViewModel>(obj.ToString());
                //MapShipmentServiceDescription(resData, listShipmentService);

                //if (resData != null)
                //{
                //    var alerts = obj["RateResponse"]["Response"]["Alert"].ToString();
                //    if (!String.IsNullOrEmpty(alerts))
                //    {
                //        resData.RateResponse.Response.ListAlert = new List<Alert>();
                //        if (alerts.Contains("["))
                //        {
                //            resData.RateResponse.Response.ListAlert.AddRange(JsonConvert.DeserializeObject<List<Alert>>(alerts.ToString()));
                //        }
                //        else
                //        {
                //            resData.RateResponse.Response.ListAlert.Add(JsonConvert.DeserializeObject<Alert>(alerts.ToString()));
                //        }
                //    }

                //    string ratedShipmentAlerts = string.Empty;
                //    string itemizedCharges = string.Empty;
                //    int index = 0;

                //    foreach (JObject item in JsonConvert.DeserializeObject<List<JObject>>(obj["RateResponse"]["RatedShipment"].ToString()))
                //    {
                //        ratedShipmentAlerts = item["RatedShipmentAlert"].ToString();
                //        if (!String.IsNullOrEmpty(ratedShipmentAlerts))
                //        {
                //            resData.RateResponse.RatedShipment.ElementAt(index).ListRatedShipmentAlert = new List<RatedShipmentAlert>();
                //            if (ratedShipmentAlerts.Contains("["))
                //            {
                //                resData.RateResponse.RatedShipment.ElementAt(index).ListRatedShipmentAlert
                //                    .AddRange(JsonConvert.DeserializeObject<List<RatedShipmentAlert>>(ratedShipmentAlerts.ToString()));
                //            }
                //            else
                //            {
                //                resData.RateResponse.RatedShipment.ElementAt(index).ListRatedShipmentAlert
                //                    .Add(JsonConvert.DeserializeObject<RatedShipmentAlert>(ratedShipmentAlerts.ToString()));

                //            }
                //        }

                //        itemizedCharges = item["ItemizedCharges"].ToString();
                //        if (!String.IsNullOrEmpty(itemizedCharges))
                //        {
                //            resData.RateResponse.RatedShipment.ElementAt(index).ListItemizedCharges = new List<ItemizedCharges>();
                //            if (itemizedCharges.Contains("["))
                //            {
                //                resData.RateResponse.RatedShipment.ElementAt(index).ListItemizedCharges
                //                    .AddRange(JsonConvert.DeserializeObject<List<ItemizedCharges>>(itemizedCharges.ToString()));

                //            }
                //            else
                //            {
                //                resData.RateResponse.RatedShipment.ElementAt(index).ListItemizedCharges
                //                    .Add(JsonConvert.DeserializeObject<ItemizedCharges>(itemizedCharges.ToString()));
                //            }
                //        }

                //        index++;
                //    }
                //}

                return Json(new { success = true, resData });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = ex.ToString() });
            }
        }

        private RatedShipment CreateRatedShipment(JObject item)
        {
            RatedShipment ratedShipment = item.ToObject<RatedShipment>();

            //Add RatedShipmentAlert
            if (item.ContainsKey(typeof(RatedShipmentAlert).Name))
            {
                ratedShipment.ListRatedShipmentAlert = new List<RatedShipmentAlert>();
                JToken ratedShipmentAlerts = item[typeof(RatedShipmentAlert).Name];
                if (ratedShipmentAlerts.Children().Count() > 1)
                {
                    ratedShipment.ListRatedShipmentAlert.AddRange(ratedShipmentAlerts.ToObject<List<RatedShipmentAlert>>());
                }
                else
                {
                    ratedShipment.ListRatedShipmentAlert.Add(ratedShipmentAlerts.ToObject<RatedShipmentAlert>());
                }
            }
            //End Add RatedShipmentAlert

            //Add ItemizedCharges
            if (item.ContainsKey(typeof(ItemizedCharges).Name))
            {
                ratedShipment.ListItemizedCharges = new List<ItemizedCharges>();
                JToken itemizedCharges = item[typeof(ItemizedCharges).Name];
                if (itemizedCharges.Children().Count() > 1)
                {
                    ratedShipment.ListItemizedCharges.AddRange(itemizedCharges.ToObject<List<ItemizedCharges>>());
                }
                else
                {
                    ratedShipment.ListItemizedCharges.Add(itemizedCharges.ToObject<ItemizedCharges>());
                }
            }
            //End Add ItemizedCharges

            return ratedShipment;
        }

        private void MapShipmentServiceDescription(ShopResponseViewModel resData, List<ShipmentService> listShipmentService)
        {
            foreach (var item in resData.RateResponse.RatedShipment)
            {
                item.Service.Description = listShipmentService.Where(m => String.Equals(m.ServiceCode, item.Service.Code)).FirstOrDefault()?.ServiceDescription;
            }
        }

        private void MapShipmentServiceDescription(RateResponseViewModel resData, List<ShipmentService> listShipmentService)
        {
            resData.RateResponse.RatedShipment.Service.Description = listShipmentService.Where(m => String.Equals(m.ServiceCode, resData.RateResponse.RatedShipment.Service.Code)).FirstOrDefault()?.ServiceDescription;
        }

        private void LoadServiceCodes(List<ShipmentService> listShipmentService)
        {
            listShipmentService.Add(new ShipmentService { ServiceCode = "01", ServiceDescription = "UPS Next Day Air" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "02", ServiceDescription = "UPS Second Day Air" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "03", ServiceDescription = "UPS Ground" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "07", ServiceDescription = "UPS Worldwide Express" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "08", ServiceDescription = "UPS Worldwide Expedited" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "11", ServiceDescription = "UPS Standard" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "12", ServiceDescription = "UPS 3-Day Select" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "13", ServiceDescription = "UPS Next Day Air Saver" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "14", ServiceDescription = "UPS Next Day Air Early AM" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "54", ServiceDescription = "UPS Worldwide Express Plus" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "59", ServiceDescription = "UPS 2nd Day Air AM" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "65", ServiceDescription = "UPS Express Saver" });
            listShipmentService.Add(new ShipmentService { ServiceCode = "93", ServiceDescription = "UPS Sure Post" });
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

                return Json(new { success = true, resData = new ShipmentResponse() });
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

    public class ShipmentService
    {
        public string ServiceCode { get; set; }
        public string ServiceDescription { get; set; }
    }
}