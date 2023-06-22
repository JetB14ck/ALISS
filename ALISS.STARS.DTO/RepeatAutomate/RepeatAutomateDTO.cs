using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ALISS.STARS.DTO.RepeatAutomate
{
    public class RepeatAutomateDataDTO
    {
        public int afu_id { get; set; }
        public string afu_arh_code { get; set; }
        public string afu_machinetype { get; set; }
        public string afu_filename { get; set; }
        public string afu_path { get; set; }
        public int afu_totalrecord { get; set; }
        public int afu_errorrecord { get; set; }
        public int afu_repeat_automaterecord { get; set; }
        public int afu_repeat_generecord { get; set; }
        public int afu_wait_approverecord { get; set; }
        public int afu_approverecord { get; set; }
        public Guid afu_smp_id { get; set; }
        public string afu_status { get; set; }
        public bool afu_repeat_flag { get; set; }
        public string afu_repeatuser { get; set; }
        public DateTime? afu_repeatdate { get; set; }
        public string afu_createuser { get; set; }
        public DateTime? afu_createdate { get; set; }
        public string afu_updateuser { get; set; }
        public DateTime? afu_updatedate { get; set; }

        public string srr_starsno { get; set; }
        public string srr_starsno_ref { get; set; }
        public string afu_repeatdate_str
        {
            get
            {
                return afu_repeatdate != null ? afu_repeatdate.Value.ToString("dd/MM/yyyy") : "";
            }
        }
        public DateTime? srr_tatdate { get; set; }
        public string srr_tatdate_str
        {
            get
            {
                return srr_tatdate != null ? srr_tatdate.Value.ToString("dd/MM/yyyy") : "";
            }
        }
        public string susp_organism { get; set; }
        public string susp_spec_type { get; set; }
        public string srr_ident_organism { get; set; }
        public string method_ident { get; set; }
        public string afu_status_str
        {
            get
            {
                string objReturn = "";
                if (afu_status == "N") objReturn = "New";
                else if (afu_status == "W") objReturn = "Wait-Inspect";
                else if (afu_status == "P") objReturn = "Processing";
                else if (afu_status == "R") objReturn = "Repeat Automate";
                else if (afu_status == "C") objReturn = "Cancel";
                return objReturn;
            }
        }
    }
    public class RepeatAutomateSearchDTO
    {
        public string arh_code { get; set; }
        public DateTime? repeat_start_date { get; set; }
        public DateTime? repeat_end_date { get; set; }
        public string repeat_startdate_str
        {
            get
            {
                return repeat_start_date != null ? repeat_start_date.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "";
            }
        }
        public string repeat_enddate_str
        {
            get
            {
                return repeat_end_date != null ? repeat_end_date.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "";
            }
        }
        public DateTime? testing_start_date { get; set; }
        public DateTime? testing_end_date { get; set; }
        public string testing_startdate_str
        {
            get
            {
                return testing_start_date != null ? testing_start_date.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "";
            }
        }
        public string testing_enddate_str
        {
            get
            {
                return testing_end_date != null ? testing_end_date.Value.ToString("yyyy/MM/dd", new CultureInfo("en-US")) : "";
            }
        }
        public string repeat_status { get; set; }

    }
}
