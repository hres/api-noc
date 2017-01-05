using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace nocWebApi.Controllers
{
    public class VetSpeciesController : ApiController
    {
        static readonly IVetSpeciesRepository databasePlaceholder = new VetSpeciesRepository();

        public IEnumerable<VetSpecies> GetAllVetSpecies(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public VetSpecies GetVetSpeciesById(int id, string lang)
        {
            VetSpecies form = databasePlaceholder.Get(id, lang);
            if (form == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return form;
        }
    }
}
