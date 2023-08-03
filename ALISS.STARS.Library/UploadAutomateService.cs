using System;
using AutoMapper;
using Log4NetLibrary;
using ALISS.STARS.Library.DataAccess;
using ALISS.STARS.DTO;
using ALISS.STARS.Library.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ALISS.STARS.DTO.UploadAutomate;
using EFCore.BulkExtensions;
using ALISS.Mapping.DTO;

namespace ALISS.STARS.Library
{
    public class UploadAutomateService : IUploadAutomateService
    {
        private static readonly ILogService log = new LogService(typeof(UploadAutomateService));
       
        private readonly STARSContext _db;
        private readonly IMapper _mapper;

        public UploadAutomateService(STARSContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public UploadAutomateDataDTO SaveUploadAutomateData(UploadAutomateDataDTO model)
        {
            log.MethodStart();

            var currentDateTime = DateTime.Now;
            UploadAutomateDataDTO objReturn = new UploadAutomateDataDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objModel = new TRAutomateUploadFile();

                    if (model.afu_status == "N")
                    {
                        objModel = _mapper.Map<TRAutomateUploadFile>(model);

                        objModel.afu_createdate = currentDateTime;
                        objModel.afu_updatedate = currentDateTime;

                        _db.TRAutomateUploadFiles.Add(objModel);
                    }
                    else
                    {
                        objModel = _db.TRAutomateUploadFiles.FirstOrDefault(x => x.afu_id == model.afu_id);
                        objModel.afu_id = model.afu_id;
                        objModel.afu_arh_code = model.afu_arh_code;
                        objModel.afu_machinetype = model.afu_machinetype;
                        objModel.afu_filename = model.afu_filename;
                        objModel.afu_path = model.afu_path;
                        objModel.afu_totalrecord = model.afu_totalrecord;
                        objModel.afu_errorrecord = model.afu_errorrecord;
                        objModel.afu_smp_id = model.afu_smp_id;
                        objModel.afu_status = model.afu_status;
                        objModel.afu_repeat_flag = model.afu_repeat_flag;
                        objModel.afu_repeatuser = model.afu_repeatuser;
                        objModel.afu_repeatdate = model.afu_repeatdate;
                        objModel.afu_createuser = model.afu_createuser;
                        objModel.afu_createdate = model.afu_createdate;
                        objModel.afu_updateuser = model.afu_updateuser;
                        objModel.afu_updatedate = model.afu_updatedate;
                    }

                    _db.SaveChanges();

                    trans.Commit();

                    objReturn = _mapper.Map<UploadAutomateDataDTO>(objModel);
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

        public UploadAutomateDataDTO GetUploadAutomateDataById(int afu_id)
        {
            log.MethodStart();
            UploadAutomateDataDTO objModel = new UploadAutomateDataDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objReturn = _db.TRAutomateUploadFiles.FirstOrDefault(x => x.afu_id == afu_id);

                    objModel = _mapper.Map<UploadAutomateDataDTO>(objReturn);

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

            return objModel;
        }

        public List<UploadAutomateDataDTO> GetUploadAutomateListWithModel(UploadAutomateSearchDTO searchModel)
        {
            log.MethodStart();


            List<UploadAutomateDataDTO> objList = new List<UploadAutomateDataDTO>();
                     
            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.UploadAutomateDataDTOs.FromSqlRaw<UploadAutomateDataDTO>("sp_GET_TRAutomateUploadFileList {0} ,{1}", searchModel.afu_Area, searchModel.afu_machinetype).ToList();
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

        public List<UploadAutomateErrorHeaderListDTO> GetUploadAutomateErrorHeaderListByAfuId(string afu_id)
        {
            log.MethodStart();
            List<UploadAutomateErrorHeaderListDTO> objList = new List<UploadAutomateErrorHeaderListDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.UploadAutomateErrorHeaderListDTOs.FromSqlRaw<UploadAutomateErrorHeaderListDTO>("sp_GET_TRUploadAutomateErrorHeaderList {0}", afu_id).ToList();
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

        public List<UploadAutomateErrorDetailListDTO> GetUploadAutomateErrorDetailListByAfuId(string afu_id)
        {
            log.MethodStart();
            List<UploadAutomateErrorDetailListDTO> objList = new List<UploadAutomateErrorDetailListDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.UploadAutomateErrorDetailListDTOs.FromSqlRaw<UploadAutomateErrorDetailListDTO>("sp_GET_TRUploadAutomateErrorDetailList {0}", afu_id).ToList();
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


        public List<UploadAutomateSummaryHeaderListDTO> GetUploadAutomateSummaryHeaderByAfuId(string afu_id)
        {
            log.MethodStart();
            List<UploadAutomateSummaryHeaderListDTO> objList = new List<UploadAutomateSummaryHeaderListDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.UploadAutomateSummaryHeaderListDTOs.FromSqlRaw<UploadAutomateSummaryHeaderListDTO>("sp_GET_TRUploadAutomateSummaryHeaderList {0}", afu_id).ToList();
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

        public List<UploadAutomateSummaryDetailListDTO> GetUploadAutomateSummaryDetailByAfuId(string fsh_id)
        {
            log.MethodStart();
            List<UploadAutomateSummaryDetailListDTO> objList = new List<UploadAutomateSummaryDetailListDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.UploadAutomateSummaryDetailListDTOs.FromSqlRaw<UploadAutomateSummaryDetailListDTO>("sp_GET_TRUploadAutomateSummaryDetailList {0}", fsh_id).ToList();
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

        public List<UploadAutomateSummaryDetailListDTO> GetUploadAutomateSummaryDetailListByAfuId(string afu_Id)
        {
            log.MethodStart();
            List<UploadAutomateSummaryDetailListDTO> objList = new List<UploadAutomateSummaryDetailListDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.UploadAutomateSummaryDetailListDTOs.FromSqlRaw<UploadAutomateSummaryDetailListDTO>("sp_GET_TRUploadAutomateSummaryDetailListByAfuId {0}", afu_Id).ToList();
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

        public List<UploadAutomateExportErrorDTO> GetUploadAutomateExportError(string[] afu_ids)
        {
            log.MethodStart();
            List<UploadAutomateExportErrorDTO> objList = new List<UploadAutomateExportErrorDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {
                string param = string.Join(",", afu_ids);
                try
                {
                    objList = _db.UploadAutomateExportErrorDTOs.FromSqlRaw<UploadAutomateExportErrorDTO>("sp_GET_TRUploadAutomateErrorDetailAll {0}", param).ToList();
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

        #region ImportMappingAutomateError

        public TRImportMappingLogDTO SaveTRImportMappingAutomateLogData(TRImportMappingLogDTO model)
        {
            log.MethodStart();

            var currentDateTime = DateTime.Now;
            TRImportMappingLogDTO objReturn = new TRImportMappingLogDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objModel = new TRImportMappingLogDTO();
                    objModel = _mapper.Map<TRImportMappingLogDTO>(model);

                    objModel.iml_createdate = currentDateTime;
                    objModel.iml_import_date = currentDateTime;

                    _db.TRImportMappingLogDTOs.Add(objModel);

                    _db.SaveChanges();

                    trans.Commit();

                    objReturn = _mapper.Map<TRImportMappingLogDTO>(objModel);
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

        public List<TempImportUploadAutomateLogDTO> SaveTempImportMappingAutomateLogData(List<TempImportUploadAutomateLogDTO> models)
        {
            log.MethodStart();

            List<TempImportUploadAutomateLogDTO> objReturn = new List<TempImportUploadAutomateLogDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    // Insert Temp table
                    var objModel = new List<TempImportUploadAutomateLogDTO>();
                    objModel = _mapper.Map<List<TempImportUploadAutomateLogDTO>>(models);

                    _db.BulkInsert(models);

                    _db.SaveChanges();

                    var result = _db.Database.ExecuteSqlCommand("exec sp_UPDATE_ImportMappingAutomateError {0}", "SYSTEM");

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

            return objReturn;
        }

        #endregion
    }
}
