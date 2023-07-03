using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ALISS.STARS.DTO
{
    public class MonthlyGeneReportSearchDTO
    {
        public string hos_code { get; set; }
        public string prv_code { get; set; }
        public string arh_code { get; set; }
        public int from_month { get; set; }
        public int to_month { get; set; }
        public int year_code { get; set; }
        public string stars_org_code { get; set; }
        public string spec_code { get; set; }
        public string ward_type { get; set; }
    }
}
