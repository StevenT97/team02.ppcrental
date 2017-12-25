using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TEDU_MVC.Areas.Admin.Models
{
    public class ClearModelErrorsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ModelStateDictionary msd = filterContext.Controller.ViewData.ModelState;
            foreach (var item in msd.Values)
            {
                item.Errors.Clear();
            }
        }
    }
}