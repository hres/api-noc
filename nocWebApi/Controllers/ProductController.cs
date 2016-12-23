using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace nocWebApi.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductRepository databasePlaceholder = new ProductRepository();

        public IEnumerable<Product> GetAllProduct()
        {

            return databasePlaceholder.GetAll();
        }


        public Product GetProductByID(int id)
        {
            Product product = databasePlaceholder.Get(id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }
    }
}
