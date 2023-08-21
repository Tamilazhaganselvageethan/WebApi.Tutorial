using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class StateDetailRepository : GenericRepository<StateDetail>, IStateDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public StateDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(StateDetail entity)
        {
            _dbContect.StateDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
