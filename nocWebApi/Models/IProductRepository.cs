using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> Get(int id);
    }
}
