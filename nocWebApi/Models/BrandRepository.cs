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


    public Brand Get(int id)
    {
        brand = dbConnection.GetBrandById(id);
        return brand;
    }


    }
}