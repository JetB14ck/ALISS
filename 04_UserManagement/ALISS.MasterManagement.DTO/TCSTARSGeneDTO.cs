using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.MasterManagement.DTO
{
    public class TCSTARSGeneDTO
    {
        public int sgt_id { get; set; }
        public string sgt_gene_code { get; set; }
        public string sgt_gene_name { get; set; }
        public string sgt_remarks { get; set; }
        public bool? sgt_active { get; set; }
        public string sgt_createduser { get; set; }
        public DateTime? sgt_createddate { get; set; }
        public string sgt_updateuser { get; set; }
        public DateTime? sgt_updatedate { get; set; }
    }
}
