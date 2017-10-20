using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IProductFormRepository
    {
        IEnumerable<ProductForm> GetAll(string lang);
        IEnumerable<ProductForm> Get(int id, string lang);
    }
}
