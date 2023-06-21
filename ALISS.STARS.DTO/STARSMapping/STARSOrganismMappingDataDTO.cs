using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ALISS.STARS.DTO
{
    public class STARSOrganismMappingDataDTO
    {
        public Guid som_id { get; set; }
        public char som_status { get; set; }
        public bool? som_flagdelete { get; set; }
        public Guid som_mappingid { get; set; }

        //[Required(ErrorMessage = "WHONet Code is required")]
        //[StringLength(50, ErrorMessage = "WHONet Code is too long.")]
        public string som_whonetcode { get; set; }

        //[Required(ErrorMessage = "WHONet Description is required")]
        //[StringLength(200, ErrorMessage = "WHONet Description is too long.")]
        public string som_whonetdesc { get; set; }

        [Required(ErrorMessage = "Organism Code is required")]
        [StringLength(50, ErrorMessage = "Organism Code is too long.")]
        public string som_localorganismcode { get; set; }

        [Required(ErrorMessage = "Organism Description is required")]
        [StringLength(200, ErrorMessage = "Organism Description is too long.")]
        public string som_localorganismdesc { get; set; }
        public string som_createuser { get; set; }
        public DateTime? som_createdate { get; set; }
        public string som_updateuser { get; set; }
        public DateTime? som_updatedate { get; set; }
    }
}
