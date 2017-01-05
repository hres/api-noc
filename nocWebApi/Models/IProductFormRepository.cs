using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IProductFormRepository
    {
        IEnumerable<ProductForm> GetAll(string lang);
        ProductForm Get(int id, string lang);
    }
}
