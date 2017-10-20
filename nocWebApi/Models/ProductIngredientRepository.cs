using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class ProductIngredientRepository : IProductIngredientRepository
    {
       
        private List<ProductIngredient> ingredients = new List<ProductIngredient>();
        private ProductIngredient ingredient = new ProductIngredient();
        

    public IEnumerable<ProductIngredient> GetAll(string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            ingredients = dbConnection.GetAllProductIngredient();

        return ingredients;
    }


    public IEnumerable<ProductIngredient> Get(int id, string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            ingredients = dbConnection.GetProductIngredientById(id);
        return ingredients;
    }


    }
}