using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PageDetails;

namespace OnlineExam.Application.Contracts.IPageConfigurationService
{
    public interface ISubPageDetailService : IGenericRepository<M_SubPageDetails>
    {
        Task Update(M_SubPageDetails entity);
    }
}
