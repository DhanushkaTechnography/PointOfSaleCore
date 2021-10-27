using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PizzaCore.Business.ExceptionHandler
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ArgumentException:
                    context.Result = new BadRequestResult();
                    break;
                case InvalidOperationException:
                    Console.Write(context.Exception);
                    context.Result = new NotFoundResult();
                    break;
                default:
                    break;
            }
        }
    }
}