using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class UploadAutomateErrorDetailListDTO
    {
        public int aed_id { get; set; }
        public int aeh_id { get; set; }
        public string aeh_type { get; set; }
        public string aeh_field { get; set; }
        public string aeh_message { get; set; }
        public string aed_localvalue { get; set; }
        public string aed_localdescr { get; set; }

    }
}
