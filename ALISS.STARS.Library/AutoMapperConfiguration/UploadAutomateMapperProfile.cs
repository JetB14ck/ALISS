
using ALISS.STARS.DTO;
using ALISS.STARS.Library.Models;
using AutoMapper;

public class UploadAutomateMapperProfile : Profile
{
    public UploadAutomateMapperProfile()
    {
        CreateMap<UploadAutomateDataDTO, TRAutomateUploadFile>();
        CreateMap<TRAutomateUploadFile, UploadAutomateDataDTO>();
    }
}