using ALISS.DropDownList.DTO;
using ALISS.DropDownList.Library;
using ALISS.DropDownList.Library.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALISS.DropDownList.Api.Controllers
{
    public class MachineTypeController : Controller
    {
        private readonly IMachineTypeDataService _service;
        public MachineTypeController(DropDownListContext db, IMapper mapper)
        {
            _service = new MachineTypeDataService(db, mapper);
        }

        [HttpPost]
        [Route("api/DropDownList/GetMachineTypeList/")]
        public List<DropDownListDTO> GetMachineTypeList([FromBody] DropDownListDTO searchModel)
        {
            var objReturn = _service.Get_MachineType_List(searchModel);

            return objReturn;
        }
    }
}
