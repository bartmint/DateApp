﻿using DateApp.Domain.Abstract;
using DateApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DateApp.UI.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultcontext = await next();

            if (!resultcontext.HttpContext.User.Identity.IsAuthenticated) return;

            var username = resultcontext.HttpContext.User.GetUsername();
            var repo = resultcontext.HttpContext.RequestServices.GetService<IUserRepository>();
            var user = await repo.GetUserByUsernameAsync(username);
            user.LastActive = DateTime.Now;
            await repo.SaveAllAsync();

        }
    }
}
//aktualizacja daty ostatniego logowania