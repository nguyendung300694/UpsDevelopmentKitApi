using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UpsApi.Models.Ups.Shipping.ShipReq
{
    public class ShipmentRequestElements
    {
        public class Phone
        {
            public string Number { get; set; }
        }

        public class Address
        {
            [Required]
            public string AddressLine { get; set; }
            [Required]
            public string City { get; set; }
            [Required]
            public string CountryCode { get; set; }
            [Required]
            public string StateProvinceCode { get; set; }
            [Required]
            public string PostalCode { get; set; }
        }

        public class ShipperAddress
        {
            public string AddressLine { get; set; }
            public string City { get; set; }
            public string CountryCode { get; set; }
            public string StateProvinceCode { get; set; }
            public string PostalCode { get; set; }
        }

        public class Shipper
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string AttentionName { get; set; }
            public Phone Phone { get; set; }
            public string FaxNumber { get; set; }
            public string ShipperNumber { get; set; }
            public ShipperAddress Address { get; set; }
        }

        public class ShipTo
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string AttentionName { get; set; }
            public Phone Phone { get; set; }
            public string FaxNumber { get; set; }
            public Address Address { get; set; }
        }

        public class ShipFrom
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string AttentionName { get; set; }
            public Phone Phone { get; set; }
            public string FaxNumber { get; set; }
            public Address Address { get; set; }
        }

        public class BillShipper
        {
            public string AccountNumber { get; set; }
        }

        public class ShipmentCharge
        {
            public string Type { get; set; }
            public BillShipper BillShipper { get; set; }
        }

        public class PaymentInformation
        {
            public ShipmentCharge ShipmentCharge { get; set; }
        }

        public class Service
        {
            [Required]
            public string Code { get; set; }
            [Required]
            public string Description { get; set; }
        }

        public class Packaging
        {
            [Required]
            public string Code { get; set; }
            [Required]
            public string Description { get; set; }
        }

        public class UnitOfMeasurement
        {
            [Required]
            public string Code { get; set; }
        }

        public class Dimensions
        {
            public UnitOfMeasurement UnitOfMeasurement { get; set; }
            [Required]
            public string Length { get; set; }
            [Required]
            public string Width { get; set; }
            [Required]
            public string Height { get; set; }
        }

        public class PackageWeight
        {
            public UnitOfMeasurement UnitOfMeasurement { get; set; }
            [Required]
            public string Weight { get; set; }
        }

        public class Package
        {
            public string Description { get; set; }
            public Packaging Packaging { get; set; }
            public Dimensions Dimensions { get; set; }
            public PackageWeight PackageWeight { get; set; }
            //public string PackageServiceOptions { get; set; }
        }

        public class ShipmentRatingOptions
        {
            public string NegotiatedRatesIndicator { get; set; }
        }

        public class Shipment
        {
            public string Description { get; set; }
            public Shipper Shipper { get; set; }
            public ShipTo ShipTo { get; set; }
            public ShipFrom ShipFrom { get; set; }
            public PaymentInformation PaymentInformation { get; set; }
            public Service Service { get; set; }
            public List<Package> Package { get; set; }
            public string ItemizedChargesRequestedIndicator { get; set; }
            public string RatingMethodRequestedIndicator { get; set; }
            public string TaxInformationIndicator { get; set; }
            public ShipmentRatingOptions ShipmentRatingOptions { get; set; }
        }

        public class LabelImageFormat
        {
            [Required]
            public string Code { get; set; }
        }

        public class LabelSpecification
        {
            public LabelImageFormat LabelImageFormat { get; set; }
        }
    }
}