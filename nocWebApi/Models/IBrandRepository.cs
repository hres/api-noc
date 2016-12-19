using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();
        Brand Get(int id);
    }
}
