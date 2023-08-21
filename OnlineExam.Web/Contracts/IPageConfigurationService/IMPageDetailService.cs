using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PageDetails;

namespace OnlineExam.Application.Contracts.IPageConfigurationService
{
    public interface IMPageDetailService : IGenericRepository<M_PageDetails>
    {
        Task Update(M_PageDetails entity);
    }
}
