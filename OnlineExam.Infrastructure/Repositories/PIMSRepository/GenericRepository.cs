using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.AccountDetailModel;
using OnlineExam.Domain.Model.PIMSModel;
using OnlineExam.Infrastructure.Common;

namespace OnlineExam.Infrastructure.Repositories.PIMSRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task Create(T entity)
        {
            await _dbContext.AddAsync(entity);
            await Save();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        //public async Task<List<cus>> GetAllcus()
        //{
        //    List<cus> _cus = new List<cus>();
        //    var add = await _dbContext.Set<AddressDetails>().ToListAsync();
        //    var scc = await _dbContext.Set<AccountDetails>().ToListAsync();
        //    return await _dbContext.Set<cus>().ToListAsync();
        //}

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        // public async Task<T> GetAllcus()
        //{
        //    List<cus> _cus = new List<cus>();
        //    var add = await _dbContext.Set<AddressDetails>().ToListAsync();
        //    var scc = await _dbContext.Set<AccountDetails>().ToListAsync();

        //    //foreach (var cus in add)
        //    //{
        //    //    _cus.AddRange(add);
        //    //}
        //    return _cus();
        //}
    }
}
