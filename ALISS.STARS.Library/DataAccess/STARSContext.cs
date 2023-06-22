using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ALISS.STARS.DTO;
using ALISS.STARS.Library.Models;
using ALISS.MasterManagement.Library.Models;
using ALISS.LabFileUpload.DTO;
using ALISS.STARS.DTO.RepeatAutomate;

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
        public DbSet<STARSMonitoringListsDTO> STARSMonitoringListsDTOs { get; set; }
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
            builder.Entity<STARSAntibioticListDTO>().HasKey(x => x.sta_ant_id);
            builder.Entity<StarsAutomateResultDTO>().HasNoKey();

            builder.Entity<TRSTARSPersonalReport>().HasKey(x => x.srp_id);
            builder.Entity<TRSTARSPersonalReport>().ToTable("TRStarsPersonalReport");

            #endregion

            #region Upload Automate & Repeat
            builder.Entity<TRAutomateUploadFile>().HasKey(x => x.afu_id);
            builder.Entity<TRAutomateUploadFile>().ToTable("TRAutomateUploadFile");

            builder.Entity<RepeatAutomateDataDTO>().HasNoKey();
            #endregion

            builder.Entity<LogProcess>().HasKey(x => x.log_id);
            builder.Entity<LogProcess>().ToTable("XLogProcess");

            builder.Entity<TrRunningNoDTO>().HasKey(x => x.trn_id);
            builder.Entity<TrRunningNoDTO>().ToTable("TR_RUNNING_NUMBER");

            builder.Entity<STARSMonitoringListsDTO>().HasKey(x => x.srr_id);

            base.OnModelCreating(builder);
        }

    }
}
