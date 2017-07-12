using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestClassic.Models
{
    public class ProductModel
    {
            public string ProductId { get; set; }
            public Guid MerchantId { get; set; }
            public string SKU { get; set; }
            public string ParentSKU { get; set; }
            public ProductType ProductType { get; set; }
            public string GTIN { get; set; }
            public string ManufacturerArticleNumber { get; set; }
            public string[] ProductClasses { get; set; }
            public string BrandName { get; set; }
            public string Title { get; set; }
            public int StockQuantity { get; set; }
            public string Status { get; set; }
            public string ExposedStatus { get; set; }
            public DateTime UpdatedUtc { get; set; }
            public ProductChannelModel[] SalesChannels { get; set; }
            public ProductCdonStatus CdonStatus;
            public int CdonProductId { get; set; }
            public string PickingLocation { get; set; }
     }

    public enum ProductType
    {
        Product = 0,

        [Display(Name = "Variation product")]
        VariationProduct = 1,

        Variation = 2
    }

    public struct ProductCdonStatus
    {
        public bool Online { get; set; }
    }

    public class ProductChannelModel
    {
        public string Culture { get; set; }
        public bool Sellable { get; set; }
        public string Currency { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal? OrdinaryPrice { get; set; }
        public decimal VAT { get; set; }
        public string CdonBaseUrl { get; set; }
        public string FreightClass { get; set; }
    }
    
}