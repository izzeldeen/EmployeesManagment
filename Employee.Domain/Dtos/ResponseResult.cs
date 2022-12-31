using Employee.Domain.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Dtos
{
    public class ResponseResult<T>
    {
        public ResponseResult(ResultCodeEnum resultCode = ResultCodeEnum.BadRequest)
        {
            ResultCode = resultCode;
        }
        public ResultCodeEnum ResultCode { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }


        public void SetSuccess(T data)
        {
            Data = data;
            IsSuccess = true;
            ResultCode = ResultCodeEnum.Ok;
        }
    }
}
