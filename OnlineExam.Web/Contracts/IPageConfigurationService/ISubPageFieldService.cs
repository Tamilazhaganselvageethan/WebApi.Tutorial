using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Domain.Model.PageDetails;


namespace OnlineExam.Application.Contracts.IPageConfigurationService
{
    public interface ISubPageFieldService : IGenericRepository<M_SubPageFields>
    {
        Task Update(M_SubPageFields entity);
    }
}
