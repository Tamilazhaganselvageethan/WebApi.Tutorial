using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class BranchNameRepository : GenericRepository<BranchNameDetails>, IBranchNameRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public BranchNameRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(BranchNameDetails entity)
        {
            _dbContect.BranchNames_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
