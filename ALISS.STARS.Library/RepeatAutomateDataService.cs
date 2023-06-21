using ALISS.STARS.DTO.RepeatAutomate;
using ALISS.STARS.Library.DataAccess;
using ALISS.STARS.Library.Models;
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
    public class RepeatAutomateDataService : IRepeatAutomateDataService
    {
        private static readonly ILogService log = new LogService(typeof(RepeatAutomateDataService));

        private readonly STARSContext _db;
        private readonly IMapper _mapper;

        public RepeatAutomateDataService(STARSContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        #region RepeatAutomate
        public List<RepeatAutomateDataDTO> GetRepeatAutomateList(RepeatAutomateSearchDTO searchModel)
        {
            log.MethodStart();

            List<RepeatAutomateDataDTO> objList = new List<RepeatAutomateDataDTO>();

            //var searchModel = JsonSerializer.Deserialize<RepeatAutomateSearchDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.RepeatAutomateDTOs.FromSqlRaw<RepeatAutomateDataDTO>("sp_GET_TRRepeatAutomateFileList {0}, {1}, {2}, {3}, {4}, {5}"
                                                                                                   , searchModel.arh_code
                                                                                                   , searchModel.repeat_startdate_str
                                                                                                   , searchModel.repeat_enddate_str
                                                                                                   , searchModel.testing_startdate_str
                                                                                                   , searchModel.testing_enddate_str
                                                                                                   , searchModel.repeat_status
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
        public RepeatAutomateDataDTO SaveRepeatFileUploadData(RepeatAutomateDataDTO model)
        {
            log.MethodStart();

            var currentDateTime = DateTime.Now;
            RepeatAutomateDataDTO objReturn = new RepeatAutomateDataDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objRepeat = _mapper.Map<TRAutomateUploadFile>(model);
                                      
                    objRepeat.afu_status = model.afu_status;
                    objRepeat.afu_smp_id = model.afu_smp_id;
                    objRepeat.afu_arh_code = model.afu_arh_code;
                    objRepeat.afu_machinetype = model.afu_machinetype;
                    objRepeat.afu_filename = model.afu_filename;
                    objRepeat.afu_path = model.afu_path;
                    objRepeat.afu_totalrecord = model.afu_totalrecord;
                    objRepeat.afu_repeat_flag = model.afu_repeat_flag;
                    objRepeat.afu_createdate = DateTime.Now;
                    objRepeat.afu_repeatdate = DateTime.Now;

                    _db.TRAutomateUploadFiles.Add(objRepeat);

                    _db.SaveChanges();

                    trans.Commit();

                    objReturn = _mapper.Map<RepeatAutomateDataDTO>(model);
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

            return objReturn;
        }

        #endregion
    }
}
