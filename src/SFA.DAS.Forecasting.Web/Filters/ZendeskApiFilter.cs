﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using IdentityServer3.Core.Extensions;
using Newtonsoft.Json;
using SFA.DAS.Forecasting.Web.Extensions;

namespace SFA.DAS.Forecasting.Web.Filters
{
    public class ZendeskApiFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            if (controller != null)
            {
                var user = (ClaimsPrincipal)controller.User;
                var accounts = user.GetEmployerAccounts();
                controller.ViewBag.ZendeskApiData = new ZendeskApiData
                {
                    Name = user.GetDisplayName(),
                    Email = user.GetEmailAddress()
                    //Organization = account?.EmployerName
                };
            }

            base.OnActionExecuting(filterContext);
        }

        public class ZendeskApiData
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Organization { get; set; }
        }
    }
}