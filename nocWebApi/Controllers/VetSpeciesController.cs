using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class VetSpeciesController : ApiController
    {
        static readonly IVetSpeciesRepository databasePlaceholder = new VetSpeciesRepository();

        public IEnumerable<VetSpecies> GetAllVetSpecies(string lang = "en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public IEnumerable<VetSpecies> GetVetSpeciesById(int id, string lang="en")
        {
            IEnumerable<VetSpecies> formList = databasePlaceholder.Get(id, lang);
            if (formList.Count() == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return formList;
        }
    }
}
