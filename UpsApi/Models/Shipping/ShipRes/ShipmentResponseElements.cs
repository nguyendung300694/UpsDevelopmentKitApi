using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShippingServiceRestApi.Models.Ups.Shipping.ShipRes
{
    public class ShipmentResponseElements
    {
        public class ResponseStatus
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class Alert
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class Response
        {
            public ResponseStatus ResponseStatus { get; set; }
            public List<Alert> ListAlert { get; set; }
            public string TransactionReference { get; set; }
        }

        public class Disclaimer
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class BaseServiceCharge
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class TransportationCharges
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class ItemizedCharge
        {
            public string Code { get; set; }
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class ServiceOptionsCharges
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class TotalCharges
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class ShipmentCharges
        {
            public BaseServiceCharge BaseServiceCharge { get; set; }
            public TransportationCharges TransportationCharges { get; set; }
            public List<ItemizedCharge> ListItemizedCharges { get; set; }
            public ServiceOptionsCharges ServiceOptionsCharges { get; set; }
            public TotalCharges TotalCharges { get; set; }
        }

        public class TotalCharge
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class TaxCharges
        {
            public string Type { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class TotalChargesWithTaxes
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class NegotiatedRateCharges
        {
            public TotalCharge TotalCharge { get; set; }
            public TaxCharges TaxCharges { get; set; }
            public TotalChargesWithTaxes TotalChargesWithTaxes { get; set; }
        }

        public class UnitOfMeasurement
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class BillingWeight
        {
            public UnitOfMeasurement UnitOfMeasurement { get; set; }
            public string Weight { get; set; }
        }

        public class ServiceOptionsCharges2
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class ImageFormat
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class ShippingLabel
        {
            public ImageFormat ImageFormat { get; set; }
            public string GraphicImage { get; set; }
            public string HTMLImage { get; set; }
        }

        public class PackageResults
        {
            public string TrackingNumber { get; set; }
            public ServiceOptionsCharges2 ServiceOptionsCharges { get; set; }
            public ShippingLabel ShippingLabel { get; set; }
        }

        public class ShipmentResults
        {
            public Disclaimer Disclaimer { get; set; }
            public ShipmentCharges ShipmentCharges { get; set; }
            public NegotiatedRateCharges NegotiatedRateCharges { get; set; }
            public string RatingMethod { get; set; }
            public string BillableWeightCalculationMethod { get; set; }
            public BillingWeight BillingWeight { get; set; }
            public string ShipmentIdentificationNumber { get; set; }
            public List<PackageResults> ListPackageResults { get; set; }
        }
    }
}