using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace nocWebApi.Controllers
{
    public class ProductIngredientController : ApiController
    {
        static readonly IProductIngredientRepository databasePlaceholder = new ProductIngredientRepository();

        public IEnumerable<ProductIngredient> GetAllProductIngredient(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ProductIngredient GetProductIngredientById(int id, string lang)
        {
            ProductIngredient route = databasePlaceholder.Get(id, lang);
            if (route == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return route;
        }
    }
}
