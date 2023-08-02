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
                    case "RP": objReturn = "ReProcess"; break;
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

    public class UploadAutomateLogDTO
    {
        public int iml_id { get; set; }
        public DateTime iml_import_date { get; set; }
        public string iml_filename { get; set; }
        public int iml_total_record { get; set; }
        public int iml_who_record { get; set; }
        public string iml_status { get; set; }
        public string iml_createduser { get; set; }
        public DateTime iml_createdate { get; set; }
    }

    public class UploadAutomateLogErrorMessageDTO
    {
        public char afu_status { get; set; }
        public char afu_Err_type { get; set; }
        public int afu_Err_no { get; set; }
        public string afu_Err_Column { get; set; }
        public string afu_Err_Message { get; set; }
    }

    public class TempImportUploadAutomateLogDTO
    {
        public int tae_id { get; set; }
        public string afu_arh_code { get; set; } // เขตสุขภาพ
        public string afu_machinetype { get; set; } // เครื่องจักร
        public string afu_filename { get; set; } // File Name
        public string aeh_field { get; set; } // Field
        public string aed_localvalue { get; set; } // Field Value
        public string aed_localdescr { get; set; } // Field Descr
        public string data_code { get; set; }
        public string data_desc { get; set; }
        public int afu_id { get; set; } // hide in excel
        public Guid afu_smp_id { get; set; } // hide in excel
    }
}
