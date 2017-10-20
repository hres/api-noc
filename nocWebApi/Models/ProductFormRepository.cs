using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class ProductFormRepository : IProductFormRepository
    {
       
        private List<ProductForm> forms = new List<ProductForm>();
        private ProductForm form = new ProductForm();
       


    public IEnumerable<ProductForm> GetAll(string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            forms = dbConnection.GetAllProductForm();

        return forms;
    }


    public IEnumerable<ProductForm> Get(int id, string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            forms = dbConnection.GetProductFormById(id);
        return forms;
    }


    }
}