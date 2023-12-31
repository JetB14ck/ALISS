﻿using ALISS.Data.Client;
using ALISS.Master.DTO;
using ALISS.MasterManagement.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ALISS.Data.D7_StarsMapping.MasterManagement
{
    public class StarsWHONETColumnService
    {
        private IConfiguration Configuration { get; }

        private ApiHelper _apiHelper;

        public StarsWHONETColumnService(IConfiguration configuration)
        {
            _apiHelper = new ApiHelper(configuration["ApiClient:ApiUrl"]);
        }

        //public async Task<List<WHONETColumnDTO>> GetListAsync()
        //{
        //    List<WHONETColumnDTO> objList = new List<WHONETColumnDTO>();

        //    objList = await _apiHelper.GetDataListAsync<WHONETColumnDTO>("whonetcolumn_api/Get_List");

        //    return objList;
        //}

        //public async Task<List<WHONETColumnDTO>> GetListByParamAsync(WHONETColumnDTO searchData)
        //{
        //    List<WHONETColumnDTO> objList = new List<WHONETColumnDTO>();

        //    var searchJson = JsonSerializer.Serialize(searchData);

        //    objList = await _apiHelper.GetDataListByParamsAsync<WHONETColumnDTO>("whonetcolumn_api/Get_List", searchJson);

        //    return objList;
        //}

        //public async Task<List<WHONETColumnDTO>> GetListByModelAsync(WHONETColumnDTO searchData)
        //{
        //    List<WHONETColumnDTO> objList = new List<WHONETColumnDTO>();

        //    objList = await _apiHelper.GetDataListByModelAsync<WHONETColumnDTO, WHONETColumnDTO>("whonetcolumn_api/Get_ListByModel", searchData);

        //    return objList;
        //}

        public async Task<List<STARSAutomateColumnDTO>> GetListByModelActiveAsync(STARSAutomateColumnDTO searchData)
        {
            List<STARSAutomateColumnDTO> objList = new List<STARSAutomateColumnDTO>();

            objList = await _apiHelper.GetDataListByModelAsync<STARSAutomateColumnDTO, STARSAutomateColumnDTO>("starcolumn_api/Get_ColumnList_Active_ByModel", searchData);

            return objList;
        }
        public async Task<List<TCSTARS_AntibioticsDTO>> GetDataList_TCWHONET_Antibiotics_Async(TCSTARS_AntibioticsDTO searchData)
        {
            List<TCSTARS_AntibioticsDTO> objList = new List<TCSTARS_AntibioticsDTO>();

            objList = await _apiHelper.GetDataListByModelAsync<TCSTARS_AntibioticsDTO, TCSTARS_AntibioticsDTO>("starcolumn_api/Get_AntibioticsList_Active_ByModel", searchData);

            return objList;
        }
        public async Task<List<TCSTARSOrganismDTO>> GetListTCSTARS_Organism_Async(TCSTARSOrganismDTO searchData)
        {
            List<TCSTARSOrganismDTO> objList = new List<TCSTARSOrganismDTO>();

            objList = await _apiHelper.GetDataListByModelAsync<TCSTARSOrganismDTO, TCSTARSOrganismDTO>("starcolumn_api/Get_OrganismList_Active_WithModel", searchData);

            return objList;
        }
        public async Task<List<TCSTARSGeneDTO>> GetListTCSTARS_Gene_Async(TCSTARSGeneDTO searchData)
        {
            List<TCSTARSGeneDTO> objList = new List<TCSTARSGeneDTO>();

            objList = await _apiHelper.GetDataListByModelAsync<TCSTARSGeneDTO, TCSTARSGeneDTO>("starcolumn_api/Get_GeneList_Active_WithModel", searchData);

            return objList;
        }

        //public async Task<WHONETColumnDTO> GetDataAsync(string mst_code)
        //{
        //    WHONETColumnDTO menu = new WHONETColumnDTO();

        //    menu = await _apiHelper.GetDataByIdAsync<WHONETColumnDTO>("whonetcolumn_api/Get_Data", mst_code);

        //    return menu;
        //}

        //public async Task<WHONETColumnDTO> SaveDataAsync(WHONETColumnDTO model)
        //{
        //    //MenuDTO menu = new MenuDTO()
        //    //{
        //    //    mnu_id = "2",
        //    //    mnu_name = "TEST_name",
        //    //    mnu_area = "TEST_area",
        //    //    mnu_controller = "TEST_controller"
        //    //};

        //    var menua = await _apiHelper.PostDataAsync<WHONETColumnDTO>("whonetcolumn_api/Post_SaveData", model);

        //    return menua;
        //}

        //public async Task<List<LogProcessDTO>> GetHistoryAsync(LogProcessSearchDTO searchData)
        //{
        //    List<LogProcessDTO> objList = new List<LogProcessDTO>();

        //    var searchJson = JsonSerializer.Serialize(searchData);

        //    objList = await _apiHelper.GetDataListByParamsAsync<LogProcessDTO>("logprocess_api/Get_List", searchJson);

        //    return objList;
        //}

        public Task<GridData[]> GetHistoryAsync()
        {
            var rng = new Random();
            var objReturn = new List<GridData>(){
                new GridData { Column_01 = "(A0000)Super admin", Column_02 = "Active role", Column_03 = "Lorem", Column_04 = "00/00/00 00:00", Column_05 = "" },
                new GridData { Column_01 = "(A0000)Super admin", Column_02 = "Inactive role", Column_03 = "Lorem", Column_04 = "00/00/00 00:00", Column_05 = "" },
            };
            return Task.FromResult(objReturn.ToArray());
        }
    }
}
