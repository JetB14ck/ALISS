using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO.UploadAutomate
{
    public class UploadAutomateExportErrorDTO
    {
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
