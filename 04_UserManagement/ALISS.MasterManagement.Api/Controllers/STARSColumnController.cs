using ALISS.MasterManagement.DTO;
using ALISS.MasterManagement.Library;
using ALISS.MasterManagement.Library.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALISS.MasterManagement.Api.Controllers
{
    public class STARSColumnController : Controller
    {
        private readonly ISTARSAutomateColumnService _service;
        public STARSColumnController(MasterManagementContext db, IMapper mapper)
        {
            _service = new STARSAutomateService(db, mapper);
        }

        [HttpGet]
        [Route("api/STARSColumn/Get_List")]
        public IEnumerable<STARSAutomateColumnDTO> Get_List()
        {
            var objReturn = _service.GetList();

            return objReturn;
        }

        [HttpPost]
        [Route("api/STARSColumn/Get_ColumnList_Active_ByModel")]
        public IEnumerable<STARSAutomateColumnDTO> GeColumntList_Active_WithModel([FromBody] STARSAutomateColumnDTO searchModel)
        {
            var objReturn = _service.GeColumntList_Active_WithModel(searchModel);

            return objReturn;
        }

        [HttpPost]
        [Route("api/STARSColumn/Get_AntibioticsList_Active_ByModel")]
        public IEnumerable<TCSTARS_AntibioticsDTO> GetAntibioticList_Active_WithModel([FromBody] TCSTARS_AntibioticsDTO searchModel)
        {
            var objReturn = _service.GetAntibioticList_Active_WithModel(searchModel);

            return objReturn;
        }
    }
}
