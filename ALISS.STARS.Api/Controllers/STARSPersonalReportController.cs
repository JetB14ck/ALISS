using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALISS.STARS.DTO;
using ALISS.STARS.Library;
using ALISS.STARS.Library.DataAccess;
using AutoMapper;


namespace ALISS.STARSPersonalReport.Api.Controllers
{
    public class STARSPersonalReportController : Controller
    {
        private readonly ISTARSPersonalReportService _service;

        public STARSPersonalReportController(STARSContext db, IMapper mapper)
        {
            _service = new STARSPersonalReportService(db, mapper);
        }

        [HttpPost]
        [Route("api/STARSPersonalReport/Get_STARSPersonalReportListByModel")]
        public IEnumerable<STARSPersonalReportListDTO> Get_STARSPersonalReportListByModel([FromBody] STARSPersonalReportSearchDTO searchModel)
        {
            var objReturn = _service.GetSTARSPersonalReportListByModel(searchModel);

            return objReturn;
        }

        [Route("api/STARSPersonalReport/Get_STARSPersonalReportDataById/{id}")]
        [HttpGet]
        public STARSPersonalReportDataDTO GetSTARSPersonalReportDataById(string id)
        {
            var objReturn = _service.GetSTARSPersonalReportDataById(id);
            return objReturn;
        }

        [Route("api/STARSPersonalReport/Get_STARSPersonalReportExportDataById/{id}")]
        [HttpGet]
        public STARSPersonalReportExportDTO Get_STARSPersonalReportExportDataById(string id)
        {
            var objReturn = _service.Get_STARSPersonalReportExportDataById(id);
            return objReturn;
        }

        [Route("api/STARSPersonalReport/Get_StarsAutomateResultDataAsync/{stars_no}")]
        [HttpGet]
        public StarsAutomateResultDTO Get_StarsAutomateResultDataAsync(string stars_no)
        {
            var objReturn = _service.Get_StarsAutomateResultDataAsync(stars_no);
            return objReturn;
        }

        [HttpPost]
        [Route("api/STARSPersonalReport/Post_SaveSTARSPersonalReportData/{format}")]
        public STARSPersonalReportDataModelDTO Post_SaveSTARSPersonalReportData(string format, [FromBody] STARSPersonalReportDataModelDTO model)
        {
            var objReturn = _service.SaveSTARSPersonalReportData(model, format);

            return objReturn;
        }

        [HttpPost]
        [Route("api/STARSPersonalReport/Get_STARSPersonalReportSelectListByModel")]
        public IEnumerable<STARSPersonalReportSelectListDTO> Get_STARSPersonalReportSelectListByModel([FromBody] STARSPersonalReportSelectSearchDTO searchModel)
        {
            var objReturn = _service.GetSTARSPersonalReportSelectListByModel(searchModel);

            return objReturn;
        }

        [HttpPost]
        [Route("api/STARSPersonalReport/Get_STARSAntibioticListByModel")]
        public IEnumerable<STARSAntibioticListDTO> Get_STARSAntibioticListByModel([FromBody] STARSAntibioticSearchDTO searchModel)
        {
            var objReturn = _service.Get_STARSAntibioticListByModel(searchModel);

            return objReturn;
        }

        [HttpPost]
        [Route("api/STARSPersonalReport/Cancel_STARSPersonalReportData/{id}/{user}")]
        public STARSPersonalReportDataDTO Cancel_STARSPersonalReportData(string id, string user)
        {
            var objReturn = _service.CancelSTARSPersonalReportData(id, user);

            return objReturn;
        }
    }
}