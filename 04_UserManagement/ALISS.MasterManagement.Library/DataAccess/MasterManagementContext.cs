﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ALISS.MasterManagement.Library.Models;
using ALISS.MasterManagement.DTO;

namespace ALISS.MasterManagement.Library.DataAccess
{
    public class MasterManagementContext : DbContext
    {
        public DbSet<TCHospital> TCHospitals { get; set; }

        public DbSet<MasterHospitalDTO> MasterHospitalDTOs { get; set; }

        public DbSet<TRHospital> TRHospitals { get; set; }

        public DbSet<LogProcess> LogProcesss { get; set; }

        public DbSet<TCMasterTemplate> TCMasterTemplates { get; set; }

        public DbSet<TCAntibiotic> TCAntibiotics { get; set; }
        public DbSet<AntibioticDTO> AntibioticDTOs { get; set; }

        public DbSet<TCExpertRule> TCExpertRoles { get; set; }
        public DbSet<ExpertRuleDTO> ExpertRuleDTOs { get; set; }

        public DbSet<TCOrganism> TCOrganisms { get; set; }

        public DbSet<OrganismDTO> OrganismDTOs { get; set; }

        public DbSet<TCQCRange> TCQCRanges { get; set; }
        public DbSet<QCRangeDTO> QCRangeDTOs { get; set; }

        public DbSet<TCSpecimen> TCSpecimens { get; set; }

        public DbSet<TCWardType> TCWardTypes { get; set; }
        public DbSet<TCWHONETColumn> TCWHONETColumns { get; set; }
        public DbSet<TCSTARSAutomateColumn> TCSTARSAutomateColumns { get; set; }
        public DbSet<TCSTARS_AntibioticsDTO> TCSTARS_AntibioticsDTOs { get; set; }
        public DbSet<TCProcessExcelColumnDTO> TCProcessExcelColumnDTOs { get; set; }
        public DbSet<TCProcessExcelRowDTO> TCProcessExcelRowDTOs { get; set; }
        public DbSet<TCProcessExcelTemplateDTO> TCProcessExcelTemplateDTOs { get; set; }
        public DbSet<TCSTARSOrganismDTO> TCSTARSOrganismDTOs { get; set; }
        public DbSet<TCSTARSGeneDTO> TCStarsGeneDTOs { get; set; }

        public MasterManagementContext(DbContextOptions<MasterManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TCHospital>().HasKey(x => x.hos_id);
            builder.Entity<TCHospital>().ToTable("TCHospital");

            builder.Entity<MasterHospitalDTO>().HasKey(x => x.hos_id);

            builder.Entity<TRHospital>().HasKey(x => x.hos_id);
            builder.Entity<TRHospital>().ToTable("TRHospital");

            builder.Entity<LogProcess>().HasKey(x => x.log_id);
            builder.Entity<LogProcess>().ToTable("XLogProcess");

            builder.Entity<TCMasterTemplate>().HasKey(x => x.mst_id);
            builder.Entity<TCMasterTemplate>().ToTable("TCMasterTemplate");

            builder.Entity<TCAntibiotic>().HasKey(x => x.ant_id);
            builder.Entity<TCAntibiotic>().ToTable("TCAntibiotic");

            builder.Entity<AntibioticDTO>().HasKey(x => x.ant_id);

            builder.Entity<TCExpertRule>().HasKey(x => x.exr_id);
            builder.Entity<TCExpertRule>().ToTable("TCExpertRule");
            builder.Entity<ExpertRuleDTO>().HasKey(x => x.exr_id);

            builder.Entity<TCOrganism>().HasKey(x => x.org_id);
            builder.Entity<TCOrganism>().ToTable("TCOrganism");

            builder.Entity<OrganismDTO>().HasKey(x => x.org_id);

            builder.Entity<TCQCRange>().HasKey(x => x.qcr_id);
            builder.Entity<TCQCRange>().ToTable("TCQCRange");
            builder.Entity<QCRangeDTO>().HasKey(x => x.qcr_id);

            builder.Entity<TCSpecimen>().HasKey(x => x.spc_id);
            builder.Entity<TCSpecimen>().ToTable("TCSpecimen");

            builder.Entity<TCWardType>().HasKey(x => x.wrd_id);
            builder.Entity<TCWardType>().ToTable("TCWardType");

            builder.Entity<TCSTARSOrganismDTO>().HasKey(x => x.sto_id);
            builder.Entity<TCSTARSOrganismDTO>().ToTable("TCStarsOrganism");

            builder.Entity<TCSTARSGeneDTO>().HasKey(x => x.sgt_id);
            builder.Entity<TCSTARSGeneDTO>().ToTable("TCStarsGeneDTO");

            builder.Entity<TCWHONETColumn>().HasKey(x => x.wnc_id);
            builder.Entity<TCWHONETColumn>().ToTable("TCWHONETColumn");

            builder.Entity<TCSTARSAutomateColumn>().HasKey(x => x.stc_id);
            builder.Entity<TCSTARSAutomateColumn>().ToTable("TCSTARS_Column");

            builder.Entity<TCSTARS_AntibioticsDTO>().HasKey(x => x.sta_ant_id);
            builder.Entity<TCSTARS_AntibioticsDTO>().ToTable("TCSTARS_Antibiotics");

            builder.Entity<TCProcessExcelColumnDTO>().HasKey(x => x.pec_id);
            builder.Entity<TCProcessExcelColumnDTO>().ToTable("TCProcessExcelColumn");

            builder.Entity<TCProcessExcelRowDTO>().HasKey(x => x.per_id);
            builder.Entity<TCProcessExcelRowDTO>().ToTable("TCProcessExcelRow");

            builder.Entity<TCProcessExcelTemplateDTO>().HasKey(x => x.pet_id);
            builder.Entity<TCProcessExcelTemplateDTO>().ToTable("TCProcessExcelTemplate");

            base.OnModelCreating(builder);
        }
    }
}
