using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// 20170119

namespace nocWebApi.Models
{
    public class NoticeOfComplianceMain
    {
        public int noc_number { get; set; }
        public DateTime? noc_date { get; set; }
        public string noc_manufacturer_name { get; set; }
        public string noc_status_with_conditions { get; set; }
        public string noc_on_submission_type { get; set; }
        public string noc_is_suppliment { get; set; }
        public string noc_submission_class { get; set; }
        public string noc_is_admin { get; set; }
        public string noc_product_type { get; set; }
        public string noc_crp_product_name { get; set; }
        public string noc_crp_company_name { get; set; }
        public string noc_crp_country_name { get; set; }
        public string noc_active_status { get; set; }
        public string noc_reason_supplement { get; set; }
        public string noc_reason_submission { get; set; }
        public string noc_therapeutic_class { get; set; }
        public DateTime? noc_last_update_date { get; set; }

    }
}