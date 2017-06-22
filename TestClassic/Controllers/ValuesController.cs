using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestClassic.Models;
using TestClassic.Services;

namespace TestClassic.Controllers
{
    //[Route("api/[controller]")] //?
    public class ValuesController : ApiController
    {
        // GET api/values
        //[HttpGet]//?
        //public IEnumerable<string> Get()
        //{
        //TestIgenService testServ = new TestIgenService();

        //String newproduct;

        //Product product = testServ.CreateIndex();
        //newproduct = product.sku;
        //return new string[] { newproduct };
        ////return new string[] { "value1", "value2" };
        //}

        // GET api/values/5

        [HttpGet]
        public MerchantProductUpdateRequest Get(Guid apikey)
        {
            MerchantProductUpdateRequestService merchServ = new MerchantProductUpdateRequestService();

            return merchServ.GetProduct(apikey); ;
        }

        // POST api/values
        [HttpPost]
        [ActionName("/create")]
        public HttpStatusCode Post(Guid apikey, [FromBody]MerchantProductUpdateRequest request)
        {
            MerchantProductUpdateRequestService merchServ = new MerchantProductUpdateRequestService();
            MerchantProductUpdateRequest newProduct = merchServ.CreateProduct(apikey, request);

            return HttpStatusCode.Accepted;
        }

        // PUT api/values/5
        [HttpPut]//ändra till post sedan enligt instruktioner?
        [ActionName("/SkuUpdateStatus")]
        public HttpStatusCode Put(string apikey, [FromBody]MerchantProductUpdateRequest request)
        {
            MerchantProductUpdateRequestService merchServ = new MerchantProductUpdateRequestService();

            MerchantProductUpdateRequest updatedProduct = merchServ.UpdateProduct(apikey, request);

            //if (updatedProduct != null)
            //{
            //    return HttpStatusCode.OK;
            //}
            //else
            //{
            //    return HttpStatusCode.BadRequest;
            //}
            return HttpStatusCode.Accepted;
        }

       
        // DELETE api/values/5
        public void Delete(Guid apikey)
        {
            MerchantProductUpdateRequestService merchServ = new MerchantProductUpdateRequestService();
            merchServ.DeleteProduct(apikey);
        }
    }
}
