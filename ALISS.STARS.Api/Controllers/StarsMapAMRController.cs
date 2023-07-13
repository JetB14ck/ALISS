using ALISS.STARS.DTO.STARSMapGene;
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
    public class StarsMapAMRController : Controller
    {
        private readonly IStarsAMRMapService _service;

        public StarsMapAMRController(STARSContext db, IMapper mapper)
        {
            _service = new StarsAMRMapService(db, mapper);
        }

        [HttpPost]
        [Route("api/StarsMapAMR/GetStarsAMRMapGeneDataWithModel")]
        public IEnumerable<StarsAMRMapGeneDataDTO> GetStarsAMRMapGeneDataWithModel([FromBody] StarsAMRMapGeneSearchDTO searchModel)
        {
            var objReturn = _service.GetStarsAMRMapGeneDataWithModel(searchModel);

            return objReturn;
        }

        [HttpPost]
        [Route("api/StarsMapAMR/GetStarAMRMapHosOrganismDataWithModel")]
        public IEnumerable<StarsAMRMapGeneDataDTO> GetStarsAMRMapOrganismWithModel([FromBody] StarAMRMapHosOrganismSelectDTO searchModel)
        {
            var objReturn = _service.GetStarsAMRMapOrganismWithModel(searchModel);

            return objReturn;
        }
    }
}
