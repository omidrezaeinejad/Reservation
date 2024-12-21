using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Contracts;
using Reservation.Domain.Exceptions;
using Reservation.Infrastructure.Data;

namespace Reservation.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ReservationDbContext _dbContext;
        private readonly IDictionary<Type, dynamic> _repositories;

        public UnitOfWork(ReservationDbContext dbContext)
        {
            _dbContext = dbContext;
            _repositories = new Dictionary<Type, dynamic>();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            var entityType = typeof(T);

            if (_repositories.ContainsKey(entityType))
            {
                return _repositories[entityType];
            }

            var repositoryType = typeof(BaseRepository<>);

            var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

            if (repository == null)
            {
                throw new NullReferenceException("Repository should not be null");
            }

            _repositories.Add(entityType, repository);

            return (IRepository<T>)repository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("duplicate key") ?? false)
                    throw new DuplicatedKeyException();

                throw;
            }
        }
    }
}