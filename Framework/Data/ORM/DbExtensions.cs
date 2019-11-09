using Microsoft.Extensions.DependencyInjection;
using Myn.Data.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace Myn.Data.ORM
{
    public static class DbCollectionExtensions
    {
        public static IServiceCollection Addorm(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDbProvider<>), typeof(MysqlProvider<>));
            return services;
        }
    }
}
