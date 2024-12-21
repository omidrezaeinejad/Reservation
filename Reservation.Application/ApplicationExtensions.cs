using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Contracts;
using Reservation.Application.Services;
using Reservation.Domain.Contracts;

namespace Reservation.Application
{
    public static class ApplicationExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped<IMeetingService, MeetingService>();
        }
    }
}
