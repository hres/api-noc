using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class ProductRepository : IProductRepository
    {
       
        private List<Product> products = new List<Product>();
        private Product product = new Product();
        DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<Product> GetAll()
    {
        products = dbConnection.GetAllProduct();

        return products;
    }


    public IEnumerable<Product> Get(int id)
    {
        products = dbConnection.GetProductById(id);
        return products;
    }


    }
}