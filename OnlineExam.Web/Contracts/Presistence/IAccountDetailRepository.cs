using OnlineExam.Domain.Model.AccountDetailModel;
using OnlineExam.Domain.Model.PIMSModel;

namespace OnlineExam.Application.Contracts.Presistence
{
    public interface IAccountDetailRepository : IGenericRepository<AccountDetails>
    {
        Task Update(AccountDetails entity);
    }

}
