﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class STARSPersonalReportDataModelDTO
    {
        public STARSPersonalReportDataDTO reportData { get; set; }
        public List<STARSPersonalReportSelectListDTO> antibioticData { get; set; }
    }
    public class STARSPersonalReportDataDTO
    {
        public int srp_id { get; set; }
        public string srp_reportno { get; set; }
        [Required(ErrorMessage = "STARS No. is required")]
        public string srp_starsno { get; set; }
        public string srp_hos_code { get; set; }
        public string srp_arh_code { get; set; }
        [Required(ErrorMessage = "ผู้ทดสอบ is required")]
        public string srp_testing_user { get; set; }
        public string srp_testing_userreport { get; set; }
        [Required(ErrorMessage = "ผู้ตรวจสอบ is required")] 
        public string srp_approve_user { get; set; }
        public string srp_approve_userreport { get; set; }
        public string srp_director_name { get; set; }
        public string srp_director_path { get; set; }
        public string srp_director_position { get; set; }
        public string srp_director_position2 { get; set; }
        public string srp_remarks { get; set; }
        public bool? X_AMK_MIC_flag { get; set; }
        public bool? X_AMK_RIS_flag { get; set; }
        public bool? X_AMC_MIC_flag { get; set; }
        public bool? X_AMC_RIS_flag { get; set; }
        public bool? X_AMP_MIC_flag { get; set; }
        public bool? X_AMP_RIS_flag { get; set; }
        public bool? X_SAM_MIC_flag { get; set; }
        public bool? X_SAM_RIS_flag { get; set; }
        public bool? X_AZM_MIC_flag { get; set; }
        public bool? X_AZM_RIS_flag { get; set; }
        public bool? X_FEP_MIC_flag { get; set; }
        public bool? X_FEP_RIS_flag { get; set; }
        public bool? X_CTX_MIC_flag { get; set; }
        public bool? X_CTX_RIS_flag { get; set; }
        public bool? X_FOX_MIC_flag { get; set; }
        public bool? X_FOX_RIS_flag { get; set; }
        public bool? X_CAZ_MIC_flag { get; set; }
        public bool? X_CAZ_RIS_flag { get; set; }
        public bool? X_CRO_MIC_flag { get; set; }
        public bool? X_CRO_RIS_flag { get; set; }
        public bool? X_CXM_MIC_flag { get; set; }
        public bool? X_CXM_RIS_flag { get; set; }
        public bool? X_CHL_MIC_flag { get; set; }
        public bool? X_CHL_RIS_flag { get; set; }
        public bool? X_CIP_MIC_flag { get; set; }
        public bool? X_CIP_RIS_flag { get; set; }
        public bool? X_CLI_MIC_flag { get; set; }
        public bool? X_CLI_RIS_flag { get; set; }
        public bool? X_COL_MIC_flag { get; set; }
        public bool? X_COL_RIS_flag { get; set; }
        public bool? X_CPO_MIC_flag { get; set; }
        public bool? X_CPO_RIS_flag { get; set; }
        public bool? X_CZO_MIC_flag { get; set; }
        public bool? X_CZO_RIS_flag { get; set; }
        public bool? X_CXA_MIC_flag { get; set; }
        public bool? X_CXA_RIS_flag { get; set; }
        public bool? X_CSL_MIC_flag { get; set; }
        public bool? X_CSL_RIS_flag { get; set; }
        public bool? X_DAP_MIC_flag { get; set; }
        public bool? X_DAP_RIS_flag { get; set; }
        public bool? X_DOR_MIC_flag { get; set; }
        public bool? X_DOR_RIS_flag { get; set; }
        public bool? X_ETP_MIC_flag { get; set; }
        public bool? X_ETP_RIS_flag { get; set; }
        public bool? X_ERT_MIC_flag { get; set; }
        public bool? X_ERT_RIS_flag { get; set; }
        public bool? X_ERY_MIC_flag { get; set; }
        public bool? X_ERY_RIS_flag { get; set; }
        public bool? X_FUS_MIC_flag { get; set; }
        public bool? X_FUS_RIS_flag { get; set; }
        public bool? X_FOS_MIC_flag { get; set; }
        public bool? X_FOS_RIS_flag { get; set; }
        public bool? X_GEH_MIC_flag { get; set; }
        public bool? X_GEH_RIS_flag { get; set; }
        public bool? X_GEN_MIC_flag { get; set; }
        public bool? X_GEN_RIS_flag { get; set; }
        public bool? X_IPM_MIC_flag { get; set; }
        public bool? X_IPM_RIS_flag { get; set; }
        public bool? X_LVX_MIC_flag { get; set; }
        public bool? X_LVX_RIS_flag { get; set; }
        public bool? X_LNZ_MIC_flag { get; set; }
        public bool? X_LNZ_RIS_flag { get; set; }
        public bool? X_MEM_MIC_flag { get; set; }
        public bool? X_MEM_RIS_flag { get; set; }
        public bool? X_MFX_MIC_flag { get; set; }
        public bool? X_MFX_RIS_flag { get; set; }
        public bool? X_NET_MIC_flag { get; set; }
        public bool? X_NET_RIS_flag { get; set; }
        public bool? X_OXA_MIC_flag { get; set; }
        public bool? X_OXA_RIS_flag { get; set; }
        public bool? X_PEN_MIC_flag { get; set; }
        public bool? X_PEN_RIS_flag { get; set; }
        public bool? X_TZP_MIC_flag { get; set; }
        public bool? X_TZP_RIS_flag { get; set; }
        public bool? X_RIF_MIC_flag { get; set; }
        public bool? X_RIF_RIS_flag { get; set; }
        public bool? X_STH_MIC_flag { get; set; }
        public bool? X_STH_RIS_flag { get; set; }
        public bool? X_TEC_MIC_flag { get; set; }
        public bool? X_TEC_RIS_flag { get; set; }
        public bool? X_TCY_MIC_flag { get; set; }
        public bool? X_TCY_RIS_flag { get; set; }
        public bool? X_TGC_MIC_flag { get; set; }
        public bool? X_TGC_RIS_flag { get; set; }
        public bool? X_SXT_MIC_flag { get; set; }
        public bool? X_SXT_RIS_flag { get; set; }
        public bool? X_VAN_MIC_flag { get; set; }
        public bool? X_VAN_RIS_flag { get; set; }
        public bool? X_CBDE_MIC_flag { get; set; }
        public bool? X_CBDE_RIS_flag { get; set; }
        public string srp_status { get; set; }
        public string srp_createduser { get; set; }
        public DateTime? srp_createddate { get; set; }
        public string srp_updateuser { get; set; }
        public DateTime? srp_updatedate { get; set; }


        public DateTime? srr_reportdate { get; set; }
        public string srr_reportuser { get; set; }

        public string srp_status_str
        {
            get
            {
                string objReturn = "";

                if (srp_status == "D") objReturn = "Draft";
                else if (srp_status == "A") objReturn = "Complete";
                else if (srp_status == "C") objReturn = "Cancel";

                return objReturn;
            }
        }

        public string srr_reportdate_str
        {
            get
            {
                return (srr_reportdate != null) ? srr_reportdate.Value.ToString("dd/MM/yyyy") : "";
            }
        }
    }

    public class ReportAntibioticModel {
        public string srr_starsno { get; set; }
        public string srr_antibiotic_code { get; set; }
    }

}
