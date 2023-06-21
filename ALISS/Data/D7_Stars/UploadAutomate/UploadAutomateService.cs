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
    public class UploadAutomateService
    {
        private IConfiguration Configuration { get; }

        private ApiHelper _apiHelper;

        public UploadAutomateService(IConfiguration configuration)
        {
            _apiHelper = new ApiHelper(configuration["ApiClient:ApiUrl"]);
        }

        public async Task<List<UploadAutomateDataDTO>> GetUploadAutomateListByModelAsync(UploadAutomateSearchDTO model)
        {
            List<UploadAutomateDataDTO> objList = new List<UploadAutomateDataDTO>();
            objList = await _apiHelper.GetDataListByModelAsync<UploadAutomateDataDTO, UploadAutomateSearchDTO>("upload_automate_api/Get_UploadAutomateListByModel", model);
            return objList;
        }


        public async Task<UploadAutomateDataDTO> GetUploadAutomateDataAsync(string afu_id)
        {
            UploadAutomateDataDTO UploadAutomate = new UploadAutomateDataDTO();

            UploadAutomate = await _apiHelper.GetDataByIdAsync<UploadAutomateDataDTO>("upload_automate_api/GetUploadAutomateDataById", afu_id);

            return UploadAutomate;
        }

        public async Task<UploadAutomateDataDTO> SaveUploadAutomateDataAsync(UploadAutomateDataDTO model)
        {
            if (model.afu_id.Equals(Guid.Empty))
            {
                model.afu_status = "N";
            }

            var UploadAutomate = await _apiHelper.PostDataAsync<UploadAutomateDataDTO>("upload_automate_api/Post_SaveUploadAutomateData", model);

            return UploadAutomate;
        }

        public async Task<List<UploadAutomateSummaryHeaderListDTO>> GetUploadAutomateSummaryHeaderListAsync(string afu_Id)
        {
            List<UploadAutomateSummaryHeaderListDTO> objList = new List<UploadAutomateSummaryHeaderListDTO>();

            objList = await _apiHelper.GetDataListByParamsAsync<UploadAutomateSummaryHeaderListDTO>("upload_automate_api/GetUploadAutomateSummaryHeaderByAfuId", afu_Id);

            return objList;
        }

        public async Task<List<UploadAutomateSummaryDetailListDTO>> GetUploadAutomateSummaryDetailListAsync(string fsh_id)
        {
            List<UploadAutomateSummaryDetailListDTO> objList = new List<UploadAutomateSummaryDetailListDTO>();

            objList = await _apiHelper.GetDataListByParamsAsync<UploadAutomateSummaryDetailListDTO>("upload_automate_api/GetUploadAutomateSummaryDetailByAfuId", fsh_id);

            return objList;
        }
        public async Task<List<UploadAutomateSummaryDetailListDTO>> GetUploadAutomateSummaryDetailListByAfuIdAsync(string afu_id)
        {
            List<UploadAutomateSummaryDetailListDTO> objList = new List<UploadAutomateSummaryDetailListDTO>();

            objList = await _apiHelper.GetDataListByParamsAsync<UploadAutomateSummaryDetailListDTO>("upload_automate_api/GetUploadAutomateSummaryDetailListByAfuIdAsync", afu_id);

            return objList;
        }

        public async Task<List<UploadAutomateErrorHeaderListDTO>> GetUploadAutomateErrorHeaderListAsync(string afu_Id)
        {
            List<UploadAutomateErrorHeaderListDTO> objList = new List<UploadAutomateErrorHeaderListDTO>();

            objList = await _apiHelper.GetDataListByParamsAsync<UploadAutomateErrorHeaderListDTO>("upload_automate_api/GetUploadAutomateErrorHeaderByAfuId", afu_Id);

            return objList;
        }

        public async Task<List<UploadAutomateErrorDetailListDTO>> GetUploadAutomateErrorDetailListAsync(string afu_Id)
        {
            List<UploadAutomateErrorDetailListDTO> objList = new List<UploadAutomateErrorDetailListDTO>();

            objList = await _apiHelper.GetDataListByParamsAsync<UploadAutomateErrorDetailListDTO>("upload_automate_api/GetUploadAutomateErrorDetailByAfuId", afu_Id);

            return objList;
        }


        public void GenerateExportSummary(IJSRuntime iJSRuntime, List<UploadAutomateSummaryHeaderListDTO> UploadAutomateSummaryHeaderList,
            List<UploadAutomateErrorDetailListDTO> UploadAutomateErrorDetailList,
            string UploadAutomateName)
        {
            byte[] fileContents;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Summary");
                var workSheet2 = package.Workbook.Worksheets.Add("Error");
                var workSheet3 = package.Workbook.Worksheets.Add("LabAlertSummary");
                #region Hearder Row
                workSheet.Cells[1, 1].Value = "Specimen";
                workSheet.Cells[1, 2].Value = "Organism";
                workSheet.Cells[1, 3].Value = "Total";
                #endregion

                int row = 2;
                foreach (UploadAutomateSummaryHeaderListDTO item in UploadAutomateSummaryHeaderList)
                {
                    workSheet.Cells[row, 1].Value = item.ash_code + " - " + item.ash_desc;
                    workSheet.Cells[row, 3].Value = item.ash_total; ;
                    row++;
                    var detail = item.UploadAutomateSummaryDetailLists;

                    if (detail != null)
                    {
                        foreach (UploadAutomateSummaryDetailListDTO d in detail)
                        {
                            workSheet.Cells[row, 2].Value = d.asd_organismcode + " - " + d.asd_organismdesc;
                            workSheet.Cells[row, 3].Value = d.asd_total;

                            row++;
                        }
                    }

                }


                workSheet2.Cells[1, 1].Value = "Message";
                workSheet2.Cells[1, 2].Value = "Local Value";
                workSheet2.Cells[1, 3].Value = "Local Description";


                row = 2;

                foreach (UploadAutomateErrorDetailListDTO err in UploadAutomateErrorDetailList)
                {
                    workSheet2.Cells[row, 1].Value = err.aeh_message;
                    workSheet2.Cells[row, 2].Value = err.aed_localvalue;
                    if (!string.IsNullOrEmpty(err.aed_localdescr))
                    {
                        workSheet2.Cells[row, 3].Value = err.aed_localdescr;
                    }
                    row++;
                }


                workSheet3.Cells[1, 1].Value = "ROW_IDX";
                workSheet3.Cells[1, 2].Value = "ALERT_NUM";
                workSheet3.Cells[1, 3].Value = "ALERT_ORG";
                workSheet3.Cells[1, 4].Value = "ALERT_TEXT";
                workSheet3.Cells[1, 5].Value = "ALERT_TOT";
                workSheet3.Cells[1, 6].Value = "PIORITY";
                workSheet3.Cells[1, 7].Value = "QUAL_CONT";
                workSheet3.Cells[1, 8].Value = "IMP_SPECIE";
                workSheet3.Cells[1, 9].Value = "IMP_RESIST";
                workSheet3.Cells[1, 10].Value = "SAVE_ISOL";
                workSheet3.Cells[1, 11].Value = "SEND_REF";
                workSheet3.Cells[1, 12].Value = "INF_CONT";
                workSheet3.Cells[1, 13].Value = "RX_COMMENT";
                workSheet3.Cells[1, 14].Value = "OTHER_AL";


                row = 2;

                //workSheet3.PrinterSettings.FitToPage = true;
                //workSheet3.PrinterSettings.FitToWidth = 1;
                //workSheet3.PrinterSettings.FitToHeight = 1;
                fileContents = package.GetAsByteArray();
            }

            try
            {
                iJSRuntime.InvokeAsync<UploadAutomateService>(
                    "saveAsFile",
                    string.Format("{0}.xlsx", "Summary"),
                    Convert.ToBase64String(fileContents)
                    );

            }
            catch (Exception ex)
            {

            }
        }
    }
}

