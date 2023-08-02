using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ALISS.STARS.DTO.InspectResult
{
    public class InspectResultDataDTO
    {
        public int srr_id { get; set; }
        public string srr_starsno { get; set; }
        public string srr_starsno_ref { get; set; }
        public string srr_arh_code { get; set; }
        public string srr_hos_code { get; set; }
        public DateTime? srr_recvdate { get; set; }
        public string srr_recvdate_str
        {
            get
            {
                return srr_recvdate != null ? srr_recvdate.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public DateTime? srr_tatdate { get; set; }
        public string srr_tatdate_str
        {
            get
            {
                return srr_tatdate != null ? srr_tatdate.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string srr_receive_organism { get; set; }
        public string srr_status { get; set; }
        public string srr_ident_organism { get; set; }
        public int? srr_mi_id { get; set; }
        public string mi_name { get; set; }
        public string srg_vana_gene { get; set; }
        public string srg_vanb_gene { get; set; }
        public string srg_vanc1_gene { get; set; }
        public string srg_vanc2c3_gene { get; set; }
        public string srg_meca_gene { get; set; }
        public string srg_mecb_gene { get; set; }
        public string srg_mecc_gene { get; set; }
        public string srg_imp_gene { get; set; }
        public string srg_vim_gene { get; set; }
        public string srg_ndm_gene { get; set; }
        public string srg_kpc_gene { get; set; }
        public string srg_oxa_gene { get; set; }
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
        public string srr_status_str
        {
            get
            {
                string objReturn = "";
                if (srr_status == "N") objReturn = "New";
                else if (srr_status == "W") objReturn = "Wait-Inspect";
                else if (srr_status == "P") objReturn = "Pending Approve";
                else if (srr_status == "RG") objReturn = "Repeat Gene";
                else if (srr_status == "T") objReturn = "Repeat Automate";
                else if (srr_status == "E") objReturn = "Cancel";
                else if (srr_status == "A") objReturn = "Approve";
                return objReturn;
            }
        }
    }

    public class InspectResultSearchDTO
    {
        public string search_starsno { get; set; }
        public string search_username { get; set; }
        public string search_arh_code { get; set; }
        public string search_hos_code { get; set; }
        public DateTime? search_receive_date_from { get; set; }
        public DateTime? search_receive_date_to { get; set; }
        public string search_receive_date_from_str
        {
            get
            {
                return search_receive_date_from != null ? search_receive_date_from.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string search_receive_date_to_str
        {
            get
            {
                return search_receive_date_to != null ? search_receive_date_to.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public DateTime? search_testing_date { get; set; }
        public string search_testing_date_str
        {
            get
            {
                return search_testing_date != null ? search_testing_date.Value.ToString("dd/MM/yyyy", new CultureInfo("en-US")) : "";
            }
        }
        public string search_repeat_status { get; set; }
        public string search_automate_filename { get; set; }
        public bool search_show_repeat { get; set; }
    }
}
