using System.Collections.Generic;

namespace nocWebApi.Models
{
    interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();
        IEnumerable<Brand> Get(int id);
    }
}
