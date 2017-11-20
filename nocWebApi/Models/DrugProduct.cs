using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nocWebApi.Models
{
    public class DrugProduct
    {
        public int noc_number { get; set; }
        public int noc_br_brand_id { get; set; }
        public string noc_br_brandname { get; set; }
        public string noc_br_din { get; set; }
        public int noc_br_product_id { get; set; }


    }
}