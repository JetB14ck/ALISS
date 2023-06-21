using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALISS.STARS.DTO;
using ALISS.STARS.Library;
using ALISS.STARS.Library.DataAccess;
using AutoMapper;


namespace ALISS.UploadAutomate.Api.Controllers
{
    public class UploadAutomateController : Controller
    {
        private readonly IUploadAutomateService _service;

        public UploadAutomateController(STARSContext db, IMapper mapper)
        {
            _service = new UploadAutomateService(db, mapper);
        }

        [Route("api/UploadAutomate/GetUploadAutomateDataById/{id}")]
        [HttpGet]
        public UploadAutomateDataDTO GetUploadAutomateDataById(int id)
        {
            var objReturn = _service.GetUploadAutomateDataById(id);
            return objReturn;
        }


        [HttpPost]
        [Route("api/UploadAutomate/Post_SaveUploadAutomateData")]
        public UploadAutomateDataDTO Post_SaveUploadAutomateData([FromBody] UploadAutomateDataDTO model)
        {
            var objReturn = _service.SaveUploadAutomateData(model);

            return objReturn;
        }

        [HttpPost]
        [Route("api/UploadAutomate/Get_UploadAutomateListByModel")]
        public IEnumerable<UploadAutomateDataDTO> Get_UploadAutomateListByModel([FromBody] UploadAutomateSearchDTO searchModel)
        {
            var objReturn = _service.GetUploadAutomateListWithModel(searchModel);

            return objReturn;
        }

        [Route("api/UploadAutomate/GetUploadAutomateSummaryHeaderByAfuId/{param}")]
        [HttpGet]
        public IEnumerable<UploadAutomateSummaryHeaderListDTO> GetUploadAutomateSummaryHeaderByAfuId(string param)
        {

            var objReturn = _service.GetUploadAutomateSummaryHeaderByAfuId(param);
            return objReturn;
        }

        [Route("api/UploadAutomate/GetUploadAutomateSummaryDetailByAfuId/{param}")]
        [HttpGet]
        public IEnumerable<UploadAutomateSummaryDetailListDTO> GetUploadAutomateSummaryDetailByAfuId(string param)
        {

            var objReturn = _service.GetUploadAutomateSummaryDetailByAfuId(param);
            return objReturn;
        }

        [Route("api/UploadAutomate/GetUploadAutomateSummaryDetailListByAfuIdAsync/{param}")]
        [HttpGet]
        public IEnumerable<UploadAutomateSummaryDetailListDTO> GetUploadAutomateSummaryDetailListByAfuIdAsync(string param)
        {

            var objReturn = _service.GetUploadAutomateSummaryDetailListByAfuId(param);
            return objReturn;
        }

        [Route("api/UploadAutomate/GetUploadAutomateErrorHeaderByAfuId/{param}")]
        [HttpGet]
        public IEnumerable<UploadAutomateErrorHeaderListDTO> GetUploadAutomateErrorHeaderByAfuId(string param)
        {

            var objReturn = _service.GetUploadAutomateErrorHeaderListByAfuId(param);
            return objReturn;
        }

        [Route("api/UploadAutomate/GetUploadAutomateErrorDetailByAfuId/{param}")]
        [HttpGet]
        public IEnumerable<UploadAutomateErrorDetailListDTO> GetUploadAutomateErrordetailByAfuId(string param)
        {

            var objReturn = _service.GetUploadAutomateErrorDetailListByAfuId(param);
            return objReturn;
        }

    }
}