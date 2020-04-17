using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using UpsApi.Models.Errors;
using UpsApi.Models.Ups.Shipping.ShipReq;
using UpsApi.Models.Ups.Shipping.ShipRes;
using UpsApi.Services.Ups.Api;
using static UpsApi.Models.Ups.Shipping.ShipRes.ShipmentResponseElements;

namespace UpsApi.Services.Ups.Shipping
{
    public class ShippingService : IShippingService
    {
        private readonly IUpsApiService _upsApiService;
        public ShippingService()
        {
            _upsApiService = new UpsApiService();
        }

        public ShipmentResponse ProcessShipment(string requestUrl, HttpContent httpContent)
        {
            var resObj = _upsApiService.GetResultFromUpsApi(requestUrl, httpContent);

            ShipmentResponse resData = new ShipmentResponse();
            ErrorsResponse resError = new ErrorsResponse();

            if (resObj.IsSuccessStatusCode)
            {
                FormatShipmentResponse(resObj.JObject, resData, requestUrl);
            }
            else
            {
                FormatErrorResponse(resObj.JObject, resError);
            }

            return resData;
        }

        private void FormatShipmentResponse(JObject resObj, ShipmentResponse resData, string requestUrl)
        {
            if (resObj != null && !String.IsNullOrEmpty(resObj.ToString()))
            {
                if (resObj.ContainsKey(typeof(ShipmentResponse).Name))
                {
                    //Assign Response
                    resData.Response = resObj[typeof(ShipmentResponse).Name][typeof(ShipmentResponseElements.Response).Name].ToObject<ShipmentResponseElements.Response>();
                    //End Assign Response

                    //Add Alert
                    var responseObj = resObj[typeof(ShipmentResponse).Name][typeof(ShipmentResponseElements.Response).Name].ToObject<JObject>();
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

                    //Assign ShipmentResults
                    resData.ShipmentResults = resObj[typeof(ShipmentResponse).Name][typeof(ShipmentResults).Name].ToObject<ShipmentResults>();
                    //End Assign ShipmentResults

                    //Add ItemizedCharges
                    var shipmentResultsObj = resObj[typeof(ShipmentResponse).Name][typeof(ShipmentResults).Name].ToObject<JObject>();
                    if (shipmentResultsObj.ContainsKey(typeof(ShipmentCharges).Name))
                    {
                        var shipmentChargeObj = shipmentResultsObj[typeof(ShipmentCharges).Name].ToObject<JObject>();
                        if (shipmentChargeObj.ContainsKey(typeof(ItemizedCharges).Name))
                        {
                            resData.ShipmentResults.ShipmentCharges.ListItemizedCharges = new List<ItemizedCharges>();
                            JToken itemizedCharges = shipmentChargeObj[typeof(ItemizedCharges).Name];
                            if (itemizedCharges.ToString().Contains("["))
                            {
                                resData.ShipmentResults.ShipmentCharges.ListItemizedCharges.AddRange(itemizedCharges.ToObject<List<ItemizedCharges>>());
                            }
                            else
                            {
                                resData.ShipmentResults.ShipmentCharges.ListItemizedCharges.Add(itemizedCharges.ToObject<ItemizedCharges>());
                            }
                        }
                    }
                    //End Add ItemizedCharges

                    //Add PackageResults
                    if (shipmentResultsObj.ContainsKey(typeof(PackageResults).Name))
                    {
                        resData.ShipmentResults.ListPackageResults = new List<PackageResults>();
                        JToken packageResults = shipmentResultsObj[typeof(PackageResults).Name];
                        if (packageResults.ToString().Contains("["))
                        {
                            resData.ShipmentResults.ListPackageResults.AddRange(packageResults.ToObject<List<PackageResults>>());
                        }
                        else
                        {
                            resData.ShipmentResults.ListPackageResults.Add(packageResults.ToObject<PackageResults>());
                        }
                    }
                    //End Add PackageResults
                }
            }
        }

        private void FormatErrorResponse(JObject resObj, ErrorsResponse resData)
        {
            if (resObj != null && !String.IsNullOrEmpty(resObj.ToString()))
            {
                resData.errors = new List<Error>();
                foreach (JObject item in resObj["response"]["errors"].ToObject<List<JObject>>())
                {
                    resData.errors.Add(item.ToObject<Error>());
                }
            }
        }
    }
}