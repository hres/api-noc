using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class MedicinalIngredientController : ApiController
    {
        static readonly IMedicinalIngredientRepository databasePlaceholder = new MedicinalIngredientRepository();

        public IEnumerable<MedicinalIngredient> GetAllMedicinalIngredient(string lang="en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public IEnumerable<MedicinalIngredient> GetMedicinalIngredientById(int id, string lang="en")
        {
            //ProductIngredient route = databasePlaceholder.Get(id, lang);
            IEnumerable<MedicinalIngredient> ingredientList = databasePlaceholder.Get(id, lang);
            //if (ingredientList.Count() == 0)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return ingredientList;
        }
    }
}
