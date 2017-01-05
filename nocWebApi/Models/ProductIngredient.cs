using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nocWebApi.Models
{
    public class ProductIngredient
    {
        public int noc_number { get; set; }
        public int noc_pi_din_product_id { get; set; }
        public string noc_pi_medic_ingr_name { get; set; }
        public int noc_pi_strength { get; set; }
        public string noc_pi_unit { get; set; }
        public string noc_pi_basic_unit { get; set; }
        public string noc_pi_base { get; set; }
    }
}