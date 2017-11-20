using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class MedicinalIngredientRepository : IMedicinalIngredientRepository
    {
       
        private List<MedicinalIngredient> ingredients = new List<MedicinalIngredient>();
        private MedicinalIngredient ingredient = new MedicinalIngredient();
        

    public IEnumerable<MedicinalIngredient> GetAll(string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            ingredients = dbConnection.GetAllMedicinalIngredient();

        return ingredients;
    }


    public IEnumerable<MedicinalIngredient> Get(int id, string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            ingredients = dbConnection.GetMedicinalIngredientById(id);
        return ingredients;
    }


    }
}