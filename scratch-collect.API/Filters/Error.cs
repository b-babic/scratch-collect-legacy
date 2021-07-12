using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using scratch_collect.API.Exceptions;

namespace scratch_collect.API.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ArgumentNullException:
                    context.ModelState.AddModelError("ERROR", context.Exception.Message);
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case DbUpdateException:
                    context.ModelState.AddModelError("ERROR", context.Exception.Message + ", or you can't delete records before deleting records in linked tables.");
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case BadRequestException:
                    context.ModelState.AddModelError("ERROR", context.Exception.Message);
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    context.ModelState.AddModelError("ERROR", "Server error!");
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var list = context.ModelState
                .ToDictionary(x => x.Key ?? "default", y => y.Value.Errors.Select(z => z.ErrorMessage));

            context.Result = new JsonResult(list);
        }
    }
}
