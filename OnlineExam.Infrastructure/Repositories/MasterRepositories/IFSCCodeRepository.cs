using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class IFSCCodeRepository : GenericRepository<IFSCDetail>, IifscCodeRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public IFSCCodeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(IFSCDetail entity)
        {
            _dbContect.iFSCDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
