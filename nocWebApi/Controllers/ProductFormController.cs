﻿using nocWebApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace nocWebApi.Controllers
{
    public class ProductFormController : ApiController
    {
        static readonly IProductFormRepository databasePlaceholder = new ProductFormRepository();

        public IEnumerable<ProductForm> GetAllProductForm(string lang)
        {

            return databasePlaceholder.GetAll(lang);
        }


        public ProductForm GetProductFormByID(int id, string lang)
        {
            ProductForm form = databasePlaceholder.Get(id, lang);
            if (form == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return form;
        }
    }
}
