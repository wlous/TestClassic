using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
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
            var productIndex = "products";
            settings.DefaultIndex("elasticsearch");
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

        public MerchantProductUpdateRequest GetProduct(String apikey)
        {
            var getResponse = client.Get<MerchantProductUpdateRequest>(apikey);

            return getResponse.Source;
        }
        
        //nedanstående metod är bara för testpurposes, tas bort sedan
        public MerchantProductUpdateRequest CreateProduct (MerchantProductUpdateRequest product)
        {
            //Ett nytt index av typen MerchantProductUpdateRequest läggs till i elasticsearch
            var indexResponse = client.Index(product);
            
            return product;
        }
        public MerchantProductUpdateRequest UpdateProduct(Guid apikey, MerchantProductUpdateRequest request)
        {
            //Ta in apikey (en kombo av merchantid (en guid) och product id (sku) som inparameter. Detta är det unika produktid.
            //hitta produkten i elasticsearch-instansen
            var getResponse = client.Get<MerchantProductUpdateRequest>(apikey);// eller id?

            //spara documentet i merchantproduct
            var merchantProduct = getResponse.Source;
            
            //uppdatera produkten eller posta den?
            //client.Update();
            
            return request;
        }

        public void DeleteProduct (Guid apikey)
        {
            client.Delete<MerchantProductUpdateRequest>(apikey);

        }
    }
}