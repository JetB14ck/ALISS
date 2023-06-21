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
using ALISS.STARS.DTO.RepeatAutomate;

namespace ALISS.Data.D7_StarsRepeat
{
    public class RepeatAutomateService
    {
        private IConfiguration Configuration { get; }

        private ApiHelper _apiHelper;
        public RepeatAutomateService(IConfiguration configuration)
        {
            _apiHelper = new ApiHelper(configuration["ApiClient:ApiUrl"]);
        }

        #region Repeat Automate
        public async Task<List<RepeatAutomateDataDTO>> GetRepeatAutomateListByParamAsync(RepeatAutomateSearchDTO modelSearch)
        {
            List<RepeatAutomateDataDTO> objList = new List<RepeatAutomateDataDTO>();

            var searchJson = JsonSerializer.Serialize(modelSearch);

            objList = await _apiHelper.GetDataListByModelAsync<RepeatAutomateDataDTO, RepeatAutomateSearchDTO>("repeat_automate_api/GetRepeatAutomateListByModel", modelSearch);

            return objList;
        }

        public async void ExportBarcode(IJSRuntime iJSRuntime, List<RepeatAutomateDataDTO> data, string tempPath)
        {
            try
            {
                var filename = string.Format("STARSRepeatBarcode_{0}.pdf", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                var _reportPath = Path.Combine(tempPath, DateTime.Today.ToString("yyyyMMdd"));
                var outputfileInfo = new FileInfo(Path.Combine(_reportPath, filename));
                if (!Directory.Exists(outputfileInfo.DirectoryName))
                    Directory.CreateDirectory(outputfileInfo.DirectoryName);
                var response = await _apiHelper.ExportDataBarcodeAsync<List<RepeatAutomateDataDTO>>("exportstars_api/printBarcode", outputfileInfo, data);
                if (response == "OK")
                {
                    byte[] fileBytes;
                    using (FileStream fs = outputfileInfo.OpenRead())
                    {
                        fileBytes = new byte[fs.Length];
                        fs.Read(fileBytes, 0, fileBytes.Length);

                        iJSRuntime.InvokeAsync<RepeatAutomateService>(
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

        public async void ExportLogbook(IJSRuntime iJSRuntime, List<RepeatAutomateDataDTO> data, string tempPath)
        {
            try
            {
                var filename = string.Format("STARSRepeatLogbook_{0}.pdf", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                var _reportPath = Path.Combine(tempPath, DateTime.Today.ToString("yyyyMMdd"));
                var outputfileInfo = new FileInfo(Path.Combine(_reportPath, filename));
                if (!Directory.Exists(outputfileInfo.DirectoryName))
                    Directory.CreateDirectory(outputfileInfo.DirectoryName);
                var response = await _apiHelper.ExportDataBarcodeAsync<List<RepeatAutomateDataDTO>>("exportstars_api/printLogbook", outputfileInfo, data);
                if (response == "OK")
                {
                    byte[] fileBytes;
                    using (FileStream fs = outputfileInfo.OpenRead())
                    {
                        fileBytes = new byte[fs.Length];
                        fs.Read(fileBytes, 0, fileBytes.Length);

                        iJSRuntime.InvokeAsync<RepeatAutomateService>(
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

        public async Task<string> GetPath()
        {
            //var ErrorMessage = new List<LabFileUploadErrorMessageDTO>();

            string path = "";
            List<ParameterDTO> objParamList = new List<ParameterDTO>();
            var searchModel = new ParameterDTO() { prm_code_major = "REPEAT_UPLOAD_PATH" };

            objParamList = await _apiHelper.GetDataListByModelAsync<ParameterDTO, ParameterDTO>("dropdownlist_api/GetParameterList", searchModel);

            if (objParamList.FirstOrDefault(x => x.prm_code_minor == "PATH") != null)
            {
                path = objParamList.FirstOrDefault(x => x.prm_code_minor == "PATH").prm_value;
            }
            else
            {
                //ErrorMessage.Add(new LabFileUploadErrorMessageDTO
                //{
                //    lfu_status = 'E',
                //    lfu_Err_type = 'E',
                //    lfu_Err_no = 1,
                //    lfu_Err_Column = "",
                //    lfu_Err_Message = "ไม่พบ Config PATH กรุณาติดต่อผู้ดูแลระบบ "
                //});

                //return ErrorMessage;
            }

            return path;
        }

        public async Task<List<AutomateFileUploadErrorMessageDTO>> ValidateLabFileAsync(string path, string fileName, Guid MappingTemplateID)
        {

            var ErrorMessage = new List<AutomateFileUploadErrorMessageDTO>();
            int row = 1;
            try
            {
                STARSWHONetMappingSearch searchWHONet = new STARSWHONetMappingSearch();
                searchWHONet.swm_mappingid = MappingTemplateID;

                STARSMappingDataDTO MappingTemplate = await _apiHelper.GetDataByIdAsync<STARSMappingDataDTO>("stars_mapping_api/GetMappingDataById", MappingTemplateID.ToString());

                List<STARSWHONetMappingDataDTO> STARSMappingColumn = await _apiHelper.GetDataListByModelAsync<STARSWHONetMappingDataDTO, STARSWHONetMappingSearch>("stars_mapping_api/Get_WHONetMappingListByModel", searchWHONet);
                var WHONetColumnMandatory = STARSMappingColumn.Where(x => x.swm_mandatory == true);

                path = Path.Combine(path, fileName);
                #region ReadExcel
                if (Path.GetExtension(fileName).ToLower() == ".xls" || Path.GetExtension(fileName).ToLower() == ".xlsx")
                {
                    ExcelDataSetConfiguration option = new ExcelDataSetConfiguration();

                    using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = new DataSet();

                            //First row is header
                            if (MappingTemplate.smp_firstlineisheader == true)
                            {

                                result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true
                                    }
                                }
                                );
                            }
                            else
                            {
                                result = reader.AsDataSet();
                            }

                            var dtResult = result.Tables[0];
                            ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                            {
                                afu_status = 'I',
                                afu_Err_type = 'I',
                                afu_Err_no = 1,
                                afu_Err_Column = "Total",
                                afu_Err_Message = dtResult.Rows.Count.ToString()
                            });

                            foreach (STARSWHONetMappingDataDTO item in WHONetColumnMandatory)
                            {
                                var swm_originalfield = item.swm_originalfield;
                                var swm_whonetfield = item.swm_whonetfield;
                                if (MappingTemplate.smp_firstlineisheader == false)
                                {
                                    int index = 0;
                                    Int32.TryParse(item.swm_originalfield.Replace("Column", ""), out index);

                                    item.swm_originalfield = "Column" + (index - 1);
                                }

                                Boolean columnExists = dtResult.Columns.Contains(item.swm_originalfield);
                                if (columnExists == false)
                                {
                                    ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                                    {
                                        afu_status = 'E',
                                        afu_Err_type = 'C',
                                        afu_Err_no = 1,
                                        afu_Err_Column = swm_originalfield,
                                        afu_Err_Message = "ไม่พบ Column " + swm_originalfield
                                    });
                                }

                                if (columnExists)
                                {
                                    var chkResult = dtResult.Select("[" + item.swm_originalfield + "]" + " is null");

                                    if (chkResult.Length > 0)
                                    {
                                        ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                                        {
                                            afu_status = 'E',
                                            afu_Err_type = 'N',
                                            afu_Err_no = 1,
                                            afu_Err_Column = swm_originalfield,
                                            afu_Err_Message = "กรุณาตรวจสอบข้อมูล Column " + swm_originalfield + " จะต้องไม่เท่ากับค่าว่าง"
                                        });
                                    }
                                }
                            } //end check mandatory column

                            var WHONetSpecimenDate = STARSMappingColumn.Where(a => a.swm_whonetfield == "Specimen date");
                            if (WHONetSpecimenDate.Count() > 0)
                            {
                                STARSWHONetMappingDataDTO wHONetMappingLists = WHONetSpecimenDate.FirstOrDefault();
                                DateTime temp = new DateTime();
                                string dateFormat = wHONetMappingLists.swm_fieldformat;

                                dateFormat = Regex.Replace(dateFormat, "d", "d", RegexOptions.IgnoreCase);
                                //dateFormat = Regex.Replace(dateFormat, "m", "M", RegexOptions.IgnoreCase);
                                dateFormat = Regex.Replace(dateFormat, "y", "y", RegexOptions.IgnoreCase);

                                foreach (DataRow rows in dtResult.Rows)
                                {
                                    if (rows[wHONetMappingLists.swm_originalfield].GetType() != typeof(DateTime))
                                    {
                                        DateTime.TryParseExact(rows[wHONetMappingLists.swm_originalfield].ToString(), dateFormat, System.Globalization.CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out temp);
                                        if (temp == DateTime.MinValue)
                                        {
                                            ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                                            {
                                                afu_status = 'E',
                                                afu_Err_type = 'N',
                                                afu_Err_no = 1,
                                                afu_Err_Column = wHONetMappingLists.swm_originalfield,
                                                afu_Err_Message = "กรุณาตรวจสอบข้อมูล Column " + wHONetMappingLists.swm_originalfield + " มีค่าไม่ถูกต้อง"
                                            });
                                            break;
                                        }
                                    }
                                }
                            }
                            var x = ErrorMessage;
                        }
                    }
                }
                #endregion
                #region ReadCSV
                else if (Path.GetExtension(fileName).ToLower() == ".csv")
                {
                    using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                    {

                        var reader = ExcelReaderFactory.CreateCsvReader(stream, new ExcelReaderConfiguration()
                        {
                            FallbackEncoding = Encoding.GetEncoding(1252),
                            AutodetectSeparators = new char[] { ',', ';', '\t', '|', '#' },
                            LeaveOpen = false,
                            AnalyzeInitialCsvRows = 0,
                        });

                        DataSet result = new DataSet();


                        //First row is header
                        if (MappingTemplate.smp_firstlineisheader == true)
                        {

                            result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            }
                            );
                        }
                        else
                        {
                            result = reader.AsDataSet();
                        }

                        ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                        {
                            afu_status = 'I',
                            afu_Err_type = 'I',
                            afu_Err_no = 1,
                            afu_Err_Column = "Total",
                            afu_Err_Message = result.Tables[0].Rows.Count.ToString()
                        });

                        var ee = result.Tables[0];
                        foreach (STARSWHONetMappingDataDTO item in WHONetColumnMandatory)
                        {
                            var wnm_originalfield = item.swm_originalfield;
                            var wnm_whonetfield = item.swm_whonetfield;
                            if (MappingTemplate.smp_firstlineisheader == false)
                            {
                                int index = 0;
                                Int32.TryParse(item.swm_originalfield.Replace("Column", ""), out index);

                                item.swm_originalfield = "Column" + (index - 1);
                            }

                            Boolean columnExists = result.Tables[0].Columns.Contains(item.swm_originalfield);
                            if (columnExists == false)
                            {
                                ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                                {
                                    afu_status = 'E',
                                    afu_Err_type = 'C',
                                    afu_Err_no = 1,
                                    afu_Err_Column = wnm_originalfield,
                                    afu_Err_Message = "ไม่พบ Column " + wnm_originalfield
                                });
                            }

                            if (columnExists)
                            {
                                var chkResult = result.Tables[0].Select(item.swm_originalfield + " = ''");

                                if (chkResult.Length > 0)
                                {
                                    ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                                    {
                                        afu_status = 'E',
                                        afu_Err_type = 'N',
                                        afu_Err_no = 1,
                                        afu_Err_Column = wnm_originalfield,
                                        afu_Err_Message = "กรุณาตรวจสอบข้อมูล Column " + wnm_originalfield + " จะต้องไม่เท่ากับค่าว่าง"
                                    });
                                }

                            }
                        }

                        var x = ErrorMessage;

                    }
                }
                #endregion
                #region ReadText
                else if (Path.GetExtension(fileName).ToLower() == ".txt")
                {
                    string line;
                    DataTable dt = new DataTable();
                    using (TextReader tr = File.OpenText(path))
                    {
                        while ((line = tr.ReadLine()) != null)
                        {
                            string[] items = line.Split('\t');

                            if (dt.Columns.Count == 0)
                            {
                                if (MappingTemplate.smp_firstlineisheader == false)
                                {
                                    for (int i = 0; i < items.Length; i++)
                                        dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
                                }
                                else
                                {
                                    for (int i = 0; i < items.Length; i++)
                                        dt.Columns.Add(new DataColumn(items[i].ToString(), typeof(string)));
                                }
                            }
                            dt.Rows.Add(items);
                        }
                    }

                    //File.Delete(path);
                    ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                    {
                        afu_status = 'I',
                        afu_Err_type = 'I',
                        afu_Err_no = 1,
                        afu_Err_Column = "Total",
                        afu_Err_Message = (dt.Rows.Count - 1).ToString()
                    });

                    foreach (STARSWHONetMappingDataDTO item in WHONetColumnMandatory)
                    {
                        var wnm_originalfield = item.swm_originalfield;
                        var wnm_whonetfield = item.swm_whonetfield;
                        if (MappingTemplate.smp_firstlineisheader == false)
                        {
                            int index = 0;
                            Int32.TryParse(item.swm_originalfield.Replace("Column", ""), out index);

                            item.swm_originalfield = "Column" + (index - 1);
                        }

                        Boolean columnExists = dt.Columns.Contains(item.swm_originalfield);
                        if (columnExists == false)
                        {
                            ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                            {
                                afu_status = 'E',
                                afu_Err_type = 'C',
                                afu_Err_no = 1,
                                afu_Err_Column = wnm_originalfield,
                                afu_Err_Message = "ไม่พบ Column " + wnm_originalfield
                            });
                        }

                        if (columnExists)
                        {
                            var chkResult = dt.Select(item.swm_originalfield + " = ''");

                            if (chkResult.Length > 0)
                            {
                                ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                                {
                                    afu_status = 'E',
                                    afu_Err_type = 'N',
                                    afu_Err_no = 1,
                                    afu_Err_Column = wnm_originalfield,
                                    afu_Err_Message = "กรุณาตรวจสอบข้อมูล Column " + wnm_originalfield + " จะต้องไม่เท่ากับค่าว่าง"
                                });
                            }

                        }

                    }

                }
                #endregion
                #region ReadSqlite
                else if (Path.GetExtension(fileName).ToLower() == ".sqlite")
                {
                    Batteries.Init();
                    DataSet result = new DataSet();
                    string connectionString = string.Format("Data Source={0}", path);
                    using (SqliteConnection connection = new SqliteConnection(connectionString))
                    {
                        connection.Open();

                        string query = "SELECT * FROM Isolates";
                        using (SqliteDataAdapter dataAdapter = new SqliteDataAdapter())
                        {
                            dataAdapter.SelectCommand = new SqliteCommand(query, connection);
                            dataAdapter.Fill(result);
                        }
                    }

                    var dtResult = result.Tables[0];
                    ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                    {
                        afu_status = 'I',
                        afu_Err_type = 'I',
                        afu_Err_no = 1,
                        afu_Err_Column = "Total",
                        afu_Err_Message = dtResult.Rows.Count.ToString()
                    });

                    foreach (STARSWHONetMappingDataDTO item in WHONetColumnMandatory)
                    {
                        var wnm_originalfield = item.swm_originalfield;
                        var wnm_whonetfield = item.swm_whonetfield;
                        if (MappingTemplate.smp_firstlineisheader == false)
                        {
                            int index = 0;
                            Int32.TryParse(item.swm_originalfield.Replace("Column", ""), out index);

                            item.swm_originalfield = "Column" + (index - 1);
                        }

                        Boolean columnExists = dtResult.Columns.Contains(item.swm_originalfield);
                        if (columnExists == false)
                        {
                            ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                            {
                                afu_status = 'E',
                                afu_Err_type = 'C',
                                afu_Err_no = 1,
                                afu_Err_Column = wnm_originalfield,
                                afu_Err_Message = "ไม่พบ Column " + wnm_originalfield
                            });
                        }

                        if (columnExists)
                        {
                            var chkResult = dtResult.Select("[" + item.swm_originalfield + "]" + " is null");

                            if (chkResult.Length > 0)
                            {
                                ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                                {
                                    afu_status = 'E',
                                    afu_Err_type = 'N',
                                    afu_Err_no = 1,
                                    afu_Err_Column = wnm_originalfield,
                                    afu_Err_Message = "กรุณาตรวจสอบข้อมูล Column " + wnm_originalfield + " จะต้องไม่เท่ากับค่าว่าง"
                                });
                            }
                        }
                    } //end check mandatory column

                    var WHONetSpecimenDate = STARSMappingColumn.Where(a => a.swm_whonetfield == "Specimen date");
                    if (WHONetSpecimenDate.Count() > 0)
                    {
                        STARSWHONetMappingDataDTO wHONetMappingLists = WHONetSpecimenDate.FirstOrDefault();
                        DateTime temp = new DateTime();
                        string dateFormat = wHONetMappingLists.swm_fieldformat;

                        dateFormat = Regex.Replace(dateFormat, "d", "d", RegexOptions.IgnoreCase);
                        //dateFormat = Regex.Replace(dateFormat, "m", "M", RegexOptions.IgnoreCase);
                        dateFormat = Regex.Replace(dateFormat, "y", "y", RegexOptions.IgnoreCase);

                        dateFormat = "yyyy-MM-dd";

                        foreach (DataRow rows in dtResult.Rows)
                        {
                            if (rows[wHONetMappingLists.swm_originalfield].GetType() != typeof(DateTime))
                            {
                                DateTime.TryParseExact(rows[wHONetMappingLists.swm_originalfield].ToString(), dateFormat, System.Globalization.CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.None, out temp);
                                if (temp == DateTime.MinValue)
                                {
                                    ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                                    {
                                        afu_status = 'E',
                                        afu_Err_type = 'N',
                                        afu_Err_no = 1,
                                        afu_Err_Column = wHONetMappingLists.swm_originalfield,
                                        afu_Err_Message = "กรุณาตรวจสอบข้อมูล Column " + wHONetMappingLists.swm_originalfield + " มีค่าไม่ถูกต้อง"
                                    });
                                    break;
                                }
                            }
                        }
                    }
                    var x = ErrorMessage;
                }
                #endregion
                #region ReadDataAccess
                else if (Path.GetExtension(fileName).ToLower() == ".accdb")
                {

                }
                #endregion
                else
                {
                    var options = new DbfDataReaderOptions
                    {
                        Encoding = Encoding.GetEncoding(874)
                    };

                    using (var dbfDataReader = new DbfDataReader.DbfDataReader(path, options))
                    //using (var dbfDataReader = new DbfDataReader.DbfDataReader(@"D:\Work\02-DMSC ALISS\TEMP\" + tempFilename, options))
                    {
                        ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                        {
                            afu_status = 'I',
                            afu_Err_type = 'I',
                            afu_Err_no = 1,
                            afu_Err_Column = "Total",
                            afu_Err_Message = dbfDataReader.DbfTable.Header.RecordCount.ToString()
                        });

                        while (dbfDataReader.Read())
                        {
                            //Validate Mandatory Field
                            foreach (STARSWHONetMappingDataDTO item in WHONetColumnMandatory)
                            {
                                var columnExists = dbfDataReader.DbfTable.Columns.FirstOrDefault(x => x.Name == item.swm_originalfield);

                                //var ll = dbfDataReader.DbfTable.Rea
                                if (columnExists != null)
                                {
                                    // 16/03/2021 : ถ้ายอมให้ Organism เป็น null ได้?? comment ตรงนี้ 

                                    //if (dbfDataReader[item.wnm_originalfield] == "" || dbfDataReader[item.wnm_originalfield] == null)
                                    //{
                                    //    if (ErrorMessage.FirstOrDefault(x => x.lfu_Err_type == 'N' && x.lfu_Err_Column == item.wnm_originalfield) == null)
                                    //    {
                                    //        ErrorMessage.Add(new LabFileUploadErrorMessageDTO
                                    //        {
                                    //            lfu_status = 'E',
                                    //            lfu_Err_type = 'N',
                                    //            lfu_Err_no = 1,
                                    //            lfu_Err_Column = item.wnm_originalfield,
                                    //            lfu_Err_Message = "กรุณาตรวจสอบข้อมูล Column " + item.wnm_originalfield + " จะต้องไม่เท่ากับค่าว่าง"
                                    //        });
                                    //    }
                                    //}
                                }
                                else
                                {
                                    if (ErrorMessage.FirstOrDefault(x => x.afu_Err_type == 'C' && x.afu_Err_Column == item.swm_originalfield) == null)
                                    {
                                        ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
                                        {
                                            afu_status = 'E',
                                            afu_Err_type = 'C',
                                            afu_Err_no = 1,
                                            afu_Err_Column = item.swm_originalfield,
                                            afu_Err_Message = "ไม่พบ Column " + item.swm_originalfield
                                        });
                                    }
                                }

                            }
                            row++;
                        }
                        var x = ErrorMessage;
                    }
                    
                }

                var chkError = ErrorMessage.FirstOrDefault(x => x.afu_status == 'E');
                if (chkError != null)
                {
                    File.Delete(path);
                }
                else
                {
                    ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
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
                ErrorMessage.Add(new AutomateFileUploadErrorMessageDTO
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

        public async Task<RepeatAutomateDataDTO> UploadFileAsync(RepeatAutomateDataDTO model)
        {
            RepeatAutomateDataDTO objReturn = new RepeatAutomateDataDTO();
            
            objReturn = await _apiHelper.PostDataAsync<RepeatAutomateDataDTO>("repeat_automate_api/Post_SaveRepeatFileUploadData", model);

            return objReturn;

        }

        #endregion
    }
}
