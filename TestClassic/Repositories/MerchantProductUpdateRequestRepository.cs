using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Web;
using System.Web.UI;
using TestClassic.Models;
using Nest;

namespace TestClassic.Repositories
{
   
    public class MerchantProductUpdateRequestRepository
    {
        private Uri node;
        private ConnectionSettings settings;
        private ElasticClient client;


        public MerchantProductUpdateRequestRepository()
        {
            node = new Uri("http://localhost:9200");
            settings = new ConnectionSettings(node);
            //settings.PrettyJson().DisableDirectStreaming().OnRequestCompleted(details =>
            //{
            //    if(details.RequestBodyInBytes != null)
            //    {
            //        var req = Encoding.UTF8.GetString(details.RequestBodyInBytes);

            //    }

            //    if (details.ResponseBodyInBytes != null)
            //    {
            //        var res = Encoding.UTF8.GetString(details.ResponseBodyInBytes);

            //    }

            //});
            var productIndex = "products";
            settings.DefaultIndex("louisesnewestdatabas");
            client = new ElasticClient(settings);
            //detta är för testning så att jag tar bort indexet varje gång programmet körs.
            if (client.IndexExists(productIndex).Exists)
                client.DeleteIndex(productIndex);
            var createIndexResponse = client.CreateIndex(productIndex, c => c
                .Mappings(m => m
                    .Map<MerchantProductUpdateRequest>(p => p
                        .AutoMap()
                    )
                )
            );
        }

        public List<ProductModel> GetProducts(List<string> productIds)
        {
            List<ProductModel> products = new List<ProductModel>();

            foreach (var productId in productIds)
            {
                var getResponse = client.Get<ProductModel>(productId);

                products.Add(getResponse.Source);
            }

            return products;
        }
        
        //nedanstående metod är bara för testpurposes, tas bort sedan
        public MerchantProductUpdateRequest CreateProduct (MerchantProductUpdateRequest product)
        {
            //Ett nytt index av typen MerchantProductUpdateRequest läggs till i louisesdatabas
            var indexResponse = client.Index(product);

            return product;
        }
        public List<ProductModel> UpdateProduct(List<ProductModel> products)
        {
            foreach (var product in products)
            {
               var indexResponse = client.Index(product);//fattar den själv att den ska radera de gamla produkterna?
            }

            return products;
        }

        public void DeleteProduct (Guid apikey)
        {
            client.Delete<MerchantProductUpdateRequest>(apikey);

        }
    }
}