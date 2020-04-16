using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UpsApi.Models.RateReq
{
    public class TransactionReference
    {
        [Required]
        public string CustomerContext { get; set; }
    }

    public class Request
    {
        [Required]
        public string SubVersion { get; set; }
        [Required]
        public TransactionReference TransactionReference { get; set; }
    }

    public class ShipmentRatingOptions
    {
        //public string UserLevelDiscountIndicator { get; set; }
        public string NegotiatedRatesIndicator { get; set; }
    }

    public class ShipperAddress
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string StateProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
    }

    public class Shipper
    {
        public string Name { get; set; }
        public string ShipperNumber { get; set; }
        public ShipperAddress Address { get; set; }
    }

    public class ShipToAddress
    {
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string StateProvinceCode { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string CountryCode { get; set; }
    }

    public class ShipTo
    {
        [Required]
        public string Name { get; set; }
        public ShipToAddress Address { get; set; }
    }

    public class ShipFromAddress
    {
        [Required]
        public string AddressLine { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string StateProvinceCode { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string CountryCode { get; set; }
    }

    public class ShipFrom
    {
        [Required]
        public string Name { get; set; }
        public ShipFromAddress Address { get; set; }
    }

    public class Service
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public class ShipmentTotalWeightUOM
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public class ShipmentTotalWeight
    {
        public ShipmentTotalWeightUOM UnitOfMeasurement { get; set; }
        [Required]
        public string Weight { get; set; }
    }

    public class PackagingType
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
    }

    public class DimensionsUOM
    {
        [Required]
        public string Code { get; set; }
    }

    public class Dimensions
    {
        public DimensionsUOM UnitOfMeasurement { get; set; }
        [Required]
        public string Length { get; set; }
        [Required]
        public string Width { get; set; }
        [Required]
        public string Height { get; set; }
    }

    public class PackageWeightUOM
    {
        [Required]
        public string Code { get; set; }
    }

    public class PackageWeight
    {
        public PackageWeightUOM UnitOfMeasurement { get; set; }
        public string Weight { get; set; }
    }

    public class Package
    {
        public PackagingType PackagingType { get; set; }
        public Dimensions Dimensions { get; set; }
        public PackageWeight PackageWeight { get; set; }
    }

    public class Shipment
    {
        public string TaxInformationIndicator { get; set; }
        public ShipmentRatingOptions ShipmentRatingOptions { get; set; }
        public Shipper Shipper { get; set; }
        public ShipTo ShipTo { get; set; }
        public ShipFrom ShipFrom { get; set; }
        public Service Service { get; set; }
        public ShipmentTotalWeight ShipmentTotalWeight { get; set; }
        public Package Package { get; set; }
    }

    public class RateRequest
    {
        public Request Request { get; set; }
        public Shipment Shipment { get; set; }
    }

}