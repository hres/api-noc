using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IProductRouteRepository
    {
        IEnumerable<ProductRoute> GetAll(string lang);
        ProductRoute Get(int id, string lang);
    }
}
