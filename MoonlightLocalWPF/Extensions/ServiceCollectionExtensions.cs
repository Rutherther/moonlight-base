using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MoonlightBaseWPF.ViewModels;

namespace MoonlightBaseWPF.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
        }

        public static void AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<MoonlightMainViewModel>();
        }
    }
}
