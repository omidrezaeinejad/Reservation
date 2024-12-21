using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Application.Models.GoogleCalendar
{
    public class SubmitEventParameters
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
