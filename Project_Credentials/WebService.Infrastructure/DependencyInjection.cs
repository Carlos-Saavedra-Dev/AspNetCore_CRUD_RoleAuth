using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Core.Integrations;
using WebService.Core.Interfaces;
using WebService.Domain.Interfaces;
using WebService.Infrastructure.DataAccess;

namespace WebService.Infrastructure
{
    public class DependencyInjection
    {

        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRolRepository, RolRepository>();




        }
    }
}
