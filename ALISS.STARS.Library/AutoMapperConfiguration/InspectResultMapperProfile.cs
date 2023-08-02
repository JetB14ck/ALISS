using ALISS.STARS.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ALISS.STARS.DTO.InspectResult;

namespace ALISS.STARS.Library.AutoMapperConfiguration
{
    public class InspectResultMapperProfile : Profile
    {
        public InspectResultMapperProfile()
        {
            CreateMap<TRStarsResult, InspectStarsResultDataDTO>()
                .ReverseMap()
                .ForMember(x => x.srr_id, opt => opt.Ignore());
            CreateMap<TRStarsResultAutomate, InspectStarsResultAutomateDataDTO>()
                .ReverseMap()
                .ForMember(x => x.sra_id, opt => opt.Ignore());
            CreateMap<TRStarsResultGene, InspectStarsResultGeneDataDTO>()
                .ReverseMap()
                .ForMember(x => x.srg_id, opt => opt.Ignore());
        }
    }
}
