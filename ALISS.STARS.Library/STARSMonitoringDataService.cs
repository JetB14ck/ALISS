using ALISS.STARS.DTO;
using ALISS.STARS.Library.DataAccess;
using ALISS.STARS.Library.Models;
using AutoMapper;
using Log4NetLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALISS.STARS.Library
{
    public class STARSMonitoringDataService : ISTARSMonitoringDataService
    {
        private static readonly ILogService log = new LogService(typeof(STARSMonitoringDataService));

        private readonly STARSContext _db;
        private readonly IMapper _mapper;

        public STARSMonitoringDataService(STARSContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<STARSMonitoringListsDTO> GetSTARSMonitoringDataList(STARSMonitoringSearchDTO searchModel)
        {
            log.MethodStart();

            List<STARSMonitoringListsDTO> objList = new List<STARSMonitoringListsDTO>();

            //var searchModel = JsonSerializer.Deserialize<RepeatAutomateSearchDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.STARSMonitoringListsDTOs.FromSqlRaw<STARSMonitoringListsDTO>("sp_GET_STARSMonitoringList {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}"
                                                                                                   , searchModel.arh_code
                                                                                                   , searchModel.hos_code
                                                                                                   , searchModel.stars_no
                                                                                                   , searchModel.recvdate_start
                                                                                                   , searchModel.recvdatet_end
                                                                                                   , searchModel.tatdate_start
                                                                                                   , searchModel.tatdatet_end
                                                                                                   , searchModel.status
                                                                                                   ).ToList();

                    //objList = _mapper.Map<List<RepeatAutomateSearchDTO>>(objList);

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

        public STARSMonitoringListsDTO SaveTRSTARSResultData(STARSMonitoringListsDTO model)
        {
            log.MethodStart();

            STARSMonitoringListsDTO objList = new STARSMonitoringListsDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    
                    var objTRStarsResult = _mapper.Map<TRStarsResult>(model);

                    objTRStarsResult.srr_remark = model.srr_remark;
                    objTRStarsResult.srr_updatedate = DateTime.Now;


                    _db.TRStarsResults.Update(objTRStarsResult);

                    _db.SaveChanges();

                    trans.Commit();

                    objList = _mapper.Map<STARSMonitoringListsDTO>(model);
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

            return objList;
        }

        public STARSMonitoringDetailDTO GetSTARSMonitoringDataDetailByParam(string starsno)
        {
            log.MethodStart();

            STARSMonitoringDetailDTO obj = new STARSMonitoringDetailDTO();

            //var searchModel = JsonSerializer.Deserialize<RepeatAutomateSearchDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    obj = _db.STARSMonitoringDetailDTOs.FromSqlRaw<STARSMonitoringDetailDTO>("sp_GET_STARSMonitoringDetail {0}", starsno).ToList().FirstOrDefault();

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

            return obj;

        }

    }
}
