using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class RouteRepository : IRouteRepository
    {
       
        private List<Route> routes = new List<Route>();
        private Route route = new Route();
       


    public IEnumerable<Route> GetAll(string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            routes = dbConnection.GetAllRoute();

        return routes;
    }


    public IEnumerable<Route> Get(int id, string lang)
    {
            DBConnection dbConnection = new DBConnection(lang);
            routes = dbConnection.GetRouteById(id);
            return routes;
    }


    }
}