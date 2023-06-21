using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.MasterManagement.DTO
{
    public class TCSTARS_AntibioticsDTO
    {
        public int sta_ant_id { get; set; }
        public string sta_ant_source { get; set; }
        public string sta_ant_code { get; set; }
        public string sta_ant_name { get; set; }
        public string sta_ant_type { get; set; }
        public string sta_ant_lab { get; set; }
        public string sta_ant_labtype { get; set; }
        public string sta_ant_size { get; set; }
        public string sta_ant_S { get; set; }
        public string sta_ant_I { get; set; }
        public string sta_ant_R { get; set; }
        public string sta_ant_status { get; set; }
        public bool sta_ant_active { get; set; }
        public string sta_ant_createuser { get; set; }
        public DateTime? sta_ant_createdate { get; set; }
        public string sta_ant_updateuser { get; set; }
        public DateTime? sta_ant_updatedate { get; set; }
    }
}
