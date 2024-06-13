using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC1.Models;
using MVC1.Controllers;

namespace MVC1.Filter
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (user)HttpContext.Current.Session["User"];

            if (oUser == null)
            {
                if(filterContext.Controller  is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index"); //ALT +126 ~   --LOGIN
                }


            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index"); //ALT +126 ~   -ENTRO A MI APLICACION
                }
            }



            base.OnActionExecuting(filterContext);
        }
    }
}