using System;
using System.Collections.Generic;
using System.Linq;
using TestClassic.Models;
using TestClassic.Repositories;
using Dapper;
using System.Net;

namespace TestClassic.Services
{
    public class MerchantProductUpdateRequestService
    {
        private Dictionary<string, string> _channelMappings = new Dictionary<string, string>
        {
            {"test.cdon.se", "se"},
            {"test.cdon.no", "no"},
            {"test.cdon.dk", "dk"},
            {"test.cdon.fi", "fi"}
        };

        public HttpStatusCode UpdateProduct(Guid apikey, MerchantProductUpdateRequest request)
        {
            MerchantProductUpdateRequestRepository merchRepo = new MerchantProductUpdateRequestRepository();

            foreach(var sku in request.Skus)
            {
                string productId;

                //hämta merchantid genom apikey från SQL-databas
                var merchantRepo = new MerchantSqlRepository();
                var merchant = merchantRepo.GetByApiKey(apikey);

                if(merchant == null)
                {
                    return HttpStatusCode.NotFound;
                    //throw new NullReferenceException($"merchant with apikey: {apikey} is missing!");
                }

                string merchantId = merchant.MerchantId.ToString().ToLowerInvariant();

                //hämta rätt produkt från DB
                productId = merchantId + "-" + sku.SKU;
                var product = merchRepo.GetProduct(productId);
                if (product == null)
                    continue;
                
                //Uppdatera lokala variabeln
                product.Status = sku.Status.ToString(); 
                product.ExposedStatus = sku.ExposeStatus.ToString();
                product.StockQuantity = sku.InStock;

                foreach(var channel in sku.Channels)
                {
                    var channelName = _channelMappings[channel.Channel];

                    var productChannel = product.SalesChannels.FirstOrDefault(p => string.Equals(p.Culture, channelName, StringComparison.OrdinalIgnoreCase));
                    if (productChannel == null)
                        continue;

                    productChannel.Sellable = channel.Sellable;
                    productChannel.OrdinaryPrice = channel.OrdinaryPrice;
                    productChannel.CurrentPrice = channel.CurrentPrice;
                    productChannel.VAT = channel.VAT;
                }
               
                //Skriv till ES anropa update i repository
                merchRepo.UpdateProduct(product);
            }
            return HttpStatusCode.OK;
        }
    }

    public class MerchantSqlRepository
    {
        public Merchant GetByApiKey(Guid key)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection(@"Data Source=sql-cl1.test.cdon.com\cl1; Initial Catalog=merchantadmin;User ID=merchant_admin;password=pGM@c1rE;"))
            {
                return connection
                    .Query<Merchant>("select MerchantId from merchant.tMerchant where ApiKey = @ApiKey", new { ApiKey = key })
                    .FirstOrDefault();
            }
        }
    }

    public class Merchant
    {
        public Guid MerchantId { get; set; }
    }
}