using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Common.Enum
{
    public  enum ResultCodeEnum
    {
        BadRequest = 400,
        NotFound = 404,
        UnAuthorized = 401,
        ForB = 403,
        Ok  = 200,
        InternalService = 500
    }
}
