using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class STARSMonitoringListsDTO
    {
		public int srr_id { get; set; }
		public string srr_starsno { get; set; }
		public DateTime? srr_senddate { get; set; }
		public DateTime? srr_recvdate { get; set; }
		public DateTime? srr_tatdate { get; set; }
		public string srr_reportno { get; set; } 
		public DateTime? srr_reportdate { get; set; }
		public string srr_stars_labno { get; set; }
		public DateTime? srr_stars_specimendate { get; set; }
		public string srr_name { get; set; }
		public string srr_age { get; set; }
		public string srr_sex { get; set; }
		public string srr_stars_orgnaism { get; set; }
		public string srr_stars_specimen { get; set; }
        public string srr_ident_org_code { get; set; }
        public string srr_ident_organism { get; set; }
        public string srr_ident_spec_code { get; set; }
        public string srr_ident_spec_name { get; set; }
        public string srr_status { get; set; }
		public string str_cancelreason { get; set; }
		public string srr_remark { get; set; }
		public string srr_hos_code { get; set; }
		public string srr_arh_code { get; set; }
        public int? srp_id { get; set; }
        public string srr_senddate_str
        {
            get
            {
                return (srr_senddate != null) ? srr_senddate.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string srr_stars_specimendate_str
        {
            get
            {
                return (srr_stars_specimendate != null) ? srr_stars_specimendate.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string srr_recvdate_str
        {
            get
            {
                return (srr_recvdate != null) ? srr_recvdate.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string srr_tatdate_str
        {
            get
            {
                return (srr_tatdate != null) ? srr_tatdate.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string srr_reportdate_str
        {
            get
            {
                return (srr_reportdate != null) ? srr_reportdate.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string srr_status_str
        {
            get
            {
                string objReturn = "";

                if (srr_status == "N") objReturn = "New";
                else if (srr_status == "W") objReturn = "Wait-Inspect";
                else if (srr_status == "G") objReturn = "Transporting";
                else if (srr_status == "V") objReturn = "Received";
                else if (srr_status == "A") objReturn = "Lab Processing";
                else if (srr_status == "R") objReturn = "Received";
                else if (srr_status == "C") objReturn = "Complete";
                else if (srr_status == "J") objReturn = "Reject Sample";
                else if (srr_status == "T") objReturn = "Repeat Automate";

                return objReturn;
            }
        }   
    
    }
    public class STARSMonitoringSearchDTO
    {
        public string arh_code { get; set; }
        public string hos_code { get; set; }
        public string stars_no { get; set; }
        public DateTime? recvdate_start { get; set; }
        public DateTime? recvdatet_end { get; set; }
        public DateTime? tatdate_start { get; set; }
        public DateTime? tatdatet_end { get; set; }
        public string status { get; set; }
        public string recvdate_start_date_str
        {
            get
            {
                return (recvdate_start != null) ? recvdate_start.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "";
            }
        }
        public string tatdatet_end_date_str
        {
            get
            {
                return (recvdatet_end != null) ? recvdatet_end.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "";
            }
        }
        public string tatdate_start_date_str
        {
            get
            {
                return (tatdate_start != null) ? tatdate_start.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "";
            }
        }
        public string recvdatet_end_date_str
        {
            get
            {
                return (tatdatet_end != null) ? tatdatet_end.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "";
            }
        }
    }
}
