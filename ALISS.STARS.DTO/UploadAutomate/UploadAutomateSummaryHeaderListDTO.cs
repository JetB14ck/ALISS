using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class UploadAutomateSummaryHeaderListDTO
    {
        public Guid ash_id { get; set; }
        public Guid ash_lfu_id { get; set; }
        public string ash_code { get; set; }
        public string ash_desc { get; set; }
        public int ash_total { get; set; }
        public List<UploadAutomateSummaryDetailListDTO> UploadAutomateSummaryDetailLists { get; set; }
    }
}
