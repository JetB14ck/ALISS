using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class STARSPersonalReportSelectListDTO
    {
        public int srr_id { get; set; }
        public string srr_starsno { get; set; }
        public string srr_hos_code { get; set; }
        public string srr_arh_code { get; set; }
        public DateTime? srr_recvdate { get; set; }
        public string srr_recvuser { get; set; }
        public string srr_name { get; set; }
        public DateTime? srr_testdate { get; set; }
        public string srr_testuser { get; set; }
        public DateTime? srr_approvedate { get; set; }
        public string srr_approveuser { get; set; }
        public DateTime? srr_tatdate { get; set; }
        public string srr_ident_organism { get; set; }
        public string srr_addition_antibiotic { get; set; }
    }

    public class STARSPersonalReportSelectSearchDTO
    {
        public string srr_arh_code { get; set; }
        public string srr_hos_code { get; set; }
        public string srr_starsno { get; set; }
        public DateTime? srr_recvdate { get; set; }
    }   
}
