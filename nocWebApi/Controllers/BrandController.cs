using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class BrandController : ApiController
    {
        static readonly IBrandRepository databasePlaceholder = new BrandRepository();

        public IEnumerable<Brand> GetAllBrand()
        {

            return databasePlaceholder.GetAll();
        }


        public IEnumerable<Brand> GetBrandByID(int id)
        {
            //Brand brand = databasePlaceholder.Get(id);
            IEnumerable <Brand> brandList= databasePlaceholder.Get(id);
            if (brandList.Count() == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return brandList;
        }
    }
}
