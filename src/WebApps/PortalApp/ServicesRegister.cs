using Microsoft.Extensions.DependencyInjection;
using PortalApp.Services;
using PortalApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalApp
{
    public static class ServicesRegister
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IExamResultService, ExamResultService>();
        }
    }
}
