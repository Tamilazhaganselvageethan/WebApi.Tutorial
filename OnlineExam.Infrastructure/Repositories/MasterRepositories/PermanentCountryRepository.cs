using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class PermanentCountryRepository : GenericRepository<PermanentCountryDetail>, IPermanentCountryRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public PermanentCountryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(PermanentCountryDetail entity)
        {
            _dbContect.permanentCountries_tbl.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
