using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class TemporaryPincodeRepository : GenericRepository<TemporaryPincodeDetail>, ITemporaryPincodeRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public TemporaryPincodeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(TemporaryPincodeDetail entity)
        {
            _dbContect.temporaryPincodes_tbl.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
