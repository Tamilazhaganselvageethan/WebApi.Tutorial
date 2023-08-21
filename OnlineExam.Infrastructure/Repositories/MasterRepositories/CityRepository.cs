using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Infrastructure.Repositories.MasterRepositories
{
    public class CityRepository : GenericRepository<CityDetail>, ICityRepository
    {
        private readonly ApplicationDbContext _dbContect;

        public CityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContect = dbContext;
        }
        public async Task Update(CityDetail entity)
        {
            _dbContect.cityDetail_tbl.Update(entity);
            _dbContect.SaveChanges();
        }
    }
}
