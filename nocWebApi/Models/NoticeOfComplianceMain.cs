﻿using System;
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
        public string noc_submission_number { get; set; }
        public string noc_manufacturer_name { get; set; }
        public string noc_status_with_conditions { get; set; }
        public string noc_qn_fname { get; set; }
        public string noc_dhcpl_fname { get; set; }
        public string noc_factsheet_fname { get; set; }
        public string noc_on_submission_type { get; set; }
        public string noc_is_suppliment { get; set; }
        public string noc_submission_class { get; set; }
        public string noc_is_admin { get; set; }
        public string noc_product_type { get; set; }
        public string noc_file_number { get; set; }
        public string noc_crp_product_name { get; set; }
        public string noc_crp_company_name { get; set; }
        public string noc_crp_country_name { get; set; }
        public string noc_active_status { get; set; }
        public string noc_scanned_page { get; set; }
        public string noc_reason_supplement { get; set; }
        public string noc_reason_submission { get; set; }
        public string noc_therapeutic_class { get; set; }
        public string noc_notes { get; set; }
        public DateTime? noc_notes_entry_date { get; set; }
        public DateTime? noc_last_update_date { get; set; }
        public DateTime? noc_entry_date { get; set; }
        public string noc_sbd_fname { get; set; }
        public string noc_nd_fname { get; set; }
        public string noc_ci_part_iii_fname { get; set; }
        public string noc_pm_fname { get; set; }

    }
}