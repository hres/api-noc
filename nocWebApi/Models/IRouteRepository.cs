using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IRouteRepository
    {
        IEnumerable<Route> GetAll(string lang="");
        IEnumerable<Route> Get(int id, string lang="");
    }
}
