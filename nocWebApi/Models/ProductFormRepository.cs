using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class ProductFormRepository : IProductFormRepository
    {
       
        private List<ProductForm> forms = new List<ProductForm>();
        private ProductForm form = new ProductForm();
        DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<ProductForm> GetAll()
    {
        forms = dbConnection.GetAllProductForm();

        return forms;
    }


    public ProductForm Get(int id)
    {
            form = dbConnection.GetProductFormById(id);
        return form;
    }


    }
}