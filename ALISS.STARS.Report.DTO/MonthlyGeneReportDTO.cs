using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALISS.STARS.Report
{
    public class MonthlyGeneReportListDTO
    {
        public string month_code { get; set; }
        public string month_name { get; set; }
        public double vana { get; set; }
        public double vanb { get; set; }
        public double vanc1 { get; set; }
        public double vanc2c3 { get; set; }
        public double vand { get; set; }
        public double meca { get; set; }
        public double mecb { get; set; }
        public double mecc { get; set; }
        public double mcr1 { get; set; }
        public double mcr2 { get; set; }
        public double mcr3 { get; set; }
        public double mcr4 { get; set; }
        public double mcr5 { get; set; }
        public double mcr6 { get; set; }
        public double mcr7 { get; set; }
        public double mcr8 { get; set; }
        public double mcr9 { get; set; }
        public double mcr10 { get; set; }
        public double imp { get; set; }
        public double vim { get; set; }
        public double oxa { get; set; }
        public double ndm { get; set; }
        public double kpc { get; set; }
        public double ctxm { get; set; }
        public double tem { get; set; }
        public double shv { get; set; }
        public double serotype { get; set; }
        public double serogroup { get; set; }
    }

    public class MonthlyReportDataDTO
    {
        public string reportTitle { get; set; }
        public string hos_code { get; set; }
        public List<MonthlyGeneReportListDTO> reportListDTOs { get; set; }
    }
}