using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IDosageFormRepository
    {
        IEnumerable<DosageForm> GetAll(string lang);
        IEnumerable<DosageForm> Get(int id, string lang);
    }
}
