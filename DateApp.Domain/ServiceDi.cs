﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateApp.Domain
{
    public static class ServiceDi
    {
        public static IServiceCollection Domain(this IServiceCollection service)
        {
            return service;
        }
    }
}
