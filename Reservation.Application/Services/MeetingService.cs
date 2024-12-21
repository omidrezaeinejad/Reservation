using Microsoft.EntityFrameworkCore;
using Reservation.Application.Contracts;
using Reservation.Application.Models;
using Reservation.Application.Models.Meeting;
using Reservation.Domain.Contracts;
using Reservation.Domain.Entities;
using Reservation.Domain.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Reservation.Application.Services
{
    public class MeetingService : IMeetingService
    {
        private IUnitOfWork UnitOfWork;
        private IGoogleCalendarService GoogleCalendarService;

        private static int[] ValidStartTimeHours = new[] { 8, 10, 12, 14, 16 }; 

        private static ConcurrentDictionary<string, string> dict = new ConcurrentDictionary<string, string>();

        public MeetingService(IUnitOfWork unitOfWork, IGoogleCalendarService googleCalendarService)
        {
            this.UnitOfWork = unitOfWork;
            this.GoogleCalendarService = googleCalendarService;
        }

        public async Task<ReservationResult> ReserveAsync(ReservationParameters parameters, CancellationToken cancellationToken)
        {
            if (!ValidStartTimeHours.Contains(parameters.StartHour))
                throw new ValidationException($"Acceptable meeting start hours are {string.Join(',', ValidStartTimeHours)}");

            Meeting meeting = new Meeting
            {
                Id = Guid.NewGuid(),
                CreateDateTime = DateTime.Now,
                Date = parameters.Date,
                StartTime = new TimeOnly(parameters.StartHour, 0),
                EndTime = new TimeOnly(parameters.StartHour + 2, 0),
                EmailAddress = parameters.Email,
                Subject = parameters.Subject,
                Description = parameters.Description,
            };

            try
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    UnitOfWork.Repository<Meeting>().Add(meeting);

                    await UnitOfWork.SaveChangesAsync(cancellationToken);

                    await GoogleCalendarService.SubmitEventAsync(new Models.GoogleCalendar.SubmitEventParameters
                    {
                        Title = meeting.Subject,
                        Description = meeting.Description,
                        Start = new DateTime(meeting.Date, meeting.StartTime),
                        End = new DateTime(meeting.Date, meeting.EndTime),
                    }, 
                    cancellationToken);

                    transaction.Complete();
                }
            }
            catch (DuplicatedKeyException)
            {
                throw new TargetDateIsAlreadyReservedException();
            }

            return new ReservationResult
            {
                Id = meeting.Id,
            };
        }
    }
}
