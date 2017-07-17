using System;
using System.ComponentModel.DataAnnotations;

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




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Xml.Serialization;
//using Nest;

//namespace TestClassic.Models
//{
//    //internal static class IntegrationNamespacess
//    //{
//    //    public const string Namespace = "http://schemas.cdon.com/integration/0.1/merchant/sku_status/";
//    //}

//    [Serializable]
//    [XmlRoot(Namespace = IntegrationNamespaces.Namespace, ElementName = "request", DataType = "merchant_product_delete_request")]
//    public class ProductModel
//    {
//        public Guid Apikey { get; set; }

//        [XmlArray("products")]
//        [XmlArrayItem("product_status")]
//        public ProductData[] Products { get; set; }
//    }

//    [Serializable]
//    [XmlType(Namespace = IntegrationNamespaces.Namespace, TypeName = "merchant_product_response_result")]
//    [ElasticsearchType(IdProperty = nameof(ProductId))]
//    public class ProductData
//    {
//        [XmlAttribute("productId")]
//        public string ProductId { get; set; }

//        [XmlAttribute("merchantId")]
//        public Guid MerchantId { get; set; }

//        [XmlAttribute("sku")]
//        public string SKU { get; set; }

//        [XmlAttribute("parentSku")]
//        public string ParentSKU { get; set; }

//        [XmlAttribute("gtin")]
//        public string GTIN { get; set; }

//        [XmlAttribute("manufacturerArticleNumber")]
//        public string ManufacturerArticleNumber { get; set; }

//        [XmlArray("productClasses")]
//        [XmlArrayItem("productClass")]
//        public string[] ProductClasses { get; set; }

//        [XmlAttribute("brandName")]
//        public string BrandName { get; set; }

//        [XmlAttribute("title")]
//        public string Title { get; set; }

//        [XmlAttribute("stockQuantity")]
//        public int StockQuantity { get; set; }

//        [XmlAttribute("status")]
//        public string Status { get; set; }

//        [XmlAttribute("exposedStatus")]
//        public string ExposedStatus { get; set; }

//        [XmlAttribute("updatedUtc")]
//        public DateTime UpdatedUtc { get; set; }

//        [XmlArray("salesChannels")]
//        [XmlArrayItem("salesChannel")]
//        public ProductChannelModel[] SalesChannels { get; set; }

//        //[XmlAttribute("cdonStatus")]
//        //public ProductCdonStatus CdonStatus;

//        [XmlAttribute("cdonProductId")]
//        public int CdonProductId { get; set; }

//        [XmlAttribute("pickingLocation")]
//        public string PickingLocation { get; set; }
//    }

//    [Serializable]
//    [XmlType("productCdonStatus", Namespace = IntegrationNamespaces.Namespace)]
//    public struct ProductCdonStatus
//    {
//        public bool Online { get; set; }
//    }

//    [Serializable]
//    [XmlType(Namespace = IntegrationNamespaces.Namespace, TypeName = "product_channel_model")]
//    public class ProductChannelModel
//    {
//        [XmlElement("culture")]
//        public string Culture { get; set; }

//        [XmlElement("sellable")]
//        public bool Sellable { get; set; }
//        [XmlElement("currency")]
//        public string Currency { get; set; }

//        [XmlElement("currentPrice")]
//        public decimal CurrentPrice { get; set; }

//        [XmlElement("ordinaryPrice")]
//        public decimal? OrdinaryPrice { get; set; }

//        [XmlElement("vat")]
//        public decimal VAT { get; set; }

//        [XmlElement("cdonBaseUrl")]
//        public string CdonBaseUrl { get; set; }

//        [XmlElement("freightClass")]
//        public string FreightClass { get; set; }
//    }
//}