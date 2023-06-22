using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class STARSPersonalReportExportDTO
    {
        public int? srp_id { get; set; }
        public string arh_name { get; set; }
        public string arh_address { get; set; }
        public string arh_telephone { get; set; }
        public string arh_certificate { get; set; }
        public string srp_reportno { get; set; }
        public DateTime? srr_senddate { get; set; }
        public DateTime? srr_recvdate { get; set; }
        public string hos_name { get; set; }
        public string hos_address { get; set; }
        public string srp_starsno { get; set; }
        public string srr_ident_spec_name { get; set; }
        public string srr_name { get; set; }
        public string srr_age { get; set; }
        public string srr_stars_labno { get; set; }
        public string srr_ident_organism { get; set; }
        public string stars_automate_result { get; set; }
        public string srp_testing_user { get; set; }
        public string srp_approve_user { get; set; }
        public DateTime? srr_testdate { get; set; }
        public DateTime? srr_approvedate { get; set; }
        public DateTime? srr_reportdate { get; set; }
        public string srp_director_path { get; set; }
        public string srp_director_name { get; set; }
        public string srp_director_position { get; set; }
        public string srp_director_position2 { get; set; }
        public string srp_remarks { get; set; }

        public string srr_senddate_str
        {
            get
            {
                return (srr_senddate != null) ? srr_senddate.Value.ToString("dd/MM/yyyy") : "";
            }
        }


        public string srr_recvdate_str
        {
            get
            {
                return (srr_recvdate != null) ? srr_recvdate.Value.ToString("dd/MM/yyyy") : "";
            }
        }


        public string srr_testdate_str
        {
            get
            {
                return (srr_testdate != null) ? srr_testdate.Value.ToString("dd/MM/yyyy") : "";
            }
        }


        public string srr_approvedate_str
        {
            get
            {
                return (srr_approvedate != null) ? srr_approvedate.Value.ToString("dd/MM/yyyy") : "";
            }
        }


        public string srr_reportdate_str
        {
            get
            {
                return (srr_reportdate != null) ? srr_reportdate.Value.ToString("dd/MM/yyyy") : "";
            }
        }

    }

    public class StarsAutomateResultDTO
    {
        public string stars_automate_result { get; set; }
    }
}
