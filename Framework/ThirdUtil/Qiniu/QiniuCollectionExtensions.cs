using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myn.ThirdUtil.Qiniu
{
    public static class QiniuCollectionExtensions
    {
        public static IServiceCollection AddQiniu(this IServiceCollection services)
        {
            services.AddScoped<IQiniu, Qiniu>();
            return services;
        }
    }
}
