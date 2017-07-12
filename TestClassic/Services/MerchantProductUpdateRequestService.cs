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
        public List<ProductModel> GetProducts(Guid apikey, MerchantProductUpdateRequest request)
        {
            List<string> productIds = new List<string>();

            //hämta merchantid genom apikey från SQL-databas
            int merchantId = 111;

            //går igenom requestarrayen för att hitta sku, lägger ihop merchantid + sku och lägger in det i en arraylist av string.
            foreach (MerchantProductData t in request.Skus)
            {
                productIds.Add(merchantId + t.SKU);
            }
            MerchantProductUpdateRequestRepository merchRepo = new MerchantProductUpdateRequestRepository();
            
            return merchRepo.GetProducts(productIds);
        }
        public MerchantProductUpdateRequest CreateProduct(Guid apikey, MerchantProductUpdateRequest request)
        {

            MerchantProductUpdateRequestRepository merchRepo = new MerchantProductUpdateRequestRepository();
            merchRepo.CreateProduct(request);
            return request;
        }

        public MerchantProductUpdateRequest UpdateProduct(Guid apikey, MerchantProductUpdateRequest request)
        {
            //hämtar lista med de produkter som ska uppdateras från databasen
            List<ProductModel> products = GetProducts(apikey, request);

           
            //här sker själva uppdateringen
            for (int i = 0; i < request.Skus.Length; i++)
            {
                for (int j = 0; j < products.Count; j++)
                {
                    if (products[i].SKU == request.Skus[j].SKU)
                    {
                        //status= online/offline
                        products[i].Status = request.Skus[j].Status.ToString(); //kanske behöver casta till string först. alltså ((string)request.Skus[j].Status.ToString();
                        //behöver jag sätta cdonproductstatus korrekt också?
                       
                        //exposestatus
                        products[i].ExposedStatus = request.Skus[j].ExposeStatus.ToString();//kanske casta till string?

                        //instock
                        products[i].StockQuantity = request.Skus[j].InStock;

                        //channels
                        for (int k = 0; k < request.Skus[j].Channels.Length; k++)
                        {
                            for (int l = 0; l < products[i].SalesChannels.Length; l++)
                            {
                                if (products[i].SalesChannels[l].Culture == request.Skus[j].Channels[k].Culture)//är det culture som man ska jämföra?
                                {
                                    products[i].SalesChannels[l].Sellable = request.Skus[j].Channels[k].Sellable;
                                    products[i].SalesChannels[l].OrdinaryPrice = request.Skus[j].Channels[k].OrdinaryPrice;
                                    products[i].SalesChannels[l].CurrentPrice = request.Skus[j].Channels[k].CurrentPrice;
                                    products[i].SalesChannels[l].VAT = request.Skus[j].Channels[k].VAT;
                                }
                            }   
                        }
                    }
                }
            }

            MerchantProductUpdateRequestRepository merchRepo = new MerchantProductUpdateRequestRepository();
            merchRepo.UpdateProduct(products);
            return request;
        }

        public void DeleteProduct(Guid apikey)
        {
            MerchantProductUpdateRequestRepository merchRepo = new MerchantProductUpdateRequestRepository();

            merchRepo.DeleteProduct(apikey);
        }
    }
}