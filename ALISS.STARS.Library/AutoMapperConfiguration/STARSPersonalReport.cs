using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ALISS.STARS.DTO;
using ALISS.STARS.Library.Models;

namespace ALISS.STARS.Library.AutoMapperConfiguration
{
    public class STARSPersonalReport : Profile
    {
        public STARSPersonalReport()
        {
            CreateMap<TRSTARSPersonalReport, STARSPersonalReportDataDTO>();
            CreateMap<STARSPersonalReportDataDTO, TRSTARSPersonalReport>();
        }
    }
}
