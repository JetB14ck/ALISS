using ALISS.MasterManagement.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.MasterManagement.Library
{
    public interface ISTARSAutomateColumnService
    {
        List<STARSAutomateColumnDTO> GetList();
        List<STARSAutomateColumnDTO> GeColumntList_Active_WithModel(STARSAutomateColumnDTO searchModel);
        List<TCSTARS_AntibioticsDTO> GetAntibioticList_Active_WithModel(TCSTARS_AntibioticsDTO searchModel);

    }
}
