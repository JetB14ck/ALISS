using ALISS.DropDownList.DTO;
using ALISS.DropDownList.Library.DataAccess;
using AutoMapper;
using Log4NetLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ALISS.DropDownList.Library
{
    public class IdentificationDataService : IIdentificationDataService
    {
        private static readonly ILogService log = new LogService(typeof(MachineTypeDataService));

        private readonly DropDownListContext _db;
        private readonly IMapper _mapper;

        public IdentificationDataService(DropDownListContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<DropDownListDTO> Get_Identification_List(DropDownListDTO searchModel)
        {
            log.MethodStart();

            List<DropDownListDTO> objList = new List<DropDownListDTO>();

            using (var trans = _db.Database.BeginTransaction())
            {
                try
                {
                    objList = _db.DropDownListDTOs.FromSqlRaw<DropDownListDTO>("sp_GET_DDL_Identification").ToList();

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    // TODO: Handle failure
                    trans.Rollback();
                }
                finally
                {
                    trans.Dispose();
                }
            }

            log.MethodFinish();

            return objList;
        }
    }
}
