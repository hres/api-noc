using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IDrugProductRepository
    {
        IEnumerable<DrugProduct> GetAll();
        IEnumerable<DrugProduct> Get(int id);
    }
}
