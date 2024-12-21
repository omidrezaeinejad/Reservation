using Reservation.Application;
using Reservation.Infrastructure;
using Reservation.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplication();

builder.Services.ConfigureInfrastructure();

builder.Services.AddControllers(config =>
{
    config.Filters.Add<ApiResultFilter>();
});

var app = builder.Build();

app.MapControllers();

app.Run();
