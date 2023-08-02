using ALISS.DropDownList.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.DropDownList.Library
{
    public interface IIdentificationDataService
    {
        List<DropDownListDTO> Get_Identification_List(DropDownListDTO searchModel);
    }
}
