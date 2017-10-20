using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class ProductFormController : ApiController
    {
        static readonly IProductFormRepository databasePlaceholder = new ProductFormRepository();

        public IEnumerable<ProductForm> GetAllProductForm(string lang="en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public IEnumerable<ProductForm> GetProductFormByID(int id, string lang = "en")
        {
            IEnumerable<ProductForm> formList = databasePlaceholder.Get(id, lang);
            if (formList.Count()==0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return formList;
        }
    }
}
