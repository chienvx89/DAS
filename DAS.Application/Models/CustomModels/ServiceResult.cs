using DAS.Application.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAS.Application.Models.CustomModels
{
    public class ServiceResult
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class ServiceResultSucess : ServiceResult
    {
        public ServiceResultSucess(string msg)
        {
            Code = CommonConst.Success;
            Message = msg;
        }
    }

    public class ServiceResultError : ServiceResult
    {
        public ServiceResultError(string msg)
        {
            Code = CommonConst.Error;
            Message = msg;
        }
    }
}