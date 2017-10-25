using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class ProductIngredientController : ApiController
    {
        static readonly IProductIngredientRepository databasePlaceholder = new ProductIngredientRepository();

        public IEnumerable<ProductIngredient> GetAllProductIngredient(string lang="en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public IEnumerable<ProductIngredient> GetProductIngredientById(int id, string lang="en")
        {
            //ProductIngredient route = databasePlaceholder.Get(id, lang);
            IEnumerable<ProductIngredient> ingredientList = databasePlaceholder.Get(id, lang);
            //if (ingredientList.Count() == 0)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return ingredientList;
        }
    }
}
