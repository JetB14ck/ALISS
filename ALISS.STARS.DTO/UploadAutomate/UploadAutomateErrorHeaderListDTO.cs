using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class UploadAutomateErrorHeaderListDTO
    {
        public Guid aeh_id { get; set; }
        public string aeh_type { get; set; }
        public string aeh_field { get; set; }
        public string aeh_message { get; set; }
        public int aeh_errorrecord { get; set; }
    }
}
