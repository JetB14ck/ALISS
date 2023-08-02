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
using ALISS.STARS.DTO.UploadAutomate;
using ALISS.STARS.DTO.RepeatAutomate;
using ALISS.DropDownList.DTO;
using ALISS.Mapping.DTO;
using ALISS.Helpers;
using System.Data;
using ExcelDataReader;
using Newtonsoft.Json;

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

        public async void GenerateExportError(IJSRuntime iJSRuntime, string[] afu_ids, string fileName)
        {
            byte[] fileContents;

            List<UploadAutomateExportErrorDTO> objList = new List<UploadAutomateExportErrorDTO>();

            objList = await _apiHelper.PostDataByListAsync<List<UploadAutomateExportErrorDTO>>("upload_automate_api/GetUploadAutomateExportError", afu_ids);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                int row_no = 2;
                var workSheet = package.Workbook.Worksheets.Add("ExportError");

                #region Hearder Row
                string[] headers = new string[] { "เขตสุขภาพ", "เครื่องจักร", "File Name", "Field", "Field Value", "Field Descr", "Data Code", "Data Desc", "afu_id", "afu_smp_id"};
                foreach (var (header, i) in headers.Select((value, i) => (value, i)))
                {
                    workSheet.Cells[1, i + 1].Value = header;
                }
                #endregion

                #region Data Row
                foreach (var row in objList)
                {
                    int col = 0;
                    foreach (var prop in row.GetType().GetProperties())
                    {
                        workSheet.Cells[row_no, col + 1].Value = prop.GetValue(row, null);
                        col++;
                    }

                    row_no++;
                }
                #endregion

                #region workSheet Properties
                workSheet.Row(1).Style.Font.Bold = true;

                workSheet.Column(1).Width = 16;
                workSheet.Column(2).Width = 36;
                workSheet.Column(3).Width = 11;
                workSheet.Column(4).Width = 11;
                workSheet.Column(5).Width = 11;
                workSheet.Column(6).Width = 36;
                workSheet.Column(7).Width = 36;
                workSheet.Column(8).Width = 36;
                workSheet.Column(9).Hidden = true;
                workSheet.Column(10).Hidden = true;
                #endregion

                //var filecont1 = package.GetAsByteArray();
                fileContents = package.GetAsByteArray();
            }

            try
            {
                iJSRuntime.InvokeAsync<UploadAutomateService>(
                    "saveAsFile",
                    string.Format("{0}.xlsx", fileName),
                    Convert.ToBase64String(fileContents)
                    );

            }
            catch (Exception ex)
            {

            }
        }

        public async Task<string> GetPath()
        {
            var ErrorMessage = new List<UploadAutomateLogErrorMessageDTO>();

            string path = "";
            List<ParameterDTO> objParamList = new List<ParameterDTO>();
            var searchModel = new ParameterDTO() { prm_code_major = "AUTOMATE_MAPPING_ERROR_PATH" };

            objParamList = await _apiHelper.GetDataListByModelAsync<ParameterDTO, ParameterDTO>("dropdownlist_api/GetParameterList", searchModel);

            if (objParamList.FirstOrDefault(x => x.prm_code_minor == "PATH") != null)
            {
                path = objParamList.FirstOrDefault(x => x.prm_code_minor == "PATH").prm_value;
            }
            return path;
        }

        public async Task<List<UploadAutomateLogErrorMessageDTO>> ValidateFileAsync(string path, string fileName)
        {

            var ErrorMessage = new List<UploadAutomateLogErrorMessageDTO>();
            int row = 1;
            try
            {
                path = Path.Combine(path, fileName);
                #region ReadExcel
                if (Path.GetExtension(fileName) == ".xls" || Path.GetExtension(fileName) == ".xlsx")
                {
                    ExcelDataSetConfiguration option = new ExcelDataSetConfiguration();

                    using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = new DataSet();

                            //First row is header
                            result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            }
                                );


                            //Rename column by mapping
                            string columns = "[{\"OriginalName\":\"เขตสุขภาพ\",\"NewName\":\"afu_arh_code\"},{\"OriginalName\":\"เครื่องจักร\",\"NewName\":\"afu_machinetype\"}," +
                                            "{\"OriginalName\":\"File Name\",\"NewName\":\"afu_filename\"},{\"OriginalName\":\"Field\",\"NewName\":\"aeh_field\"}," +
                                            "{\"OriginalName\":\"Field Value\",\"NewName\":\"aed_localvalue\"},{\"OriginalName\":\"Field Descr\",\"NewName\":\"aed_localdescr\"}," +
                                            "{\"OriginalName\":\"Data Code\",\"NewName\":\"data_code\"},{\"OriginalName\":\"Data Desc\",\"NewName\":\"data_desc\"}," +
                                            "{\"OriginalName\":\"afu_id\",\"NewName\":\"afu_id\"},{\"OriginalName\":\"afu_smp_id\",\"NewName\":\"afu_smp_id\"}]";
                            List<MappingColumn> names = JsonConvert.DeserializeObject<List<MappingColumn>>(columns);
                            DataTable source = result.Tables[0];

                            // Validate file
                            if (names.Count != source.Columns.Count)
                            {
                                ErrorMessage.Add(new UploadAutomateLogErrorMessageDTO
                                {
                                    afu_status = 'E',
                                    afu_Err_type = 'E',
                                    afu_Err_no = 1,
                                    afu_Err_Column = "All",
                                    afu_Err_Message = "รูปแบบไฟล์ไม่ถูกต้อง กรุณาตรวจสอบ!"
                                });
                                return ErrorMessage;
                            }

                            int error_no = 1;
                            foreach (DataColumn col in source.Columns)
                            {
                                if (!names.Where(x => x.OriginalName == col.ColumnName).Any())
                                {
                                    ErrorMessage.Add(new UploadAutomateLogErrorMessageDTO
                                    {
                                        afu_status = 'E',
                                        afu_Err_type = 'E',
                                        afu_Err_no = error_no,
                                        afu_Err_Column = col.ColumnName,
                                        afu_Err_Message = string.Format("ไม่พบ column {0} กรุณาตรวจสอบ!", col.ColumnName)
                                    });
                                    error_no++;
                                }
                            }
                            if (ErrorMessage.Any())
                            {
                                return ErrorMessage;
                            }

                            // Rename
                            //var dtResult = DataTableHelper.RenameColumn(result.Tables[0], names).Select("whonet_code<>''").CopyToDataTable();
                            var dtResult = DataTableHelper.RenameColumn(result.Tables[0], names);
                            //Save Temp to table
                            List<TempImportUploadAutomateLogDTO> objReturn = new List<TempImportUploadAutomateLogDTO>();
                            List<TempImportUploadAutomateLogDTO> models = new List<TempImportUploadAutomateLogDTO>();
                            models = DataTableHelper.ConvertDataTable<TempImportUploadAutomateLogDTO>(dtResult);
                            objReturn = await _apiHelper.PostDataAsync("mapping_api/Post_SaveImportUploadAutomateLogData", models);

                            ErrorMessage.Add(new UploadAutomateLogErrorMessageDTO
                            {
                                afu_status = 'I',
                                afu_Err_type = 'I',
                                afu_Err_no = 1,
                                afu_Err_Column = "Who_code",
                                afu_Err_Message = dtResult.Rows.Count.ToString()
                            });

                            ErrorMessage.Add(new UploadAutomateLogErrorMessageDTO
                            {
                                afu_status = 'I',
                                afu_Err_type = 'I',
                                afu_Err_no = 1,
                                afu_Err_Column = "Total",
                                afu_Err_Message = source.Rows.Count.ToString()
                            });
                        }
                    }
                }
                #endregion


                var chkError = ErrorMessage.FirstOrDefault(x => x.afu_status == 'E');
                if (chkError != null)
                {
                    File.Delete(path);
                }
                else
                {
                    ErrorMessage.Add(new UploadAutomateLogErrorMessageDTO
                    {
                        afu_status = 'I',
                        afu_Err_type = 'P',
                        afu_Err_no = 1,
                        afu_Err_Column = "path",
                        afu_Err_Message = path
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorMessage.Add(new UploadAutomateLogErrorMessageDTO
                {
                    afu_status = 'E',
                    afu_Err_type = 'E',
                    afu_Err_no = 1,
                    afu_Err_Column = "",
                    afu_Err_Message = ex.Message
                });
            }

            return ErrorMessage;
        }

        public async Task<UploadAutomateLogDTO> UploadFileAsync(UploadAutomateLogDTO model)
        {
            UploadAutomateLogDTO objReturn = new UploadAutomateLogDTO();
            objReturn = await _apiHelper.PostDataAsync("mapping_api/Post_SaveTempImportUploadAutomateLogData", model);

            return objReturn;
        }
    }
}