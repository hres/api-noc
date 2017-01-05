using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IProductIngredientRepository
    {
        IEnumerable<ProductIngredient> GetAll(string lang);
        ProductIngredient Get(int id, string lang);
    }
}
