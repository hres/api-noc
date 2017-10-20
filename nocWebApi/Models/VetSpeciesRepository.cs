using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class VetSpeciesRepository : IVetSpeciesRepository
    {
       
        private List<VetSpecies> forms = new List<VetSpecies>();
        private VetSpecies form = new VetSpecies();


    public IEnumerable<VetSpecies> GetAll(string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            forms = dbConnection.GetAllVetSpecies();

        return forms;
    }


    public IEnumerable<VetSpecies> Get(int id, string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            forms = dbConnection.GetVetSpeciesById(id);
        return forms;
    }


    }
}