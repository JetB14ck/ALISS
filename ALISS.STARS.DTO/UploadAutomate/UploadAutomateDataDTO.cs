using ALISS.STARS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ALISS.STARS.DTO
{
    public class UploadAutomateDataDTO
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
        public bool? afu_repeat_flag { get; set; }
        public string afu_repeatuser { get; set; }
        public DateTime? afu_repeatdate { get; set; }
        public string afu_createuser { get; set; }
        public DateTime? afu_createdate { get; set; }
        public string afu_updateuser { get; set; }
        public DateTime? afu_updatedate { get; set; }
        public string arh_name { get; set; }
        public string afu_status_str
        {
            get
            {
                string objReturn = "";

                switch (afu_status)
                {
                    case "N": objReturn = "New"; break;
                    case "W": objReturn = "Wait Inspect"; break;
                    case "I": objReturn = "Wait Approve"; break;
                    case "R": objReturn = "Repeat"; break;
                    case "A": objReturn = "Approve"; break;
                    default: objReturn = ""; break;
                }

                return objReturn;
            }
        }
    }

    public class UploadAutomateSearchDTO
    {
        public int afu_id { get; set; }
        public string afu_Area { get; set; }
        public string afu_machinetype { get; set; }
    }
   
}
