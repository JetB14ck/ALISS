using ALISS.STARS.DTO.NarstService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.Library
{
    public interface INarstServService
    {
        List<NarstServiceDTO> GetInterpretResultInfos(string startdate, string enddate);
        List<NarstServiceDTO> GetInterpretResultInfo(string param);
    }
}
