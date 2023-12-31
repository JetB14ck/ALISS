﻿using ALISS.STARS.DTO.NarstService;
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
    public class NarstServiceController : Controller
    {
        private readonly NarstServService _service;

        public NarstServiceController(STARSContext db, IMapper mapper)
        {
            _service = new NarstServService(db, mapper);
        }

        [Route("api/NARST_Service/GetInterpretResultInfo/{param}")]
        [HttpGet]
        public IEnumerable<NarstServiceDTO> GetInterpretResultInfo(string param)
        {

            var objReturn = _service.GetInterpretResultInfo(param);
            return objReturn;
        }
    }
}
