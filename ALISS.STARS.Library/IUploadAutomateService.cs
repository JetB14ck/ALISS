﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ALISS.Mapping.DTO;
using ALISS.STARS.DTO;
using ALISS.STARS.DTO.UploadAutomate;

namespace ALISS.STARS.Library
{
    public interface IUploadAutomateService
    {
        UploadAutomateDataDTO SaveUploadAutomateData(UploadAutomateDataDTO model);

        UploadAutomateDataDTO GetUploadAutomateDataById(int afu_id);

        List<UploadAutomateDataDTO> GetUploadAutomateListWithModel(UploadAutomateSearchDTO model);

        List<UploadAutomateErrorHeaderListDTO> GetUploadAutomateErrorHeaderListByAfuId(string afu_id);
        List<UploadAutomateErrorDetailListDTO> GetUploadAutomateErrorDetailListByAfuId(string afu_id);
        List<UploadAutomateSummaryHeaderListDTO> GetUploadAutomateSummaryHeaderByAfuId(string afu_id);
        List<UploadAutomateSummaryDetailListDTO> GetUploadAutomateSummaryDetailByAfuId(string fsh_id);
        List<UploadAutomateSummaryDetailListDTO> GetUploadAutomateSummaryDetailListByAfuId(string afu_Id);
        List<UploadAutomateExportErrorDTO> GetUploadAutomateExportError(string[] afu_ids);

        #region ImportMappingAutomateError
        TRImportMappingLogDTO SaveTRImportMappingAutomateLogData(TRImportMappingLogDTO model);
        List<TempImportUploadAutomateLogDTO> SaveTempImportMappingAutomateLogData(List<TempImportUploadAutomateLogDTO> model);
        #endregion
    }
}
