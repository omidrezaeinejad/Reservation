using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.Application.Contracts;
using Reservation.Application.Models;
using Reservation.Application.Models.Meeting;

namespace Reservation.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService MeetingService;

        public MeetingController(IMeetingService meetingService)
        {
            MeetingService = meetingService;
        }

        [HttpPost]
        public async Task<IActionResult> ReserveAsync(ReservationParameters parameters, CancellationToken cancellationToken)
        {
            ReservationResult result = await MeetingService.ReserveAsync(parameters, cancellationToken);
            return Ok(result);
        }
    }
}
