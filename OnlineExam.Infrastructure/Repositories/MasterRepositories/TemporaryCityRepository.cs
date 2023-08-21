using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class TemporaryCityRepository : GenericRepository<TemporaryCityDetail>, ITemporaryCityRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public TemporaryCityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(TemporaryCityDetail entity)
        {
            _dbContect.temporaryCities_tbl.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
