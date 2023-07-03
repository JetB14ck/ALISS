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
using ALISS.STARS.Report;

namespace ALISS.Data.D8_StarsReport
{
    public class MonthlyGeneReportService
    {
        private IConfiguration Configuration { get; }

        private ApiHelper _apiHelper;

        public MonthlyGeneReportService(IConfiguration configuration)
        {
            _apiHelper = new ApiHelper(configuration["ApiClient:ApiUrl"]);
        }

        public async Task<List<MonthlyGeneReportDataDTO>> getMonthlyGeneReportData(MonthlyGeneReportSearchDTO model)
        {
            List<MonthlyGeneReportDataDTO> objList = new List<MonthlyGeneReportDataDTO>();
            objList = await _apiHelper.GetDataListByModelAsync<MonthlyGeneReportDataDTO, MonthlyGeneReportSearchDTO>("gene_report_api/Get_MonthlyGeneReportListWithModel", model);
            return objList;
        }

        public async void ExportGraph(IJSRuntime iJSRuntime, MonthlyReportDataDTO data, string tempPath,string hos_code)
        {
            try
            {
                var filename = string.Format("MonthlyGeneReport_{0}_{1}.pdf", hos_code, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                var _reportPath = Path.Combine(tempPath, DateTime.Today.ToString("yyyyMMdd"));
                var outputfileInfo = new FileInfo(Path.Combine(_reportPath, filename));
                if (!Directory.Exists(outputfileInfo.DirectoryName))
                    Directory.CreateDirectory(outputfileInfo.DirectoryName);
                var response = await _apiHelper.ExportDataBarcodeAsync<MonthlyReportDataDTO>("exportstars_api/printMonthlyGeneReport", outputfileInfo, data);
                if (response == "OK")
                {
                    byte[] fileBytes;
                    using (FileStream fs = outputfileInfo.OpenRead())
                    {
                        fileBytes = new byte[fs.Length];
                        fs.Read(fileBytes, 0, fileBytes.Length);

                        iJSRuntime.InvokeAsync<MonthlyGeneReportService>(
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
    }
}

