using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class DosageFormController : ApiController
    {
        static readonly IDosageFormRepository databasePlaceholder = new DosageFormRepository();

        public IEnumerable<DosageForm> GetAllProductForm(string lang="en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public IEnumerable<DosageForm> GetProductFormByID(int id, string lang = "en")
        {
            IEnumerable<DosageForm> formList = databasePlaceholder.Get(id, lang);
            //if (formList.Count()==0)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return formList;
        }
    }
}
