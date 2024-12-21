using Reservation.Application.Models.GoogleCalendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Application.Contracts
{
    public interface IGoogleCalendarService
    {
        Task<SubmitEventResult> SubmitEventAsync(SubmitEventParameters parameters, CancellationToken cancellationToken);
    }
}
