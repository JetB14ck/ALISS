using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class STARSMonitoringDetailDTO
    {
		public int srr_id { get; set; }
        public string srr_starsno { get; set; }
        public DateTime? srr_recvdate { get; set; }
        public string srr_starsno_ref { get; set; }
        public DateTime? afu_repeatdate { get; set; }
        public string srr_stars_orgnaism { get; set; }
        public string srr_ident_organism { get; set; }
        public string method_ident { get; set; }
        public string specimen_type { get; set; }
        public string method_antibiotic { get; set; }
        public string method_resistance { get; set; }
        public string srr_status { get; set; }
        public string srg_imp_gene { get; set; }
        public string srg_vim_gene { get; set; }
        public string srg_ndm_gene { get; set; }
        public string srg_kpc_gene { get; set; }
        public string srg_oxa_gene { get; set; }
        public string srg_serotype_gene { get; set; }
        public string srg_serogroup_gene { get; set; }
        public string srg_vana_gene { get; set; }
        public string srg_vanb_gene { get; set; }
        public string srg_vanc1_gene { get; set; }
        public string srg_vanc2c3_gene { get; set; }
        public string srg_meca_gene { get; set; }
        public string srg_mecc_gene { get; set; }
        public string srg_mcr1_gene { get; set; }
        public string srg_mcr2_gene { get; set; }
        public string srg_mcr3_gene { get; set; }
        public string srg_mcr4_gene { get; set; }
        public string srg_mcr5_gene { get; set; }
        public string srg_mcr6_gene { get; set; }
        public string srg_mcr7_gene { get; set; }
        public string srg_mcr8_gene { get; set; }
        public string srg_mcr9_gene { get; set; }
        public string srg_mcr10_gene { get; set; }
        public string srg_mcim_gene { get; set; }
        public string x_amk_mic { get; set; }
        public string x_amk_ris { get; set; }
        public string x_amc_mic { get; set; }
        public string x_amc_ris { get; set; }
        public string x_sam_mic { get; set; }
        public string x_sam_ris { get; set; }
        public string x_azm_mic { get; set; }
        public string x_azm_ris { get; set; }
        public string x_fep_mic { get; set; }
        public string x_fep_ris { get; set; }
        public string x_ctx_mic { get; set; }
        public string x_ctx_ris { get; set; }
        public string x_fox_mic { get; set; }
        public string x_fox_ris { get; set; }
        public string x_caz_mic { get; set; }
        public string x_caz_ris { get; set; }
        public string x_cro_mic { get; set; }
        public string x_cro_ris { get; set; }
        public string x_cxm_mic { get; set; }
        public string x_cxm_ris { get; set; }
        public string x_chl_mic { get; set; }
        public string x_chl_ris { get; set; }
        public string x_cip_mic { get; set; }
        public string x_cip_ris { get; set; }
        public string x_cli_mic { get; set; }
        public string x_cli_ris { get; set; }
        public string x_col_mic { get; set; }
        public string x_col_ris { get; set; }
        public string x_dap_mic { get; set; }
        public string x_dap_ris { get; set; }
        public string x_dor_mic { get; set; }
        public string x_dor_ris { get; set; }
        public string x_etp_mic { get; set; }
        public string x_etp_ris { get; set; }
        public string x_ery_mic { get; set; }
        public string x_ery_ris { get; set; }
        public string x_geh_mic { get; set; }
        public string x_geh_ris { get; set; }
        public string x_gen_mic { get; set; }
        public string x_gen_ris { get; set; }
        public string x_ipm_mic { get; set; }
        public string x_ipm_ris { get; set; }
        public string x_lvx_mic { get; set; }
        public string x_lvx_ris { get; set; }
        public string x_lnz_mic { get; set; }
        public string x_lnz_ris { get; set; }
        public string x_mem_mic { get; set; }
        public string x_mem_ris { get; set; }
        public string x_met_mic { get; set; }
        public string x_met_ris { get; set; }
        public string x_mfx_mic { get; set; }
        public string x_mfx_ris { get; set; }
        public string x_net_mic { get; set; }
        public string x_net_ris { get; set; }
        public string x_oxa_mic { get; set; }
        public string x_oxa_ris { get; set; }
        public string x_pen_mic { get; set; }
        public string x_pen_ris { get; set; }
        public string x_tzp_mic { get; set; }
        public string x_tzp_ris { get; set; }
        public string x_sth_mic { get; set; }
        public string x_sth_ris { get; set; }
        public string x_tec_mic { get; set; }
        public string x_tec_ris { get; set; }
        public string x_tcy_mic { get; set; }
        public string x_tcy_ris { get; set; }
        public string x_tgc_mic { get; set; }
        public string x_tgc_ris { get; set; }
        public string x_sxt_mic { get; set; }
        public string x_sxt_ris { get; set; }
        public string x_van_mic { get; set; }
        public string x_van_ris { get; set; }
        public string x_cbde_mic { get; set; }
        public string x_cbde_ris { get; set; }
        public string srr_testuser { get; set; }
        public string srr_approveuser { get; set; }
        public string srr_recvdate_str
        {
            get
            {
                return (srr_recvdate != null) ? srr_recvdate.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string afu_repeatdate_str
        {
            get
            {
                return (afu_repeatdate != null) ? afu_repeatdate.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string srr_status_str
        {
            get
            {
                string objReturn = "";

                if (srr_status == "N") objReturn = "New";
                else if (srr_status == "W") objReturn = "Wait-Inspect";
                else if (srr_status == "G") objReturn = "Transporting";
                else if (srr_status == "V") objReturn = "Received";
                else if (srr_status == "A") objReturn = "Lab Processing";
                else if (srr_status == "R") objReturn = "Received";
                else if (srr_status == "C") objReturn = "Complete";
                else if (srr_status == "J") objReturn = "Reject Sample";
                else if (srr_status == "R") objReturn = "Repeat";

                return objReturn;
            }
        }
    }
}
