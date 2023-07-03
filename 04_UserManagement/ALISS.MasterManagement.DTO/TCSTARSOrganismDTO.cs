using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.MasterManagement.DTO
{
    public class TCSTARSOrganismDTO
    {
        public int sto_id { get; set; }
        public string sto_org_code { get; set; }
        public string sto_org_name { get; set; }
        public string sto_org_gram { get; set; }
        public string sto_org_group { get; set; }
        public string sto_org_genus { get; set; }
        public string sto_org_species { get; set; }
        public string sto_org_remarks { get; set; }
        public bool? sto_org_active { get; set; }
        public string sto_org_createuser { get; set; }
        public DateTime? sto_org_createdate { get; set; }
        public string sto_org_updateuser { get; set; }
        public DateTime? sto_org_updatedate { get; set; }
    }
}
