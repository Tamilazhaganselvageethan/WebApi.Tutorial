using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class LeaveRepository : GenericRepository<LeaveDetails>, ILeaveRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public LeaveRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }

        public async Task Update(LeaveDetails entity)
        {
            _dbContect.leaveDetails.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
