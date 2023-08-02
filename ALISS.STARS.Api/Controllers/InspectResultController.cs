using ALISS.STARS.Library;
using ALISS.STARS.Library.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALISS.STARS.DTO.InspectResult;

namespace ALISS.STARS.Api.Controllers
{
    [ApiController]
    public class InspectResultController : ControllerBase
    {
        private readonly IInspectResultDataService _service;

        public InspectResultController(STARSContext db, IMapper mapper)
        {
            _service = new InspectResultDataService(db, mapper);
        }

        [HttpGet]
        [Route("api/InspectResult/Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("api/InspectResult/GetInspectResultListByModel")]
        public IEnumerable<InspectResultDataDTO> Get_InspectResultListByModel([FromBody] InspectResultSearchDTO searchModel)
        {
            var objReturn = _service.GetInspectResultList(searchModel);

            return objReturn;
        }

        [HttpPost]
        [Route("api/InspectResult/Get_InspectStarsResultData")]
        public InspectStarsResultDataDTO Get_InspectStarsResultData([FromBody] InspectResultSearchDTO searchModel)
        {
            var objReturn = _service.GetStarsResultModel(searchModel.search_starsno);

            return objReturn;
        }

        [HttpPost]
        [Route("api/InspectResult/Get_InspectStarsResultAutomateData")]
        public InspectStarsResultAutomateDataDTO Get_InspectStarsResultAutomateData([FromBody] InspectResultSearchDTO searchModel)
        {
            var objReturn = _service.GetStarsResultAutomateModel(searchModel.search_starsno);

            return objReturn;
        }

        [HttpPost]
        [Route("api/InspectResult/Get_InspectStarsResultGeneData")]
        public InspectStarsResultGeneDataDTO Get_InspectStarsResultGeneData([FromBody] InspectResultSearchDTO searchModel)
        {
            var objReturn = _service.GetStarsResultGeneModel(searchModel.search_starsno);

            return objReturn;
        }

        [HttpPost]
        [Route("api/InspectResult/Post_SaveInspectResultData")]
        public InspectResultDataDTO Post_SaveInspectResultData([FromBody] InspectResultDataDTO model)
        {
            var objReturn = _service.SaveInspectResultData(model);

            return objReturn;
        }

        [HttpPost]
        [Route("api/InspectResult/Post_SaveStarsResultData")]
        public InspectStarsResultDataDTO Post_SaveStarsResultData([FromBody] InspectStarsResultDataDTO model)
        {
            var objReturn = _service.SaveStarsResultModel(model);

            return objReturn;
        }

        [HttpPost]
        [Route("api/InspectResult/Post_SaveInspectResultAutomateData")]
        public InspectStarsResultAutomateDataDTO Post_SaveStarsResultAutomateData([FromBody] InspectStarsResultAutomateDataDTO model)
        {
            var objReturn = _service.SaveStarsResultAutomateModel(model);

            return objReturn;
        }

        [HttpPost]
        [Route("api/InspectResult/Post_SaveInspectResultGeneData")]
        public InspectStarsResultGeneDataDTO Post_SaveStarsResultGeneData([FromBody] InspectStarsResultGeneDataDTO model)
        {
            var objReturn = _service.SaveStarsResultGeneModel(model);

            return objReturn;
        }

        [HttpPost]
        [Route("api/InspectResult/Post_SaveStarsResultDataRepeatAutomate")]
        public InspectStarsResultDataDTO Post_SaveStarsResultDataRepeatAutomate([FromBody] InspectResultSearchDTO searchModel)
        {
            var objReturn = _service.SaveStarsResultRepeatAutomateModel(searchModel.search_starsno, searchModel.search_username);

            return objReturn;
        }

    }
}
