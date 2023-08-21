using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class ExperienceRoleRepository : GenericRepository<ExperienceRoleDetails>, IExperienceRoleRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public ExperienceRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(ExperienceRoleDetails entity)
        {
            _dbContect.experienceRoles_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
