using System;
using TestClassic.Models;
using Nest;
using System.Net;

namespace TestClassic.Repositories
{
    public class MerchantProductUpdateRequestRepository
    {
        private Uri node;
        private ConnectionSettings settings;
        private ElasticClient client;

        public MerchantProductUpdateRequestRepository()
        {
            //node = new Uri("http://localhost:9200");
            node = new Uri("http://elastic1.test.cdon.com:9200");
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
            settings.DefaultIndex("products");
            client = new ElasticClient(settings);
            //detta är för testning så att jag tar bort indexet varje gång programmet körs.
            //if (client.IndexExists(productIndex).Exists)
            //    client.DeleteIndex(productIndex);
            //var createIndexResponse = client.CreateIndex(productIndex, c => c
            //    .Mappings(m => m
            //        .Map<ProductModel>(p => p
            //            .AutoMap()
            //        )
            //    )
            //);
        }

        public ProductModel GetProduct(string productId)
        {
            var getResponse = client.Get<ProductModel>(productId);
            return getResponse.Source;
        }
                
        public HttpStatusCode UpdateProduct(ProductModel product)
        {
            var indexResponse = client.Index(product);
            if (indexResponse.ApiCall.HttpStatusCode == 200)
            {
                return HttpStatusCode.Accepted;
            }
            else
                return HttpStatusCode.InternalServerError;    
        }
    }
}