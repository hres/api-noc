using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IProductFormRepository
    {
        IEnumerable<ProductForm> GetAll();
        ProductForm Get(int id);
    }
}
