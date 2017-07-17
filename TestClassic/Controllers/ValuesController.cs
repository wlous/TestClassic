using System;
using System.Net;
using System.Web.Http;
using TestClassic.Models;
using TestClassic.Services;

namespace TestClassic.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpPost]
        [ActionName("/SkuUpdateStatus")]
        public HttpStatusCode Post(Guid apikey, [FromBody]MerchantProductUpdateRequest request)
        {
            try
            {
                if (request == null)
                    return HttpStatusCode.BadRequest;

                MerchantProductUpdateRequestService merchServ = new MerchantProductUpdateRequestService();
                return merchServ.UpdateProduct(apikey, request);
            }
            catch (Exception e)
            {
                return HttpStatusCode.InternalServerError;
            }   
        }
    }
}
