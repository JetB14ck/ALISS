using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ALISS.STARS.DTO.STARSMapGene;

namespace ALISS.STARS.Library
{
    public interface IStarsAMRMapService
    {
        List<StarsAMRMapGeneDataDTO> GetStarsAMRMapGeneDataWithModel(StarsAMRMapGeneSearchDTO searchModel);

    }
}
