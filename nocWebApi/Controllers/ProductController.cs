using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductRepository databasePlaceholder = new ProductRepository();

        public IEnumerable<Product> GetAllProduct()
        {

            return databasePlaceholder.GetAll();
        }


        public IEnumerable<Product> GetProductByID(int id)
        {
            //Product product = databasePlaceholder.Get(id);
            IEnumerable < Product > productList = databasePlaceholder.Get(id);
            //if (productList.Count()== 0)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return productList;
        }
    }
}
