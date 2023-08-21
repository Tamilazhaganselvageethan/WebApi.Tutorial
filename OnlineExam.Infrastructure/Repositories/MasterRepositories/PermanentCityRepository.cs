using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class PermanentCityRepository : GenericRepository<PermanentCityDetail>, IPermanentCityRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public PermanentCityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(PermanentCityDetail entity)
        {
            _dbContect.permanentCities_tbl.Update(entity);
            _dbContect.SaveChanges();
        }


    }
}
