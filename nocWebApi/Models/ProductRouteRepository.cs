using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class ProductRouteRepository : IProductRouteRepository
    {
       
        private List<ProductRoute> routes = new List<ProductRoute>();
        private ProductRoute route = new ProductRoute();
       


    public IEnumerable<ProductRoute> GetAll(string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            routes = dbConnection.GetAllProductRoute();

        return routes;
    }


    public IEnumerable<ProductRoute> Get(int id, string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            routes = dbConnection.GetProductRouteById(id);
            return routes;
    }


    }
}