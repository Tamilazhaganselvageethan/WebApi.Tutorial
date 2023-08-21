using OnlineExam.Application.Contracts.IPageConfigurationService;
using OnlineExam.Application.Contracts.MasterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Presistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountDetailRepository accountDetail { get; }
        IAddressDetailRepository addressDetail { get; }
        IContectDetailRepository contactDetail { get; }
        IEducationDetailRepository educationDetail { get; }
        IExperienceDetailRepository experienceDetail { get; }
        IPersonalDetailRepository personalDetail { get; }
        IFamilyDetailRepository familyDetail { get; }
        IBankNameRepository bankName { get; }
        IBranchNameRepository branchName { get; }
        IifscCodeRepository ifscCode { get; }
        IBloodGroupRepository bloodGroup { get; }
        INationalityRepository nationalityRepository { get; }
        IReligionNameRepository religionName { get; }
        IOccupationDetailRepository occupationDetail { get; }
        IRelationshipDetailRepository relationshipDetail { get; }
        IExperienceRoleRepository experienceRole { get; }
        IDesignationDetailRepository designationDetail { get; }
        ICityRepository city { get; }
        ICityDetailRepository cityDetail { get; }
        ICollegeDetailRepository college { get; }
        IGradeRepository gradeDetail { get; }
        INationalityDetailRepository nationalityDetail { get; }
        IStateDetailRepository stateDetail { get; }
        IUniversityDetailRepository universityDetail { get; }
        IPermanentCityRepository permanentCity { get; }
        IPermanentCountryRepository permanentCountry { get; }
        IPermanentDistrictRepository permanentDistrict { get; }
        IPermanentPincodeRepository permanentPincode { get; }
        ITemporaryCityRepository temporaryCity { get; }
        ITemporaryCountryRepository temporaryCountry { get; }
        ITemporaryDistrictRepository temporaryDistrict { get; }
        ITemporaryPincodeRepository temporaryPincode { get; }
        IAccountTypeRepository account { get; }
        IExamRepository exam { get; }
        ILeaveRepository leaveRepository { get; }
        IQuestionRepository questionRepository { get; }
        IGenderRepository gender { get; }
        IMPageDetailService pageDetail { get; }
        ISubPageDetailService subPageDetail { get; }
        ISubPageFieldService PageField { get; }
        Task SaveAsync();


    }
}
