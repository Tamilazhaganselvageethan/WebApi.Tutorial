using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class OccupationDetailRepository : GenericRepository<OccupationDetails>, IOccupationDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public OccupationDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(OccupationDetails entity)
        {
            _dbContect.occupationDetails_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
