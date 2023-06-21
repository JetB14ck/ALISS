using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class STARSPersonalReportSearchDTO
    {
        public int srp_id { get; set; }
        public string srr_boxno { get; set; }
        public string srr_arh_code { get; set; }
        public DateTime? srr_reportdate_from { get; set; }
        public DateTime? srr_reportdate_to { get; set; }
        public string srr_hos_code { get; set; }
        public DateTime? srr_approvedate_from { get; set; }
        public DateTime? srr_approvedate_to { get; set; }
        public string srr_starsno { get; set; }
        public DateTime? srr_testdate_from { get; set; }
        public DateTime? srr_testdate_to { get; set; }
        public string srr_reportno { get; set; }
        public string srr_status { get; set; }
    }
}
