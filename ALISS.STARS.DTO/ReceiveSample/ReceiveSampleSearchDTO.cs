﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ALISS.STARS.DTO
{
    public class ReceiveSampleSearchDTO
    {
        public int srr_id { get; set; }
        public string srr_boxno { get; set; }
        public string srr_arh_code { get; set; }
        public string srr_hos_code { get; set; }
        public bool srr_status { get; set; }
        public string srr_starsno { get; set; }
    }
}
