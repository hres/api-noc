using notice;
using System.Collections.Generic;

namespace nocWebApi.Models
{
    public class BrandRepository : IBrandRepository
    {
       
        private List<Brand> brands = new List<Brand>();
        private Brand brand = new Brand();
        DBConnection dbConnection = new DBConnection("en");


    public IEnumerable<Brand> GetAll()
    {
        brands = dbConnection.GetAllBrand();

        return brands;
    }


    public IEnumerable<Brand> Get(int id)
    {
        brands = dbConnection.GetBrandById(id);
        return brands;
    }


    }
}