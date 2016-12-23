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


    public Product Get(int id)
    {
        product = dbConnection.GetProductById(id);
        return product;
    }


    }
}