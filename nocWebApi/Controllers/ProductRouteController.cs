using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class ProductRouteController : ApiController
    {
        static readonly IProductRouteRepository databasePlaceholder = new ProductRouteRepository();

        public IEnumerable<ProductRoute> GetAllProductRoute(string lang = "en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public IEnumerable<ProductRoute> GetProductRouteById(int id, string lang="en")
        {
            IEnumerable<ProductRoute> routeList = databasePlaceholder.Get(id, lang);
            //if (routeList.Count() == 0)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return routeList;
        }
    }
}
