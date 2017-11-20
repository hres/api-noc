using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Linq;

namespace nocWebApi.Controllers
{
    public class RouteController : ApiController
    {
        static readonly IRouteRepository databasePlaceholder = new RouteRepository();

        public IEnumerable<Route> GetAllRoute(string lang = "en")
        {

            return databasePlaceholder.GetAll(lang);
        }


        public IEnumerable<Route> GetRouteById(int id, string lang="en")
        {
            IEnumerable<Route> routeList = databasePlaceholder.Get(id, lang);
            //if (routeList.Count() == 0)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return routeList;
        }
    }
}
