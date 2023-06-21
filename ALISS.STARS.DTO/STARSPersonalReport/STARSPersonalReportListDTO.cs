using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class STARSPersonalReportListDTO
    {
        public int srp_id { get; set; }
        public string srr_reportno { get; set; }
        public DateTime? srr_reportdate { get; set; }
        public string srr_starsno { get; set; }
        public DateTime? srr_tatdate { get; set; }
        public DateTime? srr_testdate { get; set; }
        public DateTime? srr_approvedate { get; set; }
        public string srr_testuser { get; set; }
        public string srr_approveuser { get; set; }
        public string srp_status { get; set; }
        public string srr_reportuser { get; set; }

        public string srp_status_str
        {
            get
            {
                string objReturn = "";

                if (srp_status == "D") objReturn = "Draft";
                else if (srp_status == "A") objReturn = "Complete";
                else if (srp_status == "C") objReturn = "Cancel";

                return objReturn;
            }
        }
    }

    public class ddl_status_model
    {
        public string code { get; set; }
        public string text { get; set; }
    }
}
