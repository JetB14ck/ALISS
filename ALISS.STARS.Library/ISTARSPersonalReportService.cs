using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ALISS.STARS.DTO;

namespace ALISS.STARS.Library
{
    public interface ISTARSPersonalReportService
    {
        List<STARSPersonalReportListDTO> GetSTARSPersonalReportListByModel(STARSPersonalReportSearchDTO model);
        STARSPersonalReportDataDTO GetSTARSPersonalReportDataById(string srp_id);
        STARSPersonalReportExportDTO Get_STARSPersonalReportExportDataById(string srp_id);
        STARSPersonalReportDataModelDTO SaveSTARSPersonalReportData(STARSPersonalReportDataModelDTO model, string format);

        List<STARSPersonalReportSelectListDTO> GetSTARSPersonalReportSelectListByModel(STARSPersonalReportSelectSearchDTO model);
        List<STARSAntibioticListDTO> Get_STARSAntibioticListByModel(STARSAntibioticSearchDTO model);
        STARSPersonalReportDataDTO CancelSTARSPersonalReportData(string id, string user);
        StarsAutomateResultDTO Get_StarsAutomateResultDataAsync(string stars_no);
    }
}
