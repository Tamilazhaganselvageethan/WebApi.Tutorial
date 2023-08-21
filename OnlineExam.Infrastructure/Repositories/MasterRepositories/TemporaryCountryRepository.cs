using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class TemporaryCountryRepository : GenericRepository<TemporaryCountryDetail>, ITemporaryCountryRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public TemporaryCountryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(TemporaryCountryDetail entity)
        {
            _dbContect.temporaryCountries_tbl.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
