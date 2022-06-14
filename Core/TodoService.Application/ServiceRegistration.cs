﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TodoService.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
        }
    }
}