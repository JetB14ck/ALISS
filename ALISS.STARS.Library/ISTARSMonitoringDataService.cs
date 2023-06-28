using ALISS.STARS.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.Library
{
    public interface ISTARSMonitoringDataService
    {
        List<STARSMonitoringListsDTO> GetSTARSMonitoringDataList(STARSMonitoringSearchDTO searchModel);
        STARSMonitoringListsDTO SaveTRSTARSResultData(STARSMonitoringListsDTO model);
        STARSMonitoringDetailDTO GetSTARSMonitoringDataDetailByParam(string starsno);
    }
}
