using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IMedicinalIngredientRepository
    {
        IEnumerable<MedicinalIngredient> GetAll(string lang);
        IEnumerable<MedicinalIngredient> Get(int id, string lang);
    }
}
