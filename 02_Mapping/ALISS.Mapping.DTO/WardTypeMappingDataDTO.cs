﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ALISS.Mapping.DTO
{
    public class WardTypeMappingDataDTO
    {
        public Guid wdm_id { get; set; }
        public char wdm_status { get; set; }
        public bool? wdm_flagdelete { get; set; }
        public Guid wdm_mappingid { get; set; }

        [Required(ErrorMessage = "Ward Type is required")]
        [StringLength(50, ErrorMessage = "Ward Type is too long.")]
        public string wdm_wardtype { get; set; }

        [Required(ErrorMessage = "Ward Description is required")]
        [StringLength(50, ErrorMessage = "Ward Description is too long.")]
        public string wdm_warddesc { get; set; }

        [Required(ErrorMessage = "Local Ward Name is required")]
        [StringLength(200, ErrorMessage = "Local Ward Name is too long.")]
        public string wdm_localwardname { get; set; }
        public string wdm_createuser { get; set; }
        public DateTime? wdm_createdate { get; set; }
        public string wdm_updateuser { get; set; }
        public DateTime? wdm_updatedate { get; set; }

        [Required(ErrorMessage = "Hospital is required")]
        public string wdm_hos_code { get; set; }
    }
}
