using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class UploadAutomateSummaryDetailListDTO
    {
        public Guid fsh_id { get; set; }
        public Guid asd_id { get; set; }
        public string asd_organismcode { get; set; }
        public string asd_organismdesc { get; set; }
        public int asd_total { get; set; }
        public UploadAutomateSummaryHeaderListDTO UploadAutomateSummaryHeaderList { get; set; }

    }
}
