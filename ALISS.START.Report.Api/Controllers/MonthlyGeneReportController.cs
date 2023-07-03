using ALISS.STARS.Report;
using ALISS.STARS.Report.Api.Helpers;
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
using ALISS.STARS.Report.DTO;
using ALISS.STARS.DTO;
using ALISS.START.Report.Api.Models;
using System.Reflection;

namespace ALISS.START.Report.Api.Controllers
{
    public class MonthlyGeneReportController : ApiController
    {
        [HttpPost]
        [Route("api/STARSReport/printMonthlyGeneReport")]
        public IHttpActionResult PrintBarcode([FromBody] MonthlyReportDataDTO models)
        {
            ReportDocument rpt = new ReportDocument();
            string strReportName = "rptMonthlyGeneReport.rpt";
            var Targetpath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Report"), strReportName);
            rpt.Load(Targetpath);
            rpt.SetDataSource(models.reportListDTOs);
            rpt.SetParameterValue("report_title", models.reportTitle);

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
                    FileName = string.Format("MonthlyGeneReport_{0}_{1}.pdf", models.hos_code, DateTime.Now.ToString("yyyyMMdd"))
                };
            result.Content.Headers.ContentType =
                 new MediaTypeHeaderValue("application/pdf");

            rpt.Dispose();

            var response = ResponseMessage(result);
            return response;
        }
    }
}