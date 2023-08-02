using ALISS.Data.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using ALISS.STARS.DTO;
using Microsoft.JSInterop;
using System.IO;
using ALISS.DropDownList.DTO;
using ExcelDataReader;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using SQLitePCL;
using Microsoft.Data.Sqlite;
using ALISS.Helpers;
using DbfDataReader;
using System.Globalization;
using ALISS.STARS.DTO.InspectResult;

namespace ALISS.Data.D7_StarsRepeat
{
    public class InspectResultService
    {
        private IConfiguration Configuration { get; }

        private ApiHelper _apiHelper;
        public InspectResultService(IConfiguration configuration)
        {
            _apiHelper = new ApiHelper(configuration["ApiClient:ApiUrl"]);
        }

        #region Inspect Result
        public async Task<List<InspectResultDataDTO>> GetInspectResultListByParamAsync(InspectResultSearchDTO modelSearch)
        {
            List<InspectResultDataDTO> objList = new List<InspectResultDataDTO>();

            var searchJson = JsonSerializer.Serialize(modelSearch);

            objList = await _apiHelper.GetDataListByModelAsync<InspectResultDataDTO, InspectResultSearchDTO>("inspect_result_api/GetInspectResultListByModel", modelSearch);

            return objList;
        }

        public async Task<InspectStarsResultDataDTO> Get_InspectStarsResultModelByParamAsync(InspectResultSearchDTO modelSearch)
        {
            InspectStarsResultDataDTO objModel = new InspectStarsResultDataDTO();

            var searchJson = JsonSerializer.Serialize(modelSearch);

            objModel = await _apiHelper.GetDataByModelAsync<InspectStarsResultDataDTO, InspectResultSearchDTO>("inspect_result_api/Get_InspectStarsResultData", modelSearch);

            return objModel;
        }

        public async Task<InspectStarsResultAutomateDataDTO> Get_InspectStarsResultAutomateModelByParamAsync(InspectResultSearchDTO modelSearch)
        {
            InspectStarsResultAutomateDataDTO objModel = new InspectStarsResultAutomateDataDTO();

            var searchJson = JsonSerializer.Serialize(modelSearch);

            objModel = await _apiHelper.GetDataByModelAsync<InspectStarsResultAutomateDataDTO, InspectResultSearchDTO>("inspect_result_api/Get_InspectStarsResultAutomateData", modelSearch);

            return objModel;
        }

        public async Task<InspectStarsResultGeneDataDTO> Get_InspectStarsResultGeneModelByParamAsync(InspectResultSearchDTO modelSearch)
        {
            InspectStarsResultGeneDataDTO objModel = new InspectStarsResultGeneDataDTO();

            var searchJson = JsonSerializer.Serialize(modelSearch);

            objModel = await _apiHelper.GetDataByModelAsync<InspectStarsResultGeneDataDTO, InspectResultSearchDTO>("inspect_result_api/Get_InspectStarsResultGeneData", modelSearch);

            return objModel;
        }

        public async Task<InspectStarsResultDataDTO> Save_InspectStarsResultModelAsync(InspectStarsResultDataDTO dataModel)
        {
            InspectStarsResultDataDTO objModel = new InspectStarsResultDataDTO();

            //var dataModelJson = JsonSerializer.Serialize(dataModel);
           
            //objModel = await _apiHelper.PostDataAsync<InspectStarsResultDataDTO>("inspect_result_api/Post_SaveInspectResultData", dataModel);
            objModel = await _apiHelper.PostDataAsync<InspectStarsResultDataDTO>("inspect_result_api/Post_SaveStarsResultData", dataModel);
            return objModel;
        }

        public async Task<InspectStarsResultGeneDataDTO> Save_InspectStarsResultGeneModelAsync(InspectStarsResultGeneDataDTO dataModel)
        {
            InspectStarsResultGeneDataDTO objModel = new InspectStarsResultGeneDataDTO();

            //var dataModelJson = JsonSerializer.Serialize(dataModel);

            objModel = await _apiHelper.PostDataAsync<InspectStarsResultGeneDataDTO>("inspect_result_api/Post_SaveInspectResultGeneData", dataModel);

            return objModel;
        }

        public async Task<InspectStarsResultAutomateDataDTO> Save_InspectStarsResultAutomateModelAsync(InspectStarsResultAutomateDataDTO dataModel)
        {
            InspectStarsResultAutomateDataDTO objModel = new InspectStarsResultAutomateDataDTO();

            //var dataModelJson = JsonSerializer.Serialize(dataModel);

            objModel = await _apiHelper.PostDataAsync<InspectStarsResultAutomateDataDTO>("inspect_result_api/Post_SaveInspectResultAutomateData", dataModel);

            return objModel;
        }

        public async Task<InspectStarsResultDataDTO> Save_InspectStarsResultRepeatAutomateModelAsync(InspectResultSearchDTO dataModel)
        {
            InspectStarsResultDataDTO objModel = new InspectStarsResultDataDTO();

            //var dataModelJson = JsonSerializer.Serialize(dataModel);

            objModel = await _apiHelper.GetDataByModelAsync<InspectStarsResultDataDTO, InspectResultSearchDTO>("inspect_result_api/Post_SaveStarsResultDataRepeatAutomate", dataModel);

            return objModel;
        }

        #endregion
    }
}
