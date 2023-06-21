using System;

namespace ALISS.MasterManagement.Library.Models
{
    public class TCSTARSAutomateColumn
    {
        public int stc_id { get; set; }
        public string stc_code { get; set; }
        public string stc_name { get; set; }
        public string stc_data_type { get; set; }
        public string stc_date_format { get; set; }
        public bool stc_mendatory { get; set; }
        public bool stc_encrypt { get; set; }
        public string stc_status { get; set; }
        public bool stc_active { get; set; }
        public string stc_createuser { get; set; }
        public DateTime? stc_createdate { get; set; }
        public string stc_updateuser { get; set; }
        public DateTime? stc_updatedate { get; set; }
    }
}
