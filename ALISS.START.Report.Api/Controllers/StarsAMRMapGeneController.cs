
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Results;
using RouteAttribute = System.Web.Http.RouteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using ALISS.STARS.DTO.STARSMapGene;
using ALISS.STARS.Report.Api.Helpers;
using AutoMapper;
using ALISS.EXPORT.Library.Model;

namespace ALISS.START.Report.Api.Controllers
{
    public class StarsAMRMapGeneController : ApiController
    {
        private class MonthItem
        {
            public string MonthValue { get; set; }
            public string MonthName { get; set; }
        }

        [HttpPost]
        [Route("api/ExportStarsAMRMapGene/ExportStarsAMRMapGene")]
        public IHttpActionResult PreviewReport([FromBody] StarsAMRMapGeneDataDTO model)
        {
            MonthItem[] MonthData = new MonthItem[] {
                new MonthItem
                {
                    MonthValue = "1",
                    MonthName = "มกราคม"
                },
                new MonthItem
                {
                   MonthValue = "2",
                   MonthName = "กุมภาพันธ์"
                },
                new MonthItem
                {
                  MonthValue = "3",
                  MonthName = "มีนาคม"
                },
                new MonthItem
                {
                   MonthValue = "4",
                   MonthName = "เมษายน"
                },
                new MonthItem
                {
                   MonthValue = "5",
                   MonthName = "พฤษภาคม"
                },
                new MonthItem
                {
                    MonthValue = "6",
                    MonthName = "มิถุนายน"
                },
                new MonthItem
                {
                   MonthValue = "7",
                    MonthName = "กรกฎาคม"
                },
                new MonthItem
                {
                   MonthValue = "8",
                    MonthName = "สิงหาคม"
                },
                new MonthItem
                {
                    MonthValue = "9",
                    MonthName = "กันยายน"
                },
                new MonthItem
                {
                   MonthValue = "10",
                    MonthName = "ตุลาคม"
                },
                new MonthItem
                {
                    MonthValue = "11",
                    MonthName = "พฤศจิกายน"
                },
                new MonthItem
                {
                   MonthValue = "12",
                   MonthName = "ธันวาคม"
                }
            };
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<StarsAMRMapGeneDataDTO, sp_GET_RPAntibiotrendAMRStrategy_Result>(); });
            var mapper = new Mapper(config);
            List<sp_GET_RPAntibiotrendAMRStrategy_Result> data = new List<sp_GET_RPAntibiotrendAMRStrategy_Result>() { mapper.Map<StarsAMRMapGeneDataDTO, sp_GET_RPAntibiotrendAMRStrategy_Result>(model) };

            ReportDocument rpt = new ReportDocument();
            string strReportName = "rptStarsAMRMapGeneReport.rpt";
            var Targetpath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Report"), strReportName);
            rpt.Load(Targetpath);
            rpt.SetDataSource(data);
            rpt.SetParameterValue("paramStrHeader", string.Format("{0} - {1} {2}"
                , MonthData.FirstOrDefault(x => x.MonthValue == model.from_month).MonthName
                , MonthData.FirstOrDefault(x => x.MonthValue == model.to_month).MonthName
                , model.year_code
                ));



            // --------------- Export to PDF -------------------------------

            var stream = rpt.ExportToStream(ExportFormatType.PortableDocFormat);
            // processing the stream.
            var sm = ReportHelpers.ReadFully(stream);
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(sm.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = string.Format("StarsAMRMapGeneReport_{0}.pdf", DateTime.Now.ToString("yyyyMMdd"))
                };
            result.Content.Headers.ContentType =
                 new MediaTypeHeaderValue("application/pdf");

            rpt.Dispose();

            var response = ResponseMessage(result);
            return response;
        }
    }
}