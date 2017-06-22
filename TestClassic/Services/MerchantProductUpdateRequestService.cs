using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestClassic.Models;
using TestClassic.Repositories;

namespace TestClassic.Services
{
    public class MerchantProductUpdateRequestService
    {
        public MerchantProductUpdateRequest GetProduct(Guid apikey)
        {
            MerchantProductUpdateRequestRepository merchRepo = new MerchantProductUpdateRequestRepository();
            //string id = apikey.ToString();
            return merchRepo.GetProduct(apikey);
        }
        public MerchantProductUpdateRequest CreateProduct(Guid apikey, MerchantProductUpdateRequest request)
        {
            request.Apikey = apikey;//sätter productens apikey till den som fanns i url:en

            //lägger ihop apikey från url:en med sku:en i instansen request för att få det unika produktid:et
            //request.Id = apikey + request.Skus.ElementAt(0).SKU;
            request.Id = apikey.ToString();

            MerchantProductUpdateRequestRepository merchRepo = new MerchantProductUpdateRequestRepository();
            merchRepo.CreateProduct(request);
            return request;
        }

        public MerchantProductUpdateRequest UpdateProduct(string apikey, MerchantProductUpdateRequest request)
        {
            MerchantProductUpdateRequestRepository merchRepo = new MerchantProductUpdateRequestRepository();
            merchRepo.UpdateProduct(apikey, request);
            
            return request;
        }

        public void DeleteProduct(Guid apikey)
        {
            MerchantProductUpdateRequestRepository merchRepo = new MerchantProductUpdateRequestRepository();

            merchRepo.DeleteProduct(apikey);
        }
    }
}