using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Microsoft.Extensions.Configuration;
using Reservation.Application.Contracts;
using Reservation.Application.Models.GoogleCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Infrastructure.Services
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        private string CalendarId;

        public GoogleCalendarService(IConfiguration configuration)
        {
            CalendarId = configuration.GetRequiredSection("GoogleCalendarId").Value ?? "";
        }

        public async Task<SubmitEventResult> SubmitEventAsync(SubmitEventParameters parameters, CancellationToken cancellationToken)
        {
            var credsPath = Path.GetFullPath("google_credentials.json");

            var creds = GoogleCredential.FromFile(credsPath).CreateScoped(CalendarService.Scope.Calendar);

            var calendarService = new CalendarService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = creds,
            });

            var newEvent = await calendarService.Events.Insert(new Google.Apis.Calendar.v3.Data.Event
            {
                Start = new Google.Apis.Calendar.v3.Data.EventDateTime
                {
                    DateTimeDateTimeOffset = parameters.Start,
                },
                End = new Google.Apis.Calendar.v3.Data.EventDateTime
                {
                    DateTimeDateTimeOffset = parameters.End,
                },
                Description = parameters.Description,
                Summary = parameters.Title,

            }, CalendarId).ExecuteAsync(cancellationToken);

            return new SubmitEventResult
            {
                Id = newEvent.Id,
            };
        }
    }
}
