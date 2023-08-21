using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class PermanentPincodeRepository : GenericRepository<PermanentPincodeDetail>, IPermanentPincodeRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public PermanentPincodeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(PermanentPincodeDetail entity)
        {
            _dbContect.permanetPincodes_tbl.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
