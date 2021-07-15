using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellRepository.ApplicationService
{
    public enum EStatusCode
    {
        NonConfigured,
        NOk,
        Ok = 200,
        BadRequisition = 400,
        Success = 201,
        NotAllowed = 405,
        ImATeaPot = 418
    }
}
