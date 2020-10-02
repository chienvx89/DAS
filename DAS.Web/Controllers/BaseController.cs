using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DAS.Web.Models;
using DAS.Application.Models.CustomModels;
using DAS.Application.Constants;

namespace DAS.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IActionResult JSErrorModelState()
        {
            List<Microsoft.AspNetCore.Mvc.ModelBinding.ModelErrorCollection> modelErrorCollection = ModelState.Select(x => x.Value.Errors)
                       .Where(y => y.Count > 0).ToList();
            string msgErr = string.Empty;
            foreach (var item in modelErrorCollection)
            {
                msgErr = !string.IsNullOrEmpty(msgErr) ? $"{msgErr}\n{item[0].ErrorMessage}" : item[0].ErrorMessage;
            }
            return JSErrorResult(msgErr);
        }

        protected IActionResult CustJSonResult(ServiceResult serviceResult)
        {
            if (serviceResult.Code == CommonConst.Success)
                return JSSuccessResult(serviceResult.Message);
            else if (serviceResult.Code == CommonConst.Error)
                return JSErrorResult(serviceResult.Message);
            else if (serviceResult.Code == CommonConst.Warning)
                return JSWarningResult(serviceResult.Message);
            else return null;
        }

        protected IActionResult JSSuccessResult(string msg)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Success,
                Message = msg
            });
        }

        protected IActionResult JSErrorResult(string msg)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Error,
                Message = msg
            });
        }

        protected IActionResult JSWarningResult(string msg)
        {
            return new JsonResult(new
            {
                Type = CommonConst.Error,
                Message = msg
            });
        }

        protected int GetCurrUser()
        {
            return 1;
        }
    }
}