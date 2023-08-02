using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ALISS.STARS.DTO;
using ALISS.STARS.Library.Models;
using ALISS.MasterManagement.Library.Models;
using ALISS.LabFileUpload.DTO;
using ALISS.STARS.DTO.RepeatAutomate;
using ALISS.STARS.DTO.STARSMapGene;
using ALISS.STARS.DTO.NarstService;
using ALISS.STARS.DTO.UploadAutomate;
using ALISS.STARS.DTO.InspectResult;

namespace ALISS.STARS.Library.DataAccess
{
    public class STARSContext : DbContext
    {
        public DbSet<LogProcess> LogProcesss { get; set; }
        #region STARSMapping
        public DbSet<TRSTARSMapping> TRSTARSMappings { get; set; }
        public DbSet<STARSMappingListsDTO> STARSMappingListDTOs { get; set; }
        public DbSet<STARSMappingDataDTO> STARSMappingDataDTOs { get; set; }

        public DbSet<TRSTARSWHONetMapping> TRSTARSWHONetMappings { get; set; }
        public DbSet<STARSWHONetMappingListsDTO> STARSWHONetMappingListsDTOs { get; set; }
        public DbSet<STARSWHONetMappingDataDTO> STARSWHONetMappingDataDTOs { get; set; }

        public DbSet<TRSTARSSpecimenMapping> TRSTARSSpecimenMappings { get; set; }
        public DbSet<STARSSpecimenMappingListsDTO> STARSSpecimenMappingListsDTOs { get; set; }
        public DbSet<STARSSpecimenMappingDataDTO> STARSSpecimenMappingDataDTOs { get; set; }


        public DbSet<TRSTARSOrganismMapping> TRSTARSOrganismMappings { get; set; }
        public DbSet<STARSOrganismMappingListsDTO> STARSOrganismMappingListsDTOs { get; set; }
        public DbSet<STARSOrganismMappingDataDTO> STARSOrganismMappingDataDTOs { get; set; }
        public DbSet<NarstServiceDTO> NarstServiceDTOs { get; set; }
        #endregion

        #region Receive Sample

        public DbSet<TRStarsResult> TRStarsResults { get; set; }
        public DbSet<TRStarsReceiveSample> TRStarsReceiveSamples { get; set; }
        public DbSet<ReceiveSampleListsDTO> ReceiveSampleListsDTOs { get; set; }
        public DbSet<TrRunningNoDTO> TrRunningNoDTOs { get; set; }

        #endregion


        #region Upload Automate

        public DbSet<TRAutomateUploadFile> TRAutomateUploadFiles { get; set; }
        public DbSet<UploadAutomateDataDTO> UploadAutomateDataDTOs { get; set; }
        public DbSet<UploadAutomateSummaryHeaderListDTO> UploadAutomateSummaryHeaderListDTOs { get; set; }
        public DbSet<UploadAutomateSummaryDetailListDTO> UploadAutomateSummaryDetailListDTOs { get; set; }
        public DbSet<UploadAutomateErrorHeaderListDTO> UploadAutomateErrorHeaderListDTOs { get; set; }
        public DbSet<UploadAutomateErrorDetailListDTO> UploadAutomateErrorDetailListDTOs { get; set; }
        public DbSet<UploadAutomateAlertSummaryListDTO> UploadAutomateAlertSummaryListDTOs { get; set; }
        public DbSet<UploadAutomateExportErrorDTO> UploadAutomateExportErrorDTOs { get; set; }

        #endregion

        #region STARS Personal Report

        public DbSet<STARSPersonalReportDataDTO> STARSPersonalReportDataDTOs { get; set; }
        public DbSet<STARSPersonalReportExportDTO> STARSPersonalReportExportDTOs { get; set; }
        public DbSet<STARSPersonalReportListDTO> STARSPersonalReportListDTOs { get; set; }
        public DbSet<STARSPersonalReportSelectListDTO> STARSPersonalReportSelectListDTOs { get; set; }
        public DbSet<TRSTARSPersonalReport> TRSTARSPersonalReports { get; set; }
        public DbSet<STARSAntibioticListDTO> STARSAntibioticListDTOs { get; set; }
        public DbSet<StarsAutomateResultDTO> StarsAutomateResultDTOs { get; set; }

        #endregion

        #region  Upload Automate & Repeat
        public DbSet<RepeatAutomateDataDTO> RepeatAutomateDTOs { get; set; }
        #endregion

        #region Stars Monitoring

        public DbSet<STARSMonitoringListsDTO> STARSMonitoringListsDTOs { get; set; }
        public DbSet<STARSMonitoringDetailDTO> STARSMonitoringDetailDTOs { get; set; }

        #endregion

        #region Monthly Gene Report

        public DbSet<MonthlyGeneReportDataDTO> MonthlyGeneReportDataDTOs { get; set; }
        #endregion

        #region Stars AMR Map

        public DbSet<StarsAMRMapGeneDataDTO> STARSMapGeneDataDTOs { get; set; }

        public DbSet<StarAMRMapHosOrganismDataDTO> StarAMRMapHosOrganismDataDTOs { get; set; }
        public DbSet<StarAMRMapHosOrganismSelectDTO> StarAMRMapHosOrganismSelectDTOs { get; set; }
        #endregion

        #region Inspect Result
        public DbSet<InspectResultDataDTO> InspectResultDataDTOs { get; set; }
        public DbSet<TRStarsResultAutomate> TRStarsResultAutomates { get; set; }
        public DbSet<TRStarsResultGene> TRStarsResultGenes { get; set; }
        #endregion

        public STARSContext(DbContextOptions<STARSContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region STARSMapping
            builder.Entity<STARSMappingListsDTO>().HasKey(x => x.smp_id);
            builder.Entity<STARSMappingDataDTO>().HasKey(x => x.smp_id);

            builder.Entity<TRSTARSMapping>().HasKey(x => x.smp_id);
            builder.Entity<TRSTARSMapping>().ToTable("TRStarsMapping");


            builder.Entity<STARSWHONetMappingListsDTO>().HasKey(x => x.swm_id);
            builder.Entity<STARSWHONetMappingDataDTO>().HasKey(x => x.swm_id);

            builder.Entity<TRSTARSWHONetMapping>().HasKey(x => x.swm_id);
            builder.Entity<TRSTARSWHONetMapping>().ToTable("TRStarsWHONetMapping");


            builder.Entity<STARSSpecimenMappingListsDTO>().HasKey(x => x.ssm_id);
            builder.Entity<STARSSpecimenMappingDataDTO>().HasKey(x => x.ssm_id);

            builder.Entity<TRSTARSSpecimenMapping>().HasKey(x => x.ssm_id);
            builder.Entity<TRSTARSSpecimenMapping>().ToTable("TRStarsSpecimenMapping");

            builder.Entity<STARSOrganismMappingListsDTO>().HasKey(x => x.som_id);
            builder.Entity<STARSOrganismMappingDataDTO>().HasKey(x => x.som_id);

            builder.Entity<TRSTARSOrganismMapping>().HasKey(x => x.som_id);
            builder.Entity<TRSTARSOrganismMapping>().ToTable("TRStarsOrganismMapping");

            #endregion

            #region ReceiveSample
            builder.Entity<TRStarsResult>().HasKey(x => x.srr_id);
            builder.Entity<TRStarsResult>().ToTable("TRStarsResult");

            builder.Entity<TRStarsReceiveSample>().HasKey(x => x.str_id);
            builder.Entity<TRStarsReceiveSample>().ToTable("TRStarsReceiveSample");

            builder.Entity<ReceiveSampleListsDTO>().HasKey(x => x.srr_id);
            builder.Entity<ReceiveSampleDataDTO>().HasKey(x => x.srr_id);

            #endregion

            #region Upload Automate

            builder.Entity<UploadAutomateDataDTO>().HasKey(x => x.afu_id);

            builder.Entity<TRAutomateUploadFile>().HasKey(x => x.afu_id);
            builder.Entity<TRAutomateUploadFile>().ToTable("TRAutomateUploadFile");

            builder.Entity<UploadAutomateSummaryHeaderListDTO>().HasKey(x => x.ash_id);
            builder.Entity<UploadAutomateSummaryDetailListDTO>().HasKey(x => x.asd_id);
            builder.Entity<UploadAutomateSummaryHeaderListDTO>()
                .HasMany(h => h.UploadAutomateSummaryDetailLists)
                .WithOne(d => d.UploadAutomateSummaryHeaderList);

            builder.Entity<UploadAutomateSummaryDetailListDTO>()
                .HasOne(d => d.UploadAutomateSummaryHeaderList)
                .WithMany(h => h.UploadAutomateSummaryDetailLists);

            builder.Entity<UploadAutomateErrorHeaderListDTO>().HasKey(x => x.aeh_id);
            builder.Entity<UploadAutomateErrorDetailListDTO>().HasKey(x => x.aed_id);
            builder.Entity<UploadAutomateAlertSummaryListDTO>().HasKey(x => x.plas_id);

            #endregion

            #region STARS Personal Report

            builder.Entity<STARSPersonalReportListDTO>().HasKey(x => x.srp_id);
            builder.Entity<STARSPersonalReportDataDTO>().HasKey(x => x.srp_id);
            builder.Entity<STARSPersonalReportExportDTO>().HasKey(x => x.srp_id);
            builder.Entity<STARSPersonalReportSelectListDTO>().HasKey(x => x.srr_id);
            builder.Entity<STARSAntibioticListDTO>().HasNoKey();
            builder.Entity<StarsAutomateResultDTO>().HasNoKey();

            builder.Entity<TRSTARSPersonalReport>().HasKey(x => x.srp_id);
            builder.Entity<TRSTARSPersonalReport>().ToTable("TRStarsPersonalReport");

            #endregion

            #region Upload Automate & Repeat
            builder.Entity<TRAutomateUploadFile>().HasKey(x => x.afu_id);
            builder.Entity<TRAutomateUploadFile>().ToTable("TRAutomateUploadFile");

            builder.Entity<RepeatAutomateDataDTO>().HasNoKey();
            #endregion

            #region Monthly Gene Report

            builder.Entity<MonthlyGeneReportDataDTO>().HasNoKey();
            #endregion

            #region Stars AMR Map

            builder.Entity<StarsAMRMapGeneDataDTO>().HasNoKey();
            #endregion

            #region Inspect Result

            builder.Entity<InspectResultDataDTO>().HasNoKey();

            builder.Entity<TRStarsResultAutomate>().HasKey(x => x.sra_id);
            builder.Entity<TRStarsResultAutomate>().ToTable("TRStarsResultAutomate");

            builder.Entity<TRStarsResultGene>().HasKey(x => x.srg_id);
            builder.Entity<TRStarsResultGene>().ToTable("TRStarsResultGene");

            #endregion

            builder.Entity<StarAMRMapHosOrganismDataDTO>().HasNoKey();
            builder.Entity<StarAMRMapHosOrganismSelectDTO>().HasNoKey();

            builder.Entity<LogProcess>().HasKey(x => x.log_id);
            builder.Entity<LogProcess>().ToTable("XLogProcess");

            builder.Entity<TrRunningNoDTO>().HasKey(x => x.trn_id);
            builder.Entity<TrRunningNoDTO>().ToTable("TR_RUNNING_NUMBER");

            builder.Entity<STARSMonitoringListsDTO>().HasKey(x => x.srr_id);
            builder.Entity<STARSMonitoringDetailDTO>().HasKey(x => x.srr_id);

            builder.Entity<NarstServiceDTO>().HasNoKey();
            builder.Entity<UploadAutomateExportErrorDTO>().HasNoKey();

            base.OnModelCreating(builder);
        }

    }
}
