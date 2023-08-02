using ALISS.STARS.DTO.InspectResult;
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
    public class InspectResultDataService : IInspectResultDataService
    {
        private static readonly ILogService log = new LogService(typeof(InspectResultDataService));

        private readonly STARSContext _db;
        private readonly IMapper _mapper;

        public InspectResultDataService(STARSContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        #region Inspect Result
        public List<InspectResultDataDTO> GetInspectResultList(InspectResultSearchDTO searchModel)
        {
            log.MethodStart();

            List<InspectResultDataDTO> objList = new List<InspectResultDataDTO>();

            //var searchModel = JsonSerializer.Deserialize<RepeatAutomateSearchDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.InspectResultDataDTOs.FromSqlRaw<InspectResultDataDTO>("sp_GET_InspectResultList {0}, {1}, {2}, {3}, {4}, {5}, {6}"
                                                                                                   , searchModel.search_arh_code
                                                                                                   , searchModel.search_hos_code
                                                                                                   , searchModel.search_receive_date_from
                                                                                                   , searchModel.search_receive_date_to
                                                                                                   , searchModel.search_testing_date
                                                                                                   , searchModel.search_automate_filename
                                                                                                   , searchModel.search_repeat_status
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

        public InspectStarsResultDataDTO GetStarsResultModel(string search_starno)
        {
            log.MethodStart();

            InspectStarsResultDataDTO objModel = new InspectStarsResultDataDTO();

            //var searchModel = JsonSerializer.Deserialize<RepeatAutomateSearchDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    var objResult = _db.TRStarsResults.FirstOrDefault(x => x.srr_starsno == search_starno);

                    objModel = _mapper.Map<InspectStarsResultDataDTO>(objResult);

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

        public InspectStarsResultAutomateDataDTO GetStarsResultAutomateModel(string search_starno)
        {
            log.MethodStart();

            InspectStarsResultAutomateDataDTO objModel = new InspectStarsResultAutomateDataDTO();

            //var searchModel = JsonSerializer.Deserialize<RepeatAutomateSearchDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    var objResult = _db.TRStarsResultAutomates.FirstOrDefault(x => x.sra_starsno == search_starno);

                    if (objResult == null)
                    {
                        var objNewModel = new TRStarsResultAutomate()
                        {
                            sra_starsno = search_starno,
                            sra_createduser = "AUTO",
                            sra_createddate = DateTime.Now
                        };

                        _db.TRStarsResultAutomates.Add(objNewModel);

                        _db.SaveChanges();
 
                        objModel = _mapper.Map<InspectStarsResultAutomateDataDTO>(objNewModel);
                    }
                    else
                    {
                        objModel = _mapper.Map<InspectStarsResultAutomateDataDTO>(objResult);
                    }

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

        public InspectStarsResultGeneDataDTO GetStarsResultGeneModel(string search_starno)
        {
            log.MethodStart();

            InspectStarsResultGeneDataDTO objModel = new InspectStarsResultGeneDataDTO();

            //var searchModel = JsonSerializer.Deserialize<RepeatAutomateSearchDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    var objResult = _db.TRStarsResultGenes.FirstOrDefault(x => x.srg_starsno == search_starno);

                    if (objResult == null)
                    {
                        var objNewModel = new TRStarsResultGene()
                        {
                            srg_starsno = search_starno,
                            srg_createduser = "AUTO",
                            srg_createddate = DateTime.Now
                        };

                        _db.TRStarsResultGenes.Add(objNewModel);

                        _db.SaveChanges();
 
                        objModel = _mapper.Map<InspectStarsResultGeneDataDTO>(objNewModel);
                   }
                    else
                    {
                        objModel = _mapper.Map<InspectStarsResultGeneDataDTO>(objResult);
                    }


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

        public InspectResultDataDTO SaveInspectResultData(InspectResultDataDTO model)
        {
            log.MethodStart();

            var currentDateTime = DateTime.Now;
            InspectResultDataDTO objReturn = new InspectResultDataDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objRepeat = _mapper.Map<TRAutomateUploadFile>(model);
                                      
                    //objRepeat.afu_status = model.afu_status;
                    //objRepeat.afu_smp_id = model.afu_smp_id;
                    //objRepeat.afu_arh_code = model.afu_arh_code;
                    //objRepeat.afu_machinetype = model.afu_machinetype;
                    //objRepeat.afu_filename = model.afu_filename;
                    //objRepeat.afu_path = model.afu_path;
                    //objRepeat.afu_totalrecord = model.afu_totalrecord;
                    //objRepeat.afu_repeat_flag = model.afu_repeat_flag;
                    //objRepeat.afu_createdate = DateTime.Now;
                    //objRepeat.afu_repeatdate = DateTime.Now;

                    _db.TRAutomateUploadFiles.Add(objRepeat);

                    _db.SaveChanges();

                    trans.Commit();

                    objReturn = _mapper.Map<InspectResultDataDTO>(model);
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

        public InspectStarsResultDataDTO SaveStarsResultModel(InspectStarsResultDataDTO model)
        {
            log.MethodStart();

            var objModel = _mapper.Map<TRStarsResult>(model);

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objTR = _db.TRStarsResults.FirstOrDefault(x => x.srr_starsno == model.srr_starsno);

                    _mapper.Map(model, objTR);

                    _db.SaveChanges();

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

            return model;
        }

        public InspectStarsResultAutomateDataDTO SaveStarsResultAutomateModel(InspectStarsResultAutomateDataDTO model)
        {
            log.MethodStart();

            var objModel = _mapper.Map<TRStarsResultAutomate>(model);

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objTR = _db.TRStarsResultAutomates.FirstOrDefault(x => x.sra_starsno == model.sra_starsno);

                    _mapper.Map(model, objTR);

                    _db.SaveChanges();

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

            return model;
        }

        public InspectStarsResultGeneDataDTO SaveStarsResultGeneModel(InspectStarsResultGeneDataDTO model)
        {
            log.MethodStart();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objTR = _db.TRStarsResultGenes.FirstOrDefault(x => x.srg_starsno == model.srg_starsno);

                    _mapper.Map(model, objTR);

                    _db.SaveChanges();

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

            return model;
        }

        public InspectStarsResultDataDTO SaveStarsResultRepeatAutomateModel(string search_starno, string username)
        {
            log.MethodStart();

            InspectStarsResultDataDTO objModel = new InspectStarsResultDataDTO();

            //var searchModel = JsonSerializer.Deserialize<RepeatAutomateSearchDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    //var objResult = _db.TRStarsResults.FromSqlRaw("EXEC sp_Save_InspectResultRepeatAutomate {0}, {1}", search_starno, username).ToList();

                    var result = _db.Database.ExecuteSqlCommand("exec sp_Save_InspectResultRepeatAutomate {0}, {1}", search_starno, username);

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

        #endregion
    }
}
