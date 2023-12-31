﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALISS.Mapping.DTO;
using ALISS.Mapping.Library;
using ALISS.Mapping.Library.DataAccess;
using ALISS.STARS.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace ALISS.Mapping.Api.Controllers
{

    public class DataListController : Controller
    {
        private readonly IMappingDataService _service;

        public DataListController(MappingContext db, IMapper mapper)
        {
            _service = new MappingDataService(db, mapper);
        }

        #region Mapping

        [Route("api/Mapping/GetList")]
        [HttpGet]
        public IEnumerable<MappingListsDTO> GetList()
        {
            var objReturn = _service.GetList();
            return objReturn;
        }


        // GET: api/<controller>
        [Route("api/Mapping/GetMappingList/{param}")]
        [HttpGet]
        public IEnumerable<MappingListsDTO> GetMappingList(string param)
        {

            var objReturn = _service.GetMappingList(param);
            return objReturn;
        }

        // GET: api/<controller>
        [Route("api/Mapping/GetMappingDataById/{id}")]
        [HttpGet]
        public MappingDataDTO GetMappingDataById(string id)
        {
            var objReturn = _service.GetMappingDataById(id);
            return objReturn;
        }

        [HttpPost]
        [Route("api/Mapping/Post_SaveMappingData")]
        public MappingDataDTO Post_SaveMappingData([FromBody] MappingDataDTO model)
        {
            var objReturn = _service.SaveMappingData(model);

            return objReturn;
        }

        [HttpPost]
        [Route("api/Mapping/Post_CopyMappingData")]
        public MappingDataDTO Post_CopyMappingData([FromBody] MappingDataDTO model)
        {
            var objReturn = _service.CopyMappingData(model);

            return objReturn;
        }

        [HttpPost]
        [Route("api/Mapping/Get_MappingDataByModel")]
        public MappingDataDTO Get_MappingDataByModel([FromBody] MappingDataDTO model)
        {
            var objReturn = _service.GetMappingDataWithModel(model);

            return objReturn;
        }

        [HttpPost]
        [Route("api/Mapping/Get_chkDuplicateMappingApproved")]
        public MappingDataDTO Get_chkDuplicateMappingApproved([FromBody] MappingDataDTO model)
        {
            var objReturn = _service.chkDuplicateMappingApproved(model);

            return objReturn;
        }


        [HttpPost]
        [Route("api/Mapping/Get_MappingDataActiveWithModel")]
        public MappingDataDTO Get_MappingDataActiveWithModel([FromBody] MappingDataDTO model)
        {
            var objReturn = _service.GetMappingDataActiveWithModel(model);

            return objReturn;
        }
        #endregion


        #region WHONetMapping

        [HttpPost]
        [Route("api/Mapping/Post_SaveWHONetMappingData")]
        public WHONetMappingDataDTO Post_SaveWHONetMappingData([FromBody] WHONetMappingDataDTO model)
        {
            var objReturn = _service.SaveWHONetMappingData(model);

            return objReturn;
        }


        [HttpPost]
        [Route("api/Mapping/Get_WHONetMappingListByModel")]
        public IEnumerable<WHONetMappingListsDTO> Get_WHONetMappingListByModel([FromBody] WHONetMappingSearch searchModel)
        {
            var objReturn = _service.GetWHONetMappingListWithModel(searchModel);

            return objReturn;
        }


        [HttpGet]
        [Route("api/Mapping/Get_WHONetMappingData/{wnm_Id}")]
        public WHONetMappingDataDTO Get_WHONetMappingData(string wnm_Id)
        {
            var objReturn = _service.GetWHONetMappingData(wnm_Id);

            return objReturn;
        }

        [HttpPost]
        [Route("api/Mapping/Get_WHONetMappingDataByModel")]
        public WHONetMappingDataDTO Get_WHONetMappingDataByModel([FromBody] WHONetMappingDataDTO model)
        {
            var objReturn = _service.GetWHONetMappingDataWithModel(model);

            return objReturn;
        }

        #endregion


        #region SpecimenMapping

        [HttpPost]
        [Route("api/Mapping/Post_SaveSpecimenMappingData")]
        public SpecimenMappingDataDTO Post_SaveSpecimenMappingData([FromBody] SpecimenMappingDataDTO model)
        {
            var objReturn = _service.SaveSpecimenMappingData(model);

            return objReturn;
        }


        [HttpPost]
        [Route("api/Mapping/Get_SpecimenMappingListByModel")]
        public IEnumerable<SpecimenMappingListsDTO> Get_SpecimenHONetMappingListByModel([FromBody] SpecimenMappingSearch searchModel)
        {
            var objReturn = _service.GetSpecimenMappingListWithModel(searchModel);

            return objReturn;
        }

        [HttpPost]
        [Route("api/Mapping/Get_SpecimenMappingDataByModel")]
        public SpecimenMappingDataDTO Get_SpecimenMappingDataByModel([FromBody] SpecimenMappingDataDTO model)
        {
            var objReturn = _service.GetSpecimenMappingDataWithModel(model);

            return objReturn;
        }

        [HttpGet]
        [Route("api/Mapping/Get_SpecimenMappingData/{spm_Id}")]
        public SpecimenMappingDataDTO Get_SpecimenMappingData(string spm_Id)
        {
            var objReturn = _service.GetSpecimenMappingData(spm_Id);

            return objReturn;
        }

        #endregion

        #region OrganismMapping
        [HttpPost]
        [Route("api/Mapping/Post_SaveOrganismMappingData")]
        public OrganismMappingDataDTO Post_SaveOrganismMappingData([FromBody] OrganismMappingDataDTO model)
        {
            var objReturn = _service.SaveOrganismMappingData(model);

            return objReturn;
        }


        [HttpPost]
        [Route("api/Mapping/Get_OrganismMappingListByModel")]
        public IEnumerable<OrganismMappingListsDTO> Get_OrganismMappingListByModel([FromBody] OrganismMappingSearch searchModel)
        {
            var objReturn = _service.GetOrganismMappingListWithModel(searchModel);

            return objReturn;
        }

        [HttpPost]
        [Route("api/Mapping/Get_OrganismMappingDataByModel")]
        public OrganismMappingDataDTO Get_OrganismMappingDataByModel([FromBody] OrganismMappingDataDTO model)
        {
            var objReturn = _service.GetOrganismMappingDataWithModel(model);

            return objReturn;
        }


        [HttpGet]
        [Route("api/Mapping/Get_OrganismMappingData/{ogm_Id}")]
        public OrganismMappingDataDTO Get_OrganismMappingData(string ogm_Id)
        {
            var objReturn = _service.GetOrganismMappingData(ogm_Id);

            return objReturn;
        }
        #endregion


        #region WardTypeMapping
        [HttpPost]
        [Route("api/Mapping/Post_SaveWardTypeMappingData")]
        public WardTypeMappingDataDTO Post_SaveWardTypeMappingData([FromBody] WardTypeMappingDataDTO model)
        {
            var objReturn = _service.SaveWardTypeMappingData(model);

            return objReturn;
        }


        [HttpPost]
        [Route("api/Mapping/Get_WardTypeMappingListByModel")]
        public IEnumerable<WardTypeMappingListsDTO> Get_WardTypeMappingListByModel([FromBody] WardTypeMappingSearch searchModel)
        {
            var objReturn = _service.GetWardTypeMappingListWithModel(searchModel);

            return objReturn;
        }


        [HttpPost]
        [Route("api/Mapping/Get_WardTypeMappingDataByModel")]
        public WardTypeMappingDataDTO Get_WardTypeMappingDataByModel([FromBody] WardTypeMappingDataDTO model)
        {
            var objReturn = _service.GetWardTypeMappingDataWithModel(model);

            return objReturn;
        }

        [HttpGet]
        [Route("api/Mapping/Get_WardTypeMappingData/{wdm_Id}")]
        public WardTypeMappingDataDTO Get_WardTypeMappingData(string wdm_Id)
        {
            var objReturn = _service.GetWardTypeMappingData(wdm_Id);

            return objReturn;
        }

        [HttpPost]
        [Route("api/Mapping/Post_SaveTRImportMappingLogData")]
        public TRImportMappingLogDTO Post_SaveTRImportMappingLogData([FromBody] TRImportMappingLogDTO model)
        {
            var objReturn = _service.SaveTRImportMappingLogData(model);

            return objReturn;
        }

        [HttpPost]
        [Route("api/Mapping/Post_SaveTempImportMappingLogData")]
        public List<TempImportMappingLogDTO> Post_SaveTempImportMappingLogData([FromBody] List<TempImportMappingLogDTO> model)
        {
            var objReturn = _service.SaveTempImportMappingLogData(model);

            return objReturn;
        }
        #endregion
    }
}
