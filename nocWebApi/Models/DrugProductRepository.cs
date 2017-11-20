using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class DrugProductRepository : IDrugProductRepository
    {
       
        private List<DrugProduct> brands = new List<DrugProduct>();
        private DrugProduct brand = new DrugProduct();
        DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<DrugProduct> GetAll()
    {
        brands = dbConnection.GetAllDrugProduct();

        return brands;
    }


    public IEnumerable<DrugProduct> Get(int id)
    {
        brands = dbConnection.GetDrugProductById(id);
        return brands;
    }


    }
}