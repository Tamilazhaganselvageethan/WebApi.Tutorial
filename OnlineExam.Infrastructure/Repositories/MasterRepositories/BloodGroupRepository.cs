using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class BloodGroupRepository : GenericRepository<BloodGroupDetails>, IBloodGroupRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public BloodGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(BloodGroupDetails entity)
        {
            _dbContect.bloodGroups_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
