using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class ReligionNameRepository : GenericRepository<ReligionNameDetail>, IReligionNameRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public ReligionNameRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(ReligionNameDetail entity)
        {
            _dbContect.religionNames_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
