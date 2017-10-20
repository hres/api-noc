using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IProductIngredientRepository
    {
        IEnumerable<ProductIngredient> GetAll(string lang);
        IEnumerable<ProductIngredient> Get(int id, string lang);
    }
}
