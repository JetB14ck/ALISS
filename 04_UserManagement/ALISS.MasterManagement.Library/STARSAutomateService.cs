using ALISS.MasterManagement.DTO;
using ALISS.MasterManagement.Library.DataAccess;
using ALISS.MasterManagement.Library.Models;
using AutoMapper;
using Log4NetLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALISS.MasterManagement.Library
{
    public class STARSAutomateService : ISTARSAutomateColumnService
    {
        private static readonly ILogService log = new LogService(typeof(STARSAutomateService));

        private readonly MasterManagementContext _db;
        private readonly IMapper _mapper;
        public STARSAutomateService(MasterManagementContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<STARSAutomateColumnDTO> GetList()
        {
            log.MethodStart();

            List<STARSAutomateColumnDTO> objList = new List<STARSAutomateColumnDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objReturn1 = _db.TCSTARSAutomateColumns.ToList();

                    objList = _mapper.Map<List<STARSAutomateColumnDTO>>(objReturn1);

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

        public List<STARSAutomateColumnDTO> GeColumntList_Active_WithModel(STARSAutomateColumnDTO searchModel)
        {
            log.MethodStart();

            List<STARSAutomateColumnDTO> objList = new List<STARSAutomateColumnDTO>();

            //var searchModel = JsonSerializer.Deserialize<MenuSearchDTO>(param);

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objDataList = _db.TCSTARSAutomateColumns.FromSqlRaw<TCSTARSAutomateColumn>("sp_GET_TCSTARS_Column_Active {0}", searchModel.stc_status).ToList();

                    objList = _mapper.Map<List<STARSAutomateColumnDTO>>(objDataList);

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

        public List<TCSTARS_AntibioticsDTO> GetAntibioticList_Active_WithModel(TCSTARS_AntibioticsDTO searchModel)
        {
            log.MethodStart();

            List<TCSTARS_AntibioticsDTO> objList = new List<TCSTARS_AntibioticsDTO>();

            //var searchModel = JsonSerializer.Deserialize<MenuSearchDTO>(param);

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objDataList = _db.TCSTARS_AntibioticsDTOs.FromSqlRaw<TCSTARS_AntibioticsDTO>("sp_GET_TCSTARS_Antibiotics_Active {0}", searchModel.sta_ant_status).ToList();

                    objList = _mapper.Map<List<TCSTARS_AntibioticsDTO>>(objDataList);

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

        public List<TCSTARSOrganismDTO> GetOrganismList_Active_WithModel(TCSTARSOrganismDTO searchModel)
        {
            log.MethodStart();

            List<TCSTARSOrganismDTO> objList = new List<TCSTARSOrganismDTO>();

            //var searchModel = JsonSerializer.Deserialize<MenuSearchDTO>(param);

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    objList = _db.TCSTARSOrganismDTOs.FromSqlRaw<TCSTARSOrganismDTO>("sp_GET_TCSTARS_Organism_Active").ToList();

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

        public List<TCSTARSGeneDTO> GetGeneList_Active_WithModel(TCSTARSGeneDTO searchModel)
        {
            log.MethodStart();

            List<TCSTARSGeneDTO> objList = new List<TCSTARSGeneDTO>();

            //var searchModel = JsonSerializer.Deserialize<MenuSearchDTO>(param);

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    objList = _db.TCStarsGeneDTOs.FromSqlRaw<TCSTARSGeneDTO>("sp_GET_TCSTARS_Gene_Active").ToList();

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
