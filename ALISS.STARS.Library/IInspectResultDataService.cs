using ALISS.STARS.DTO.InspectResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.Library
{
    public interface IInspectResultDataService
    {
        List<InspectResultDataDTO> GetInspectResultList(InspectResultSearchDTO searchModel);
        InspectResultDataDTO SaveInspectResultData(InspectResultDataDTO model);
        InspectStarsResultDataDTO GetStarsResultModel(string search_starno);
        InspectStarsResultAutomateDataDTO GetStarsResultAutomateModel(string search_starno);
        InspectStarsResultGeneDataDTO GetStarsResultGeneModel(string search_starno);
        InspectStarsResultDataDTO SaveStarsResultModel(InspectStarsResultDataDTO model);
        InspectStarsResultAutomateDataDTO SaveStarsResultAutomateModel(InspectStarsResultAutomateDataDTO model);
        InspectStarsResultGeneDataDTO SaveStarsResultGeneModel(InspectStarsResultGeneDataDTO model);
        InspectStarsResultDataDTO SaveStarsResultRepeatAutomateModel(string search_starno, string username);
    }
}
