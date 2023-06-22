
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
using ALISS.STARS.Report.Api.Helpers;
using ALISS.START.Report.Api.Models;
using System.Reflection;

namespace ALISS.EXPORT.Api.Controllers
{
    public class STARSPersonalReportController : ApiController
    {
        [HttpPost]
        [Route("api/STARSReport/PreviewReport")]
        public IHttpActionResult PreviewReport([FromBody] STARSPersonalReportExportDTO model)
        {
            ReportDocument rpt = new ReportDocument();
            string strReportName = "rptSTARSPersonalReport.rpt";
            var Targetpath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Report"), strReportName);
            rpt.Load(Targetpath);
            rpt.SetParameterValue("arh_name", model.arh_name);
            rpt.SetParameterValue("arh_address", model.arh_address);
            rpt.SetParameterValue("arh_telephone", model.arh_telephone);
            rpt.SetParameterValue("arh_certificate", model.arh_certificate);
            rpt.SetParameterValue("srp_reportno", model.srp_reportno);
            rpt.SetParameterValue("hos_name", model.hos_name);
            rpt.SetParameterValue("hos_address", model.hos_address);
            rpt.SetParameterValue("srp_starsno", model.srp_starsno);
            rpt.SetParameterValue("srr_ident_spec_name", model.srr_ident_spec_name);
            rpt.SetParameterValue("srr_name", model.srr_name);
            rpt.SetParameterValue("srr_age", model.srr_age);
            rpt.SetParameterValue("srr_stars_labno", model.srr_stars_labno);
            rpt.SetParameterValue("srr_ident_organism", model.srr_ident_organism);
            rpt.SetParameterValue("stars_automate_result", string.IsNullOrEmpty(model.stars_automate_result) ? "": model.stars_automate_result.Replace("\\n", Environment.NewLine));
            rpt.SetParameterValue("srr_testuser", model.srp_testing_user);
            rpt.SetParameterValue("srr_approveuser", model.srp_approve_user);
            rpt.SetParameterValue("srp_director_path", model.srp_director_path);
            rpt.SetParameterValue("srp_director_name", model.srp_director_name);
            rpt.SetParameterValue("srp_director_position", model.srp_director_position);
            rpt.SetParameterValue("srp_director_position2", model.srp_director_position2);
            rpt.SetParameterValue("srp_remarks", model.srp_remarks);
            rpt.SetParameterValue("srr_senddate_str", model.srr_senddate_str);
            rpt.SetParameterValue("srr_recvdate_str", model.srr_recvdate_str);
            rpt.SetParameterValue("srr_testdate_str", model.srr_testdate_str);
            rpt.SetParameterValue("srr_approvedate_str", model.srr_approvedate_str);
            rpt.SetParameterValue("srr_reportdate_str", model.srr_reportdate_str);

            //List<STARSPersonalReportExportDTO> models = new List<STARSPersonalReportExportDTO>();
            //models.Add(model);
            //rpt.SetDataSource(models);



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
                    FileName = string.Format("STARSPersonalReport_{0}.pdf", DateTime.Now.ToString("yyyyMMdd"))
                };
            result.Content.Headers.ContentType =
                 new MediaTypeHeaderValue("application/pdf");

            rpt.Dispose();

            var response = ResponseMessage(result);
            return response;
        }
    }
}
