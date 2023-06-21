using ALISS.STARS.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ALISS.STARS.DTO.RepeatAutomate;

namespace ALISS.STARS.Library.AutoMapperConfiguration
{
    public class AutomateUploadMapperProfile : Profile
    {
        public AutomateUploadMapperProfile()
        {
            CreateMap<TRAutomateUploadFile, RepeatAutomateDataDTO>();
            CreateMap<RepeatAutomateDataDTO, TRAutomateUploadFile>();

        }
    }
}
