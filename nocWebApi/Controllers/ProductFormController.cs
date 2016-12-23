using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace nocWebApi.Controllers
{
    public class ProductFormController : ApiController
    {
        static readonly IProductFormRepository databasePlaceholder = new ProductFormRepository();

        public IEnumerable<ProductForm> GetAllProductForm()
        {

            return databasePlaceholder.GetAll();
        }


        public ProductForm GetProductFormByID(int id)
        {
            ProductForm form = databasePlaceholder.Get(id);
            if (form == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return form;
        }
    }
}
