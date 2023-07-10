﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ALISS.STARS.DTO.STARSMapGene
{
    public class StarsAMRMapGeneDataDTO
    {
        public string org_code { get; set; }
        public string org_name { get; set; }
        public string org_label_name { get; set; }
        public string from_month { get; set; }
        public string to_month { get; set; }
        public string year_code { get; set; }
        public decimal arh_01 { get; set; }
        public decimal arh_02 { get; set; }
        public decimal arh_03 { get; set; }
        public decimal arh_04 { get; set; }
        public decimal arh_05 { get; set; }
        public decimal arh_06 { get; set; }
        public decimal arh_07 { get; set; }
        public decimal arh_08 { get; set; }
        public decimal arh_09 { get; set; }
        public decimal arh_10 { get; set; }
        public decimal arh_11 { get; set; }
        public decimal arh_12 { get; set; }
        public decimal arh_13 { get; set; }
        public int rank_arh_01 { get; set; }
        public int rank_arh_02 { get; set; }
        public int rank_arh_03 { get; set; }
        public int rank_arh_04 { get; set; }
        public int rank_arh_05 { get; set; }
        public int rank_arh_06 { get; set; }
        public int rank_arh_07 { get; set; }
        public int rank_arh_08 { get; set; }
        public int rank_arh_09 { get; set; }
        public int rank_arh_10 { get; set; }
        public int rank_arh_11 { get; set; }
        public int rank_arh_12 { get; set; }
        public int rank_arh_13 { get; set; }
    }

    public class StarsAMRMapGeneSearchDTO
    {
        public string from_month { get; set; }
        public string to_month { get; set; }
        public string year_code { get; set; }
        public string stars_org_code { get; set; }
        public string stars_gene_code { get; set; }
    }
}