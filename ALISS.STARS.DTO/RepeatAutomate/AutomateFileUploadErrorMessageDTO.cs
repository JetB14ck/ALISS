using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO.RepeatAutomate
{
    public class AutomateFileUploadErrorMessageDTO
    {
        public char afu_status { get; set; }
        public char afu_Err_type { get; set; }
        public int afu_Err_no { get; set; }
        public string afu_Err_Column { get; set; }
        public string afu_Err_Message { get; set; }
    }
}
