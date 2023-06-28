using System;
using AutoMapper;
using Log4NetLibrary;
using ALISS.STARS.Library.DataAccess;
using ALISS.STARS.DTO;
using ALISS.STARS.Library.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ALISS.MasterManagement.Library.Models;
using Newtonsoft.Json;

namespace ALISS.STARS.Library
{
    public class STARSPersonalReportService : ISTARSPersonalReportService
    {
        private static readonly ILogService log = new LogService(typeof(UploadAutomateService));
       
        private readonly STARSContext _db;
        private readonly IMapper _mapper;

        public STARSPersonalReportService(STARSContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<STARSPersonalReportListDTO> GetSTARSPersonalReportListByModel(STARSPersonalReportSearchDTO searchModel)
        {
            log.MethodStart();

            List<STARSPersonalReportListDTO> objList = new List<STARSPersonalReportListDTO>();                     
            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.STARSPersonalReportListDTOs.FromSqlRaw<STARSPersonalReportListDTO>("sp_GET_STARSPersonalReportList {0} ,{1} ,{2} ,{3} ,{4} ,{5} ,{6} ,{7} ,{8} ,{9} ,{10}"
                            , searchModel.srr_arh_code
                            , searchModel.srr_hos_code
                            , searchModel.srr_starsno
                            , searchModel.srr_reportno
                            , searchModel.srr_status
                            , searchModel.srr_reportdate_from
                            , searchModel.srr_reportdate_to
                            , searchModel.srr_approvedate_from
                            , searchModel.srr_approvedate_to
                            , searchModel.srr_testdate_from
                            , searchModel.srr_testdate_to
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


        public STARSPersonalReportDataDTO GetSTARSPersonalReportDataById(string srp_id)
        {
            log.MethodStart();
            STARSPersonalReportDataDTO objModel = new STARSPersonalReportDataDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    objModel = _db.STARSPersonalReportDataDTOs.FromSqlRaw<STARSPersonalReportDataDTO>("sp_GET_TRSTARSPersonalReportByID {0}", srp_id).AsEnumerable().FirstOrDefault();
                    objModel = objModel ?? new STARSPersonalReportDataDTO();
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

        public STARSPersonalReportExportDTO Get_STARSPersonalReportExportDataById(string srp_id)
        {
            log.MethodStart();
            STARSPersonalReportExportDTO objModel = new STARSPersonalReportExportDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    objModel = _db.STARSPersonalReportExportDTOs.FromSqlRaw<STARSPersonalReportExportDTO>("sp_GET_STARSPersonalReportDataByID {0}", srp_id).AsEnumerable().FirstOrDefault();
                    objModel = objModel ?? new STARSPersonalReportExportDTO();
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

        public StarsAutomateResultDTO Get_StarsAutomateResultDataAsync(string stars_no)
        {
            log.MethodStart();
            StarsAutomateResultDTO objModel = new StarsAutomateResultDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    objModel = _db.StarsAutomateResultDTOs.FromSqlRaw<StarsAutomateResultDTO>("sp_GET_STARSPersonalReportAntibioticByID {0}", stars_no).AsEnumerable().FirstOrDefault();
                    objModel = objModel ?? new StarsAutomateResultDTO();
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

        public STARSPersonalReportDataModelDTO SaveSTARSPersonalReportData(STARSPersonalReportDataModelDTO models, string format)
        {
            log.MethodStart();

            var currentDateTime = DateTime.Now;
            var model = models.reportData;
            STARSPersonalReportDataDTO objReturn = new STARSPersonalReportDataDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    string[] list_stars_no = model.srp_starsno.Split('\n');
                    foreach (string stars_no in list_stars_no)
                    {
                        if (list_stars_no.Length > 1)
                            model.srp_reportno = string.Empty;
                        var objModel = new TRSTARSPersonalReport();

                        if (string.IsNullOrEmpty(model.srp_reportno))
                        {
                            ReceiveSampleDataService receiveSampleDataService = new ReceiveSampleDataService(_db, _mapper);
                            model.srp_reportno = receiveSampleDataService.GenerateRunningNumber("stars_report_no", format, model.srp_arh_code);
                            model.srr_reportdate = currentDateTime;
                            model.srr_reportuser = model.srp_updateuser;

                            var trstarsresult = _db.TRStarsResults.FirstOrDefault(x => x.srr_starsno == stars_no);
                            trstarsresult.srr_reportdate = model.srr_reportdate;
                            trstarsresult.srr_reportno = model.srp_reportno;
                            trstarsresult.srr_updatedate = currentDateTime;
                            trstarsresult.srr_updateuser = model.srp_updateuser;
                            trstarsresult.srr_reportuser = model.srp_updateuser;
                            //_db.TRStarsResults.Update(trstarsresult);
                            _db.SaveChanges();
                        }

                        if (model.srp_id == 0)
                        {
                            objModel = _mapper.Map<TRSTARSPersonalReport>(model);

                            objModel.srp_starsno = stars_no;
                            objModel.srp_createddate = currentDateTime;
                            objModel.srp_updatedate = currentDateTime;

                            updateAntibiotics(ref objModel, models.antibioticData, stars_no);

                            _db.TRSTARSPersonalReports.Add(objModel);
                        }
                        else
                        {
                            objModel = _db.TRSTARSPersonalReports.FirstOrDefault(x => x.srp_id == model.srp_id);
                            objModel.srp_reportno = model.srp_reportno;
                            objModel.srp_starsno = stars_no;
                            objModel.srp_hos_code = model.srp_hos_code;
                            objModel.srp_arh_code = model.srp_arh_code;
                            objModel.srp_testing_user = model.srp_testing_user;
                            objModel.srp_testing_userreport = model.srp_testing_userreport;
                            objModel.srp_approve_user = model.srp_approve_user;
                            objModel.srp_approve_userreport = model.srp_approve_userreport;
                            objModel.srp_director_name = model.srp_director_name;
                            objModel.srp_director_path = model.srp_director_path;
                            objModel.srp_director_position = model.srp_director_position;
                            objModel.srp_director_position2 = model.srp_director_position2;
                            objModel.srp_remarks = model.srp_remarks;
                            objModel.srp_status = model.srp_status;
                            objModel.srp_updatedate = currentDateTime;

                            updateAntibiotics(ref objModel, models.antibioticData, stars_no);
                        }

                        #region Save Log Process ...
                        _db.LogProcesss.Add(new LogProcess()
                        {
                            log_usr_id = (objModel.srp_updateuser ?? objModel.srp_createduser),
                            log_mnu_id = "",
                            log_mnu_name = "PersonalReport",
                            log_tran_id = objModel.srp_id.ToString(),
                            log_action = (objModel.srp_status == "N" ? "New" : "Update"),
                            log_desc = "Update PersonalReport ",
                            log_createuser = "SYSTEM",
                            log_createdate = currentDateTime
                        });
                        #endregion

                        _db.SaveChanges();

                        if (objReturn.srp_id == 0)
                        {
                            objReturn = _mapper.Map<STARSPersonalReportDataDTO>(objModel);
                        }
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

            var result = new STARSPersonalReportDataModelDTO() { reportData = objReturn };

            return result;
        }

        public List<STARSPersonalReportSelectListDTO> GetSTARSPersonalReportSelectListByModel(STARSPersonalReportSelectSearchDTO searchModel)
        {
            log.MethodStart();

            List<STARSPersonalReportSelectListDTO> objList = new List<STARSPersonalReportSelectListDTO>();
            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.STARSPersonalReportSelectListDTOs.FromSqlRaw<STARSPersonalReportSelectListDTO>("sp_GET_STARSPersonalReportSelectList {0} ,{1} ,{2} ,{3}"
                            , searchModel.srr_arh_code
                            , searchModel.srr_hos_code
                            , searchModel.srr_starsno
                            , searchModel.srr_recvdate
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

        public List<STARSAntibioticListDTO> Get_STARSAntibioticListByModel(STARSAntibioticSearchDTO searchModel)
        {
            log.MethodStart();

            List<STARSAntibioticListDTO> objList = new List<STARSAntibioticListDTO>();
            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.STARSAntibioticListDTOs.FromSqlRaw<STARSAntibioticListDTO>("sp_GET_STARSAntibioticSelectList {0}", searchModel.srr_starsno).ToList();
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

        public STARSPersonalReportDataDTO CancelSTARSPersonalReportData(string id, string user)
        {
            log.MethodStart();

            var currentDateTime = DateTime.Now;
            STARSPersonalReportDataDTO objReturn = new STARSPersonalReportDataDTO();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objModel = new TRSTARSPersonalReport();
                    objModel = _db.TRSTARSPersonalReports.FirstOrDefault(x => x.srp_id == int.Parse(id));
                    objModel.srp_updatedate = currentDateTime;
                    objModel.srp_updateuser = user;
                    objModel.srp_status = "C";

                    #region Save Log Process ...
                    _db.LogProcesss.Add(new LogProcess()
                    {
                        log_usr_id = (objModel.srp_updateuser ?? objModel.srp_createduser),
                        log_mnu_id = "",
                        log_mnu_name = "PersonalReport",
                        log_tran_id = objModel.srp_id.ToString(),
                        log_action = "Cancel",
                        log_desc = "Update PersonalReport ",
                        log_createuser = "SYSTEM",
                        log_createdate = currentDateTime
                    });
                    #endregion

                    _db.SaveChanges();
                    objReturn = _mapper.Map<STARSPersonalReportDataDTO>(objModel);

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

            var result = new STARSPersonalReportDataModelDTO() { reportData = objReturn };

            return objReturn;
        }

        private void updateAntibiotics(ref TRSTARSPersonalReport data, List<STARSPersonalReportSelectListDTO> antibioticData, string stars_no)
        {
            if (antibioticData.Any() && !string.IsNullOrEmpty(antibioticData.FirstOrDefault(x => x.srr_starsno == stars_no).srr_addition_antibiotic))
            {
                var antibioticList = antibioticData.FirstOrDefault(x => x.srr_starsno == stars_no).srr_addition_antibiotic.Split(',');
                if (antibioticList.Count() > 0)
                {
                    foreach (var item in antibioticList)
                    {
                        data.GetType().GetProperty(string.Format("X_{0}_MIC_flag", item)).SetValue(data, true);
                        data.GetType().GetProperty(string.Format("X_{0}_RIS_flag", item)).SetValue(data, true);
                    }
                }
            }
            if (antibioticData.Any() && !string.IsNullOrEmpty(antibioticData.FirstOrDefault(x => x.srr_starsno == stars_no).srr_hos_code))
            {
                data.srp_hos_code = antibioticData.FirstOrDefault(x => x.srr_starsno == stars_no).srr_hos_code;
            }
        }
    }
}
