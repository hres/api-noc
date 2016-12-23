using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
    }
}
