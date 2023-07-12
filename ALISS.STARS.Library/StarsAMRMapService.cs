using System;
using AutoMapper;
using Log4NetLibrary;
using ALISS.STARS.Library.DataAccess;
using ALISS.STARS.DTO;
using ALISS.STARS.Library.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ALISS.STARS.DTO.STARSMapGene;

namespace ALISS.STARS.Library
{
    public class StarsAMRMapService : IStarsAMRMapService
    {
        private static readonly ILogService log = new LogService(typeof(UploadAutomateService));
       
        private readonly STARSContext _db;
        private readonly IMapper _mapper;

        public StarsAMRMapService(STARSContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<StarsAMRMapGeneDataDTO> GetStarsAMRMapGeneDataWithModel(StarsAMRMapGeneSearchDTO searchModel)
        {
            log.MethodStart();

            List<StarsAMRMapGeneDataDTO> objList = new List<StarsAMRMapGeneDataDTO>();


            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objDataList = _db.STARSMapGeneDataDTOs.FromSqlRaw<StarsAMRMapGeneDataDTO>("sp_GET_RPSTARSGeneAMRStrategy {0}, {1}, {2}, {3}, {4}"
                                                                                                    , searchModel.from_month
                                                                                                    , searchModel.to_month
                                                                                                    , searchModel.year_code
                                                                                                    , searchModel.stars_org_code
                                                                                                    , searchModel.stars_gene_code.Replace("-","")
                                                                                                    ).ToList();

                    objList = _mapper.Map<List<StarsAMRMapGeneDataDTO>>(objDataList);

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

        public List<StarAMRMapHosOrganismDataDTO> GetStarsAMRMapOrganismWithModel(StarAMRMapOrganismListDTO searchModel)
        {
            log.MethodStart();

            List<StarAMRMapHosOrganismDataDTO> objList = new List<StarAMRMapHosOrganismDataDTO>();


            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    var objDataList = _db.StarAMRMapHosOrganismDataDTOs.FromSqlRaw<StarAMRMapHosOrganismDataDTO>("sp_GET_RPMapOrganism {0}, {1}, {2}, {3}, {4}, {5}, {6}"
                        , searchModel.from_month
                        , searchModel.to_month
                        , searchModel.from_year_code
                        , searchModel.year_code
                        , searchModel.sap_who_org_code
                        , searchModel.gene_code
                        , searchModel.arh_code
                    ).ToList();

                    objList = _mapper.Map<List<StarAMRMapHosOrganismDataDTO>>(objDataList);

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
