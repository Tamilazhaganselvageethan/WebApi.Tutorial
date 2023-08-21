using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class TemporaryDistrictRepository : GenericRepository<TemporaryDistrictDetail>, ITemporaryDistrictRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public TemporaryDistrictRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(TemporaryDistrictDetail entity)
        {
            _dbContect.temporaryDistricts_tbl.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
