using ALISS.STARS.DTO;
using ALISS.STARS.Library;
using ALISS.STARS.Library.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALISS.STARS.Api.Controllers
{
    public class STARSMonitoringController : ControllerBase
    {
        private readonly ISTARSMonitoringDataService _service;
        public STARSMonitoringController(STARSContext db, IMapper mapper)
        {
            _service = new STARSMonitoringDataService(db, mapper);
        }

        [HttpGet]
        [Route("api/STARSMonitoring/Get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("api/STARSMonitoring/GetSTARSMonitoringDataListByModel")]
        public IEnumerable<STARSMonitoringListsDTO> GetSTARSMonitoringDataList([FromBody] STARSMonitoringSearchDTO searchModel)
        {
            var objReturn = _service.GetSTARSMonitoringDataList(searchModel);

            return objReturn;
        }

        [HttpPost]
        [Route("api/STARSMonitoring/Post_SaveRemarkSTARSResultData")]
        public STARSMonitoringListsDTO Post_SaveRemarkSTARSResultData([FromBody] STARSMonitoringListsDTO model)
        {
            var objReturn = _service.SaveTRSTARSResultData(model);

            return objReturn;
        }

        [HttpGet]
        [Route("api/STARSMonitoring/GetSTARSMonitoringDataDetailByParam/{starsno}")]
        public STARSMonitoringDetailDTO GetSTARSMonitoringDataDetailByParam(string starsno)
        {
            var objReturn = _service.GetSTARSMonitoringDataDetailByParam(starsno);

            return objReturn;
        }
    }
}
