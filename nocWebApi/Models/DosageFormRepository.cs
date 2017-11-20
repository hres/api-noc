using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class DosageFormRepository : IDosageFormRepository
    {
       
        private List<DosageForm> forms = new List<DosageForm>();
        private DosageForm form = new DosageForm();
       


    public IEnumerable<DosageForm> GetAll(string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            forms = dbConnection.GetAllDosageForm();

        return forms;
    }


    public IEnumerable<DosageForm> Get(int id, string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            forms = dbConnection.GetDosageFormById(id);
        return forms;
    }


    }
}