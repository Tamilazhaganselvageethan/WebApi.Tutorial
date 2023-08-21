using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class PermanentDistrictRepository : GenericRepository<PermanentDistrictDetail>, IPermanentDistrictRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public PermanentDistrictRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(PermanentDistrictDetail entity)
        {
            _dbContect.permanentDistricts_tbl.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
