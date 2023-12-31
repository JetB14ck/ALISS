﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Log4NetLibrary;
using ALISS.STARS.Library.DataAccess;
using ALISS.STARS.DTO;
using ALISS.MasterManagement.Library.Models;
using ALISS.STARS.Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using EFCore.BulkExtensions;
using ALISS.LabFileUpload.DTO;

namespace ALISS.STARS.Library
{
    public class ReceiveSampleDataService : IReceiveSampleDataService
    {

        private static readonly ILogService log = new LogService(typeof(STARSMappingDataService));

        private readonly STARSContext _db;
        private readonly IMapper _mapper;

        public ReceiveSampleDataService(STARSContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        #region Receive Sample

        public List<ReceiveSampleListsDTO> GetList()
        {
            log.MethodStart();
            List<ReceiveSampleListsDTO> objList = new List<ReceiveSampleListsDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {
                    objList = _db.ReceiveSampleListsDTOs.FromSqlRaw<ReceiveSampleListsDTO>("sp_GET_TRSTARSResultList").ToList();
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
        public List<ReceiveSampleListsDTO> GetStarsResultList(string Param)
        {
            log.MethodStart();


            List<ReceiveSampleListsDTO> objList = new List<ReceiveSampleListsDTO>();

            var searchModel = JsonSerializer.Deserialize<ReceiveSampleSearchDTO>(Param);

            using (var trans = _db.Database.BeginTransaction())
            {

                try
                {                    
                    objList = _db.ReceiveSampleListsDTOs.FromSqlRaw<ReceiveSampleListsDTO>("sp_GET_TRSTARSResultList {0}, {1}, {2}, {3}", searchModel.srr_boxno, searchModel.srr_arh_code, searchModel.srr_hos_code, searchModel.srr_status.ToString()).ToList(); 
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

        public List<ReceiveSampleListsDTO> SaveReceiveSampleData(List<ReceiveSampleListsDTO> models, string format)
        {
            log.MethodStart();
            List<ReceiveSampleListsDTO> objList = new List<ReceiveSampleListsDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    DateTime currentDate = DateTime.Now;
                    foreach (var model in models)
                    {
                        if (model.str_id != null)
                            continue;
                        var objTRStarsResult = _mapper.Map<TRStarsResult>(model);
                        var objTRStarsReceiveSample = _mapper.Map<TRStarsReceiveSample>(model);

                        objTRStarsResult.srr_updatedate = currentDate;

                        if (model.srr_status == "R")
                        {
                            objTRStarsResult.srr_starsno = GenerateRunningNumber("stars_no", format, objTRStarsResult.srr_arh_code);
                            objTRStarsResult.srr_recvdate = currentDate;
                            objTRStarsResult.srr_recvuser = objTRStarsResult.srr_updateuser;
                            objTRStarsResult.srr_tatdate = currentDate.AddDays(model.arh_days_receive);
                        }

                        if (!string.IsNullOrEmpty(model.str_cancelreason))
                        {
                            objTRStarsResult.srr_status = "J";
                            objTRStarsReceiveSample.str_canceldate = currentDate;
                        }

                        objTRStarsReceiveSample.srr_id = objTRStarsResult.srr_id;
                        objTRStarsReceiveSample.str_starsno = objTRStarsResult.srr_starsno;
                        objTRStarsReceiveSample.str_recvdate = objTRStarsResult.srr_recvdate;
                        objTRStarsReceiveSample.str_tatdate = objTRStarsResult.srr_tatdate;
                        objTRStarsReceiveSample.str_boxno = objTRStarsResult.srr_boxno;
                        objTRStarsReceiveSample.str_hos_code = objTRStarsResult.srr_hos_code;
                        objTRStarsReceiveSample.str_labno = objTRStarsResult.srr_stars_labno;
                        objTRStarsReceiveSample.str_hnno = objTRStarsResult.srr_hnno;
                        objTRStarsReceiveSample.str_idcard = objTRStarsResult.srr_idcard;
                        objTRStarsReceiveSample.str_ident_organism = objTRStarsResult.srr_ident_org_code;
                        objTRStarsReceiveSample.str_ident_organismdesc = objTRStarsResult.srr_ident_organism;
                        objTRStarsReceiveSample.str_specimen = objTRStarsResult.srr_stars_specimen;
                        objTRStarsReceiveSample.str_susp_organism = objTRStarsResult.srr_stars_orgnaism;
                        objTRStarsReceiveSample.str_prename = objTRStarsResult.srr_prename;
                        objTRStarsReceiveSample.str_fullname = objTRStarsResult.srr_name;
                        objTRStarsReceiveSample.str_age = objTRStarsResult.srr_age;
                        objTRStarsReceiveSample.str_receiveflag = objTRStarsResult.srr_status == "R";
                        objTRStarsReceiveSample.str_createdate = currentDate;
                        objTRStarsReceiveSample.str_updatedate = currentDate;
                        objTRStarsReceiveSample.str_createduser = objTRStarsResult.srr_updateuser;
                        objTRStarsReceiveSample.str_updateuser = objTRStarsResult.srr_updateuser;
                        _db.TRStarsReceiveSamples.Add(objTRStarsReceiveSample);

                        _db.TRStarsResults.Update(objTRStarsResult);

                        _db.SaveChanges();

                        objList.Add(_mapper.Map<ReceiveSampleListsDTO>(model));
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

            return objList;
        }

        #endregion

        public string GenerateRunningNumber(string prefix, string format, string special_field = "")
        {
            string result = string.Empty;

            format = format.Replace("DD", DateTime.Now.ToString("dd"));
            format = format.Replace("MM", DateTime.Now.ToString("MM"));
            format = format.Replace("[YYYY]", DateTime.Now.AddYears(543).ToString("yyyy"));
            format = format.Replace("[YY]", DateTime.Now.AddYears(543).ToString("yy"));
            format = format.Replace("YYYY", DateTime.Now.ToString("yyyy"));
            format = format.Replace("YY", DateTime.Now.ToString("yy"));

            if(!string.IsNullOrEmpty(special_field))
            format = format.Replace("[SP]", special_field);

            List<TrRunningNoDTO> listobj = _db.TrRunningNoDTOs.FromSqlRaw<TrRunningNoDTO>("sp_GetRunningNumber {0},{1}", prefix, format).ToList();
            var obj = listobj.FirstOrDefault();

            obj.trn_no++;
            _db.TrRunningNoDTOs.Update(obj);
            _db.SaveChanges();

            if (obj.trn_no != 0)
            {
                format = format.Replace("RRRRRR", string.Format("{0:D6}", obj.trn_no));
                format = format.Replace("RRRRR", string.Format("{0:D5}", obj.trn_no));
                format = format.Replace("RRRR", string.Format("{0:D4}", obj.trn_no));
                format = format.Replace("RRR", string.Format("{0:D3}", obj.trn_no));
                format = format.Replace("RR", string.Format("{0:D2}", obj.trn_no));
                result = format;
            }
            return result;
        }
    }
}


