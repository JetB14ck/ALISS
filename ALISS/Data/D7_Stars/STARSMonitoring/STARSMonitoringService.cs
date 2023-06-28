using ALISS.Data.Client;
using ALISS.STARS.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ALISS.Data.D7_StarsMonitoring
{
    public class STARSMonitoringService
    {
        private IConfiguration Configuration { get; }

        private ApiHelper _apiHelper;
        public STARSMonitoringService(IConfiguration configuration)
        {
            _apiHelper = new ApiHelper(configuration["ApiClient:ApiUrl"]);
        }

        public async Task<List<STARSMonitoringListsDTO>> GetRepeatAutomateListByParamAsync(STARSMonitoringSearchDTO modelSearch)
        {
            List<STARSMonitoringListsDTO> objList = new List<STARSMonitoringListsDTO>();

            var searchJson = JsonSerializer.Serialize(modelSearch);

            objList = await _apiHelper.GetDataListByModelAsync<STARSMonitoringListsDTO, STARSMonitoringSearchDTO>("stars_monitoring/GetSTARSMonitoringDataListByModel", modelSearch);

            return objList;
        }

        public async Task<STARSMonitoringListsDTO> SaveRemarkForRejectSampleAsync(STARSMonitoringListsDTO model)
        {
            STARSMonitoringListsDTO objList = new STARSMonitoringListsDTO();

            objList = await _apiHelper.PostDataAsync<STARSMonitoringListsDTO>("stars_monitoring/Post_SaveRemarkSTARSResultData", model);

            return objList;
        }

        public async void ExportBarcode(IJSRuntime iJSRuntime, STARSMonitoringListsDTO data, string tempPath)
        {
            try
            {
                List<STARSMonitoringListsDTO> datas = new List<STARSMonitoringListsDTO>();
                datas.Add(data);
                var filename = string.Format("STARSBarcode_{0}.pdf", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                var _reportPath = Path.Combine(tempPath, DateTime.Today.ToString("yyyyMMdd"));
                var outputfileInfo = new FileInfo(Path.Combine(_reportPath, filename));
                if (!Directory.Exists(outputfileInfo.DirectoryName))
                    Directory.CreateDirectory(outputfileInfo.DirectoryName);
                var response = await _apiHelper.ExportDataBarcodeAsync<List<STARSMonitoringListsDTO>>("exportstars_api/printBarcode", outputfileInfo, datas);
                if (response == "OK")
                {
                    byte[] fileBytes;
                    using (FileStream fs = outputfileInfo.OpenRead())
                    {
                        fileBytes = new byte[fs.Length];
                        fs.Read(fileBytes, 0, fileBytes.Length);

                        iJSRuntime.InvokeAsync<STARSMonitoringService>(
                            "previewPDF",
                            Convert.ToBase64String(fileBytes)
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<STARSMonitoringDetailDTO> GetRepeatAutomateDetailByParamAsync(string starsno)
        {
            STARSMonitoringDetailDTO obj = new STARSMonitoringDetailDTO();

            obj = await _apiHelper.GetDataByIdAsync<STARSMonitoringDetailDTO>("stars_monitoring/GetSTARSMonitoringDataDetailByParam", starsno);

            return obj;
        }
    }
}
