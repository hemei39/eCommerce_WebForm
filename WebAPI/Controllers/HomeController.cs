using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Authorize]
    public class HomeController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [ActionName("GetShoppingCart")]
        //[WebApiCacheOutput(CacheProfile = "DefaultClientAndServer")]
        //[SecurityLevel(SecurityProfile = "low")]
        public HttpResponseMessage GetShoppingCart()
        {
            DAL dal = new DAL();

            List<ShoppingCart> shoppingCart = dal.GetShoppingCart("vistor");

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, shoppingCart);

            return response;
        }
    }
}
