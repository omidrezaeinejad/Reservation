using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Application.Models.Meeting
{
    public class ReservationParameters
    {
        public DateOnly Date { get; set; }
        public int StartHour { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
