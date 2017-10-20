using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IVetSpeciesRepository
    {
        IEnumerable<VetSpecies> GetAll(string lang);
        IEnumerable<VetSpecies> Get(int id, string lang);
    }
}
