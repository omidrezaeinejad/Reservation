using Reservation.Application.Models;
using Reservation.Application.Models.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Application.Contracts
{
    public interface IMeetingService
    {
        Task<ReservationResult> ReserveAsync(ReservationParameters parameters, CancellationToken cancellationToken);
    }
}
