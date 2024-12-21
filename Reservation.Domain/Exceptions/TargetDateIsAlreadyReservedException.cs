using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Domain.Exceptions
{
    public class TargetDateIsAlreadyReservedException : ValidationException
    {
        public TargetDateIsAlreadyReservedException() : this("Specified date is already reserved")
        {
        }

        public TargetDateIsAlreadyReservedException(string? message) : base(message)
        {
        }

        public TargetDateIsAlreadyReservedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
