using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UpsApi.Models.RateRes
{
    public class BaseResponse
    {
        public class Response
        {
            public ResponseStatus ResponseStatus { get; set; }
            public List<Alert> ListAlert { get; set; }
            public TransactionReference TransactionReference { get; set; }
        }

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

        public class TransactionReference
        {
            public string CustomerContext { get; set; }
        }

        public class RatedShipment
        {
            public Disclaimer Disclaimer { get; set; }
            public Service Service { get; set; }
            public List<RatedShipmentAlert> ListRatedShipmentAlert { get; set; }
            public BillingWeight BillingWeight { get; set; }
            public TransportationCharges TransportationCharges { get; set; }
            public BaseServiceCharge BaseServiceCharge { get; set; }
            public List<ItemizedCharges> ListItemizedCharges { get; set; }
            public ServiceOptionsCharges ServiceOptionsCharges { get; set; }
            public TotalCharges TotalCharges { get; set; }
            public NegotiatedRateCharges NegotiatedRateCharges { get; set; }
            public GuaranteedDelivery GuaranteedDelivery { get; set; }
            public RatedPackage RatedPackage { get; set; }
        }

        public class Disclaimer
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class Service
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class RatedShipmentAlert
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class BillingWeight
        {
            public UnitOfMeasurement UnitOfMeasurement { get; set; }
            public string Weight { get; set; }
        }

        public class UnitOfMeasurement
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class TransportationCharges
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class BaseServiceCharge
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class ItemizedCharges
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

        public class NegotiatedRateCharges
        {
            public TaxCharges TaxCharges { get; set; }
            public TotalCharge TotalCharge { get; set; }
            public TotalChargesWithTaxes TotalChargesWithTaxes { get; set; }
        }

        public class TaxCharges
        {
            public string Type { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class TotalCharge
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class TotalChargesWithTaxes
        {
            public string CurrencyCode { get; set; }
            public string MonetaryValue { get; set; }
        }

        public class GuaranteedDelivery
        {
            public string BusinessDaysInTransit { get; set; }
            public string DeliveryByTime { get; set; }
        }

        public class RatedPackage
        {
            public string NegotiatedCharges { get; set; }
            public string Weight { get; set; }
        }

    }
}