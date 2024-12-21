using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Contracts;
using Reservation.Domain.Contracts;
using Reservation.Infrastructure.Data;
using Reservation.Infrastructure.Repositories;
using Reservation.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ReservationDbContext>(options =>
                options.UseSqlServer("name=ConnectionStrings:MyAppDatabase"));

            //services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGoogleCalendarService, GoogleCalendarService>();
        }
    }
}
