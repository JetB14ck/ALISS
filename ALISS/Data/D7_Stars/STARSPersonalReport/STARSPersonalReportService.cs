using ALISS.Data.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALISS.STARS.DTO;
using Microsoft.JSInterop;
using OfficeOpenXml;
using System.IO;
using ALISS.UserManagement.DTO;
using ALISS.STARS.Report.DTO;
using Log4NetLibrary;

namespace ALISS.Data.D7_StarsMapping
{
    public class STARSPersonalReportService
    {
        private IConfiguration Configuration { get; }

        private ApiHelper _apiHelper;

        public STARSPersonalReportService(IConfiguration configuration)
        {
            _apiHelper = new ApiHelper(configuration["ApiClient:ApiUrl"]);
        }

        public async Task<List<STARSPersonalReportListDTO>> GetSTARSPersonalReportListByModelAsync(STARSPersonalReportSearchDTO model)
        {
            List<STARSPersonalReportListDTO> objList = new List<STARSPersonalReportListDTO>();
            objList = await _apiHelper.GetDataListByModelAsync<STARSPersonalReportListDTO, STARSPersonalReportSearchDTO>("personal_report_api/Get_STARSPersonalReportListByModel", model);
            return objList;
        }

        public async Task<STARSPersonalReportDataDTO> GetStarsPersonalReportDataAsync(string srp_id)
        {
            STARSPersonalReportDataDTO data = new STARSPersonalReportDataDTO();

            data = await _apiHelper.GetDataByIdAsync<STARSPersonalReportDataDTO>("personal_report_api/Get_STARSPersonalReportDataById", srp_id);

            return data;
        }

        public async Task<STARSPersonalReportDataModelDTO> SaveStarsPersonalReportDataAsync(STARSPersonalReportDataModelDTO model, string format)
        {
            var mapping = await _apiHelper.PostDataAsync<STARSPersonalReportDataModelDTO>("personal_report_api/Post_SaveSTARSPersonalReportData/"+format, model);

            return mapping;
        }

        public async Task<STARSPersonalReportDataDTO> CancelStarsPersonalReportDataAsync(string id, string user)
        {
            var mapping = await _apiHelper.PostDataAsync<STARSPersonalReportDataDTO>(string.Format("personal_report_api/Cancel_STARSPersonalReportData/{0}/{1}", id, user), new STARSPersonalReportDataDTO());

            return mapping;
        }

        #region Modal 

        public async Task<List<STARSPersonalReportSelectListDTO>> GetSTARSPersonalReportSelectListByModelAsync(STARSPersonalReportSelectSearchDTO model)
        {
            List<STARSPersonalReportSelectListDTO> objList = new List<STARSPersonalReportSelectListDTO>();
            objList = await _apiHelper.GetDataListByModelAsync<STARSPersonalReportSelectListDTO, STARSPersonalReportSelectSearchDTO>("personal_report_api/Get_STARSPersonalReportSelectListByModel", model);
            return objList;
        }

        public async Task<List<STARSAntibioticListDTO>> GetSTARSAntibioticListByModelAsync(STARSAntibioticSearchDTO model)
        {
            List<STARSAntibioticListDTO> objList = new List<STARSAntibioticListDTO>();
            objList = await _apiHelper.GetDataListByModelAsync<STARSAntibioticListDTO, STARSAntibioticSearchDTO>("personal_report_api/Get_STARSAntibioticListByModel", model);
            return objList;
        }

        #endregion

        #region Report
        public async Task<STARSPersonalReportExportDTO> GetStarsPersonalExportDataAsync(string srp_id)
        {
            STARSPersonalReportExportDTO data = new STARSPersonalReportExportDTO();

            data = await _apiHelper.GetDataByIdAsync<STARSPersonalReportExportDTO>("personal_report_api/Get_STARSPersonalReportExportDataById", srp_id);

            return data;
        }
        public async Task<StarsAutomateResultDTO> GetStarsAutomateResultDataAsync(string stars_no)
        {
            StarsAutomateResultDTO data = new StarsAutomateResultDTO();

            data = await _apiHelper.GetDataByIdAsync<StarsAutomateResultDTO>("personal_report_api/Get_StarsAutomateResultDataAsync", stars_no);

            return data;
        }

        public async void PreviewReport(IJSRuntime iJSRuntime, STARSPersonalReportExportDTO reportData, string tempPath)
        {
            try
            {
                var filename = string.Format("STARSPersonalReport_{0}.pdf", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                var _reportPath = Path.Combine(tempPath, DateTime.Today.ToString("yyyyMMdd"));
                var outputfileInfo = new FileInfo(Path.Combine(_reportPath, filename));
                if (!Directory.Exists(outputfileInfo.DirectoryName))
                    Directory.CreateDirectory(outputfileInfo.DirectoryName);
                var response = await _apiHelper.ExportDataBarcodeAsync<STARSPersonalReportExportDTO>("exportstars_api/PreviewReport", outputfileInfo, reportData);
                if (response == "OK")
                {
                    byte[] fileBytes;
                    using (FileStream fs = outputfileInfo.OpenRead())
                    {
                        fileBytes = new byte[fs.Length];
                        fs.Read(fileBytes, 0, fileBytes.Length);

                        iJSRuntime.InvokeAsync<ReceiveSampleService>(
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
        #endregion
    }
}

