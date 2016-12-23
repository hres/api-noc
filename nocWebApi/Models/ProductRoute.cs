using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nocWebApi.Models
{
    public class ProductRoute
    {
        public int noc_number { get; set; }
        public int noc_pr_din_product_id { get; set; }
        public string noc_pr_route_eng_desc { get; set; }
        public string noc_pr_route_fr_desc { get; set; }

    }
}