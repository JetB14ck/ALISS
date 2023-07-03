using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ALISS.STARS.DTO;

namespace ALISS.STARS.Library
{
    public interface IMonthlyGeneReportService
    {
        List<MonthlyGeneReportDataDTO> GetMonthlyGeneReportListWithModel(MonthlyGeneReportSearchDTO model);
    }
}
