using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace nocWebApi.Controllers
{
    public class BrandController : ApiController
    {
        static readonly IBrandRepository databasePlaceholder = new BrandRepository();

        public IEnumerable<Brand> GetAllBrand()
        {

            return databasePlaceholder.GetAll();
        }


        public Brand GetBrandByID(int id)
        {
            Brand brand = databasePlaceholder.Get(id);
            if (brand == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return brand;
        }
    }
}
