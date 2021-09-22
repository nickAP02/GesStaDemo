using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace GesStaDemo.Filters
{
    public class Authentication_Filter : ActionFilterAttribute
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };

            }
        }

      
    }
    

}