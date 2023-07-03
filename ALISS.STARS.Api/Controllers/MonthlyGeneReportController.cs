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
    public class MonthlyGeneReportController : Controller
    {
        private readonly IMonthlyGeneReportService _service;

        public MonthlyGeneReportController(STARSContext db, IMapper mapper)
        {
            _service = new MonthlyGeneReportService(db, mapper);
        }

        [HttpPost]
        [Route("api/MonthlyGeneReport/Get_MonthlyGeneReportListWithModel")]
        public IEnumerable<MonthlyGeneReportDataDTO> Get_MonthlyGeneReportListWithModel([FromBody] MonthlyGeneReportSearchDTO searchModel)
        {
            var objReturn = _service.GetMonthlyGeneReportListWithModel(searchModel);

            return objReturn;
        }
    }
}