using Reservation.Domain.Contracts;

namespace Reservation.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        IRepository<T> Repository<T>() where T : class;
    }
}