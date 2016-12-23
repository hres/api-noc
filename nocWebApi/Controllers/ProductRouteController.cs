using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace nocWebApi.Controllers
{
    public class ProductRouteController : ApiController
    {
        static readonly IProductRouteRepository databasePlaceholder = new ProductRouteRepository();

        public IEnumerable<ProductRoute> GetAllProductRoute()
        {

            return databasePlaceholder.GetAll();
        }


        public ProductRoute GetProductRouteByID(int id)
        {
            ProductRoute route = databasePlaceholder.Get(id);
            if (route == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return route;
        }
    }
}
