using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALISS.STARS.Report
{
    public class MonthlyGeneReportListDTO
    {
        public int month_code { get; set; }
        public string month_name { get; set; }
        public string gene_name { get; set; }
        public double value { get; set; }
    }

    public class MonthlyReportDataDTO
    {
        public string reportTitle { get; set; }
        public string hos_code { get; set; }
        public string year_code { get; set; }
        public List<MonthlyGeneReportListDTO> reportListDTOs { get; set; }
    }
}