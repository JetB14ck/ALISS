using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Log4NetLibrary;
using ALISS.Data.Client;
using ALISS.STARS.DTO.STARSMapGene;
using ALISS.DropDownList.DTO;
using Microsoft.JSInterop;

namespace ALISS.Data.D7_Stars.StarsAMRMap
{
    public class StarsAMRMapGeneService
    {
        private IConfiguration Configuration { get; }
        private string _reportPath;
        private ApiHelper _apiHelper;
        private static readonly ILogService log = new LogService(typeof(StarsAMRMapGeneService));
        public StarsAMRMapGeneService(IConfiguration configuration)
        {
            _apiHelper = new ApiHelper(configuration["ApiClient:ApiUrl"]);
            _reportPath = configuration["ReportPath"];
        }

        public async Task<List<StarsAMRMapGeneDataDTO>> GetSTARSAMRStrategyModelAsync(StarsAMRMapGeneSearchDTO searchData)
        {
            List<StarsAMRMapGeneDataDTO> objList = new List<StarsAMRMapGeneDataDTO>();

            objList = await _apiHelper.GetDataListByModelAsync<StarsAMRMapGeneDataDTO, StarsAMRMapGeneSearchDTO>("stars_map_amr_api/GetStarsAMRMapGeneDataWithModel", searchData);

            return objList;
        }

        public async Task ExportMapDataAsync(IJSRuntime iJSRuntime, StarsAMRMapGeneDataDTO data, string tempPath)
        {
            try
            {
                var filename = string.Format("StarsAMRMapGeneReport_{0}.pdf", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                var _reportPath = Path.Combine(tempPath, DateTime.Today.ToString("yyyyMMdd"));
                var outputfileInfo = new FileInfo(Path.Combine(_reportPath, filename));
                if (!Directory.Exists(outputfileInfo.DirectoryName))
                    Directory.CreateDirectory(outputfileInfo.DirectoryName);
                var response = await _apiHelper.ExportDataBarcodeAsync<StarsAMRMapGeneDataDTO>("export_starsmap_api/ExportStarsAMRMapGene", outputfileInfo, data);
                if (response == "OK")
                {
                    byte[] fileBytes;
                    using (FileStream fs = outputfileInfo.OpenRead())
                    {
                        fileBytes = new byte[fs.Length];
                        fs.Read(fileBytes, 0, fileBytes.Length);

                        iJSRuntime.InvokeAsync<StarsAMRMapGeneService>(
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
