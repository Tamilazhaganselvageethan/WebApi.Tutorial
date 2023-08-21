using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class GenderRepository : GenericRepository<GenderDetails>, IGenderRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public GenderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }

        public async Task Update(GenderDetails entity)
        {
            _dbContect.genderDetails.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
