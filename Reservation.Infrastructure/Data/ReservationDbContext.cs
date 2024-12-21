using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Entities;

namespace Reservation.Infrastructure.Data
{
    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options) : base(options)
        { 
        
        }

        public DbSet<Meeting> Meetings { get; set; }
    }
}
