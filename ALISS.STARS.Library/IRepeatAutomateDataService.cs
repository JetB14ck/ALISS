using ALISS.STARS.DTO.RepeatAutomate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.Library
{
    public interface IRepeatAutomateDataService
    {
        List<RepeatAutomateDataDTO> GetRepeatAutomateList(RepeatAutomateSearchDTO searchModel);
        RepeatAutomateDataDTO SaveRepeatFileUploadData(RepeatAutomateDataDTO model);
    }
}
