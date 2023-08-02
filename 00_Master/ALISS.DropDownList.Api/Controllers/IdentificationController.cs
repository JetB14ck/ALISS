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
    public class IdentificationController : Controller
    {
        private readonly IIdentificationDataService _service;
        public IdentificationController(DropDownListContext db, IMapper mapper)
        {
            _service = new IdentificationDataService(db, mapper);
        }

        [HttpPost]
        [Route("api/DropDownList/GetIdentificationList/")]
        public List<DropDownListDTO> GetIdentificationList([FromBody] DropDownListDTO searchModel)
        {
            var objReturn = _service.Get_Identification_List(searchModel);

            return objReturn;
        }
    }
}
