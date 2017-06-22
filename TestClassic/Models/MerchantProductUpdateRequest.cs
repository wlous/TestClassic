using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace TestClassic.Models
{
    internal static class IntegrationNamespaces
    {
        public const string Namespace = "http://schemas.cdon.com/integration/0.1/merchant/sku-status/";
    }

    [Serializable]
    [XmlRoot(Namespace = IntegrationNamespaces.Namespace, ElementName = "request", DataType = "merchant_product_delete_request")]
    public class MerchantProductUpdateRequest
    {
        public Guid Apikey { get; set; }
        public string Id { get; set; } 

        [XmlArray("skus")]
        [XmlArrayItem("sku_status")]
        public MerchantProductData[] Skus { get; set; }
    }

    [Serializable]
    [XmlType(Namespace = IntegrationNamespaces.Namespace, TypeName = "merchant_product_response_result")]
    public class MerchantProductData
    {
        [XmlAttribute("sku")]
        public string SKU { get; set; }

        [XmlAttribute("productId")]
        public int ProductId { get; set; }

        [XmlAttribute("status")]
        public ProductStatus Status { get; set; }

        [XmlAttribute("exposure")]
        public ProductExposure ExposeStatus { get; set; }

        [XmlAttribute("inStock")]
        public int InStock { get; set; }

        [XmlArray("channels")]
        [XmlArrayItem("channel")]
        public MerchantProductChannelData[] Channels { get; set; }
    }

    [Serializable]
    [XmlType(Namespace = IntegrationNamespaces.Namespace,
        TypeName = "product_channel_info")]//r107
    public class MerchantProductChannelData
    {
        [XmlElement("channel")]
        public string Channel { get; set; }

        [XmlElement("sellable")]
        public bool Sellable { get; set; }

        [XmlElement("ordinary_price")]
        public decimal? OrdinaryPrice { get; set; }

        [XmlElement("current_price")]
        public decimal CurrentPrice { get; set; }

        [XmlElement("vat")]
        public decimal VAT { get; set; }

        [XmlElement("culture")]
        public string Culture { get; set; }
    }

    [XmlType("productStatus", Namespace = IntegrationNamespaces.Namespace)]
    public enum ProductStatus
    {
        [XmlEnum("none")]
        None,

        [XmlEnum("offline")]
        Offline,

        [XmlEnum("online")]
        Online,

        [XmlEnum("deleted")]
        Deleted
    }

    [XmlType("productExposure", Namespace = IntegrationNamespaces.Namespace)]
    public enum ProductExposure
    {
        [XmlEnum("unknown")]
        Unknown,

        [XmlEnum("buyable")]
        Buyable,

        [XmlEnum("bookable")]
        Bookable,

        [XmlEnum("subscribable")]
        Guardable,

        [XmlEnum("watchable")]
        Watchable
    }
}
