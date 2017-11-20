using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nocWebApi.Models
{
    public class DosageForm
    {
        public int noc_number { get; set; }
        public int noc_pf_din_product_id { get; set; }
        public string noc_pf_form_name { get; set; }
    }
}