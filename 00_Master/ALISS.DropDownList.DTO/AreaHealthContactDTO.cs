using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.DropDownList.DTO
{
    public class TCAreaHealthContact
    {
        public int arc_id { get; set; }
        public string arc_arh_code { get; set; }
        public string arc_testuser { get; set; }
        public string arc_approveuser { get; set; }
        public string arc_directoruser { get; set; }
        public string arc_directorsign_path { get; set; }
        public string arc_directorposition_1 { get; set; }
        public string arc_directorposition_2 { get; set; }
        public string arc_status { get; set; }
        public string arc_createuser { get; set; }
        public DateTime? arc_createdate { get; set; }
        public string arc_updateuser { get; set; }
        public DateTime? arc_updatedate { get; set; }
        public string arh_name { get; set; }
    }
}
