﻿using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace nocWebApi.Controllers
{
    public class ProductRouteController : ApiController
    {
        static readonly IProductRouteRepository databasePlaceholder = new ProductRouteRepository();

        public IEnumerable<ProductRoute> GetAllProductRoute(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ProductRoute GetProductRouteById(int id, string lang)
        {
            ProductRoute route = databasePlaceholder.Get(id, lang);
            if (route == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return route;
        }
    }
}
