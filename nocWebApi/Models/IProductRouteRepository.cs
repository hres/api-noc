using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IProductRouteRepository
    {
        IEnumerable<ProductRoute> GetAll();
        ProductRoute Get(int id);
    }
}
