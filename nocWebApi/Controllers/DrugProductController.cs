using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class DrugProductController : ApiController
    {
        static readonly IDrugProductRepository databasePlaceholder = new DrugProductRepository();

        public IEnumerable<DrugProduct> GetAllBrand()
        {

            return databasePlaceholder.GetAll();
        }


        public IEnumerable<DrugProduct> GetBrandByID(int id)
        {
            //Brand brand = databasePlaceholder.Get(id);
            IEnumerable <DrugProduct> brandList= databasePlaceholder.Get(id);
            //if (brandList.Count() == 0)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return brandList;
        }
    }
}
