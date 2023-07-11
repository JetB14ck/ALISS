using ALISS.STARS.DTO.NarstService;
using ALISS.STARS.Library.DataAccess;
using AutoMapper;
using Log4NetLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ALISS.STARS.Library
{
    public class NarstServService : INarstServService
    {
        private static readonly ILogService log = new LogService(typeof(NarstServService));

        private readonly STARSContext _db;
        private readonly IMapper _mapper;

        public NarstServService(STARSContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<NarstServiceDTO> GetInterpretResultInfo(string Param)
        {
            log.MethodStart();


            List<NarstServiceDTO> objList = new List<NarstServiceDTO>();

            var searchModel = JsonSerializer.Deserialize<NarstServiceDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.NarstServiceDTOs.FromSqlRaw<NarstServiceDTO>("sp_GET_INTERP_RESULT_INFO {0}, {1}", searchModel.start_date, searchModel.end_date).ToList();
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

        public List<NarstServiceDTO> GetInterpretResultInfos(string startdate, string enddate)
        {
            log.MethodStart();


            List<NarstServiceDTO> objList = new List<NarstServiceDTO>();

            var start_date = JsonSerializer.Deserialize<NarstServiceDTO>(startdate);
            var end_date = JsonSerializer.Deserialize<NarstServiceDTO>(enddate);

            var sttdate = DateTime.Parse(startdate);
            var eddate = DateTime.Parse(enddate);

            var convstdate = Convert.ToDateTime(startdate);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.NarstServiceDTOs.FromSqlRaw<NarstServiceDTO>("sp_GET_INTERP_RESULT_INFO {0} {1}", convstdate.start_date, eddate.end_date).ToList();
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
