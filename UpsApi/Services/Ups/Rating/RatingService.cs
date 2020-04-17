using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using UpsApi.Models.RateRes;
using UpsApi.Services.Ups.Api;
using static UpsApi.Models.RateRes.BaseResponse;

namespace UpsApi.Services.Ups.Rating
{
    public class RatingService : IRatingService
    {
        private readonly IUpsApiService _upsApiService;
        public RatingService()
        {
            _upsApiService = new UpsApiService();
        }

        public RateResponse GetRate(string requestUrl, HttpContent httpContent)
        {
            var resObj = _upsApiService.GetResultFromUpsApi(requestUrl, httpContent);

            RateResponse resData = new RateResponse()
            {
                RatedShipment = new List<RatedShipment>()
            };

            if (resObj.IsSuccessStatusCode)
            {
                FormatRateResponse(resObj.JObject, resData, requestUrl);
                MapShipmentServiceDescription(resData);
            }
            else
            {
                
            }
           
            return resData;
        }

        private void FormatRateResponse(JObject resObj, RateResponse resData, string requestUrl)
        {
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
                        if (alerts.ToString().Contains("["))
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

                    if (requestUrl.Contains(AppSettings.UpsConfiguration.UpsRatingType.Shop)) //Shop Type
                    {
                        //Add RatedShipment
                        foreach (JObject item in resObj[typeof(RateResponse).Name][typeof(RatedShipment).Name].ToObject<List<JObject>>())
                        {
                            ratedShipment = CreateRatedShipment(item);
                            resData.RatedShipment.Add(ratedShipment);
                        }
                        //End Add RatedShipment
                    }

                    if (requestUrl.Contains(AppSettings.UpsConfiguration.UpsRatingType.Rate)) //Rate Type
                    {
                        //Add RatedShipment
                        ratedShipment = CreateRatedShipment(resObj[typeof(RateResponse).Name][typeof(RatedShipment).Name].ToObject<JObject>());
                        resData.RatedShipment.Add(ratedShipment);
                        //End Add RatedShipment
                    }
                }
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
                if (ratedShipmentAlerts.ToString().Contains("["))
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
                if (itemizedCharges.ToString().Contains("["))
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

        private void MapShipmentServiceDescription(RateResponse resData)
        {
            List<ShipmentService> listShipmentService = new List<ShipmentService>();
            LoadServiceCodes(listShipmentService);

            foreach (var item in resData.RatedShipment)
            {
                item.Service.Description = listShipmentService.Where(m => String.Equals(m.ServiceCode, item.Service?.Code)).FirstOrDefault()?.ServiceDescription;
            }
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
    }

    public class ShipmentService
    {
        public string ServiceCode { get; set; }
        public string ServiceDescription { get; set; }
    }
}