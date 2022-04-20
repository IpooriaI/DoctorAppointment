using DoctorAppointment.Infrastructure.Application;

namespace DoctorAppointment.Persistence.EF
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public EFUnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
