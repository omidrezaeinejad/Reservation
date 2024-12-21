using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Domain.Exceptions
{
    public class DuplicatedKeyException : Exception
    {
        public DuplicatedKeyException()
        {
        }

        public DuplicatedKeyException(string? message) : base(message)
        {
        }

        public DuplicatedKeyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
