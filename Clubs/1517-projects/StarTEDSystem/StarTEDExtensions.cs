using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using StarTEDSystem.DAL;
using StarTEDSystem.BLL;

namespace StarTEDSystem
{
    public static class StarTEDExtensions
    {
        public static void StarTEDExtensionServices(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<StarTEDContext>(options);

            services.AddTransient<ClubServices>((serviceProvider) =>
                {
                    var context = serviceProvider.GetRequiredService<StarTEDContext>();

                    return new ClubServices(context);
                });

            services.AddTransient<EmployeeServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<StarTEDContext>();

                return new EmployeeServices(context);
            });


        }
        
    }
}
