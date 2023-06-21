using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class STARSAntibioticListDTO
    {
        public int sta_ant_id { get; set; }
        public string sta_ant_code { get; set; }
        public string sta_ant_name { get; set; }
        public string sta_ant_MIC { get; set; }
        public string sta_ant_SIR { get; set; }
    }

    public class STARSAntibioticSearchDTO
    {
        public string srr_starsno { get; set; }
        public DateTime? srr_recvdate { get; set; }
        public string srr_ident_organism { get; set; }
    }
}
