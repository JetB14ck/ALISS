using ALISS.STARS.Library;
using ALISS.STARS.Library.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALISS.STARS.DTO.RepeatAutomate;

namespace ALISS.STARS.Api.Controllers
{
    [ApiController]
    public class RepeatAutomateController : ControllerBase
    {
        private readonly IRepeatAutomateDataService _service;

        public RepeatAutomateController(STARSContext db, IMapper mapper)
        {
            _service = new RepeatAutomateDataService(db, mapper);
        }

        [HttpGet]
        [Route("api/RepeatAutomate/Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("api/RepeatAutomate/GetRepeatAutomateListByModel")]
        public IEnumerable<RepeatAutomateDataDTO> Get_LabFileUploadListByModel([FromBody] RepeatAutomateSearchDTO searchModel)
        {
            var objReturn = _service.GetRepeatAutomateList(searchModel);

            return objReturn;
        }

        [HttpPost]
        [Route("api/RepeatAutomate/Post_SaveRepeatFileUploadData")]
        public RepeatAutomateDataDTO Post_SaveRepeatFileUploadData([FromBody] RepeatAutomateDataDTO model)
        {
            var objReturn = _service.SaveRepeatFileUploadData(model);

            return objReturn;
        }

    }
}
