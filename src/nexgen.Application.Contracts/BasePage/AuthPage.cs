using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Application.Contracts.BasePage
{
    public class AuthPage : PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (string.IsNullOrEmpty(context.HttpContext.Request.Headers["authToken"]))
                context.Result = new RedirectToPageResult("UnAuthurized");
            base.OnPageHandlerExecuting(context);
        }
    }
}
