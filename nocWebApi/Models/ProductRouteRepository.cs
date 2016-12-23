using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class ProductRouteRepository : IProductRouteRepository
    {
       
        private List<ProductRoute> routes = new List<ProductRoute>();
        private ProductRoute route = new ProductRoute();
        DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<ProductRoute> GetAll()
    {
        routes = dbConnection.GetAllProductRoute();

        return routes;
    }


    public ProductRoute Get(int id)
    {
            route = dbConnection.GetProductRouteById(id);
        return route;
    }


    }
}