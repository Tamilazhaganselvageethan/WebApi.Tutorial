using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class NationalityRepository : GenericRepository<NationalityDetails>, INationalityRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public NationalityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(NationalityDetails entity)
        {
            _dbContect.nationalities_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
