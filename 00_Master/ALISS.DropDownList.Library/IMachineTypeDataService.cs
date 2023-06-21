using ALISS.DropDownList.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.DropDownList.Library
{
    public interface IMachineTypeDataService
    {
        List<DropDownListDTO> Get_MachineType_List(DropDownListDTO searchModel);
    }
}
