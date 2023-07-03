
using AutoMapper;
using Log4NetLibrary;
using ALISS.STARS.Library.DataAccess;
using ALISS.STARS.DTO;
using ALISS.STARS.Library.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace ALISS.STARS.Library
{
    public class MonthlyGeneReportService : IMonthlyGeneReportService
    {
        private static readonly ILogService log = new LogService(typeof(UploadAutomateService));

        private readonly STARSContext _db;
        private readonly IMapper _mapper;

        public MonthlyGeneReportService(STARSContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<MonthlyGeneReportDataDTO> GetMonthlyGeneReportListWithModel(MonthlyGeneReportSearchDTO searchModel)
        {
            log.MethodStart();


            List<MonthlyGeneReportDataDTO> objList = new List<MonthlyGeneReportDataDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.MonthlyGeneReportDataDTOs.FromSqlRaw<MonthlyGeneReportDataDTO>("sp_GET_MonthlyGeneReportData {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}"
                        , searchModel.arh_code
                        , searchModel.hos_code
                        , searchModel.from_month
                        , searchModel.to_month
                        , searchModel.year_code
                        , searchModel.stars_org_code
                        , searchModel.spec_code
                        , searchModel.ward_type
                        ).ToList();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    // TODO: Handle failure
                    trans.Rollback();
                }
                finally
                {
                    trans.Dispose();
                }
            }
            log.MethodFinish();

            return objList;

        }
    }
}