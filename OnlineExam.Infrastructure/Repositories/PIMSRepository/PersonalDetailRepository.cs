using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PIMSModel;
using OnlineExam.Infrastructure.Common;

namespace OnlineExam.Infrastructure.Repositories.PIMSRepository
{
    public class PersonalDetailRepository : GenericRepository<PersonalDetails>, IPersonalDetailRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public PersonalDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }


        public async Task Update(PersonalDetails entity)
        {
            _dbContect.Personal_Details_tbl.Update(entity);
            _dbContect.SaveChanges();
        }

    }
}
