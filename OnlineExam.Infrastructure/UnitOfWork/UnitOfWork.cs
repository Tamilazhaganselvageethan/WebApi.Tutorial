using OnlineExam.Application.Contracts.IPageConfigurationService;
using OnlineExam.Application.Contracts.MasterRepository;
using OnlineExam.Application.Contracts.Presistence;
using OnlineExam.Infrastructure.Common;
using OnlineExam.Infrastructure.Repositories.MasterRepositories;
using OnlineExam.Infrastructure.Repositories.PageConfigurationService;
using OnlineExam.Infrastructure.Repositories.PIMSRepository;

namespace OnlineExam.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            accountDetail = new AccountDetailRepository(_dbContext);
            addressDetail = new AddressDetailRepository(_dbContext);
            contactDetail = new ContectDetailRepository(_dbContext);
            educationDetail = new EducationDetailRepository(_dbContext);
            experienceDetail = new ExperienceDetailRepository(_dbContext);
            personalDetail = new PersonalDetailRepository(_dbContext);
            familyDetail = new FamilyDetailRepository(_dbContext);
            bankName = new BankNameRepository(_dbContext);
            branchName = new BranchNameRepository(_dbContext);
            ifscCode = new IFSCCodeRepository(_dbContext);
            relationshipDetail = new RelationshipDetailRepository(_dbContext);
            occupationDetail = new OccupationDetailRepository(_dbContext);
            designationDetail = new DesignationDetailRepository(_dbContext);
            city = new CityRepository(_dbContext);
            experienceRole = new ExperienceRoleRepository(_dbContext);
            cityDetail = new CityDetailRepository(_dbContext);
            college = new CollegeDetailRepository(_dbContext);
            gradeDetail = new GradeDetailRepository(_dbContext);
            nationalityDetail = new NationalityDetailRepository(_dbContext);
            stateDetail = new StateDetailRepository(_dbContext);
            universityDetail = new UniversityDetailRepository(_dbContext);
            permanentCity = new PermanentCityRepository(_dbContext);
            permanentCountry = new PermanentCountryRepository(_dbContext);
            permanentDistrict = new PermanentDistrictRepository(_dbContext);
            permanentPincode = new PermanentPincodeRepository(_dbContext);
            temporaryCity = new TemporaryCityRepository(_dbContext);
            temporaryCountry = new TemporaryCountryRepository(_dbContext);
            temporaryDistrict = new TemporaryDistrictRepository(_dbContext);
            temporaryPincode = new TemporaryPincodeRepository(_dbContext);
            account = new AccountRepository(_dbContext);
            exam = new ExamRepository(_dbContext);
            leaveRepository = new LeaveRepository(_dbContext);
            questionRepository = new QuestionRepository(_dbContext);
            gender = new GenderRepository(_dbContext);
            bloodGroup = new BloodGroupRepository(_dbContext);
            religionName = new ReligionNameRepository(_dbContext);
            pageDetail = new MPageDetailServices(_dbContext);
            subPageDetail = new SubPageDetailService(_dbContext);
            PageField = new SubPageFieldService(_dbContext);
        }
        public IAccountDetailRepository accountDetail { get; private set; }
        public IAddressDetailRepository addressDetail { get; private set; }
        public IContectDetailRepository contactDetail { get; private set; }
        public IEducationDetailRepository educationDetail { get; private set; }
        public IExperienceDetailRepository experienceDetail { get; private set; }
        public IPersonalDetailRepository personalDetail { get; private set; }
        public IFamilyDetailRepository familyDetail { get; private set; }
        public IBankNameRepository bankName { get; private set; }
        public IBranchNameRepository branchName { get; private set; }
        public IifscCodeRepository ifscCode { get; private set; }
        public IBloodGroupRepository bloodGroup { get; private set; }
        public INationalityRepository nationalityRepository { get; private set; }
        public IReligionNameRepository religionName { get; private set; }
        public IRelationshipDetailRepository relationshipDetail { get; private set; }
        public IOccupationDetailRepository occupationDetail { get; private set; }
        public IDesignationDetailRepository designationDetail { get; private set; }
        public ICityRepository city { get; private set; }
        public IExperienceRoleRepository experienceRole { get; private set; }
        public ICityDetailRepository cityDetail { get; private set; }
        public ICollegeDetailRepository college { get; private set; }
        public IGradeRepository gradeDetail { get; private set; }
        public INationalityDetailRepository nationalityDetail { get; private set; }
        public IStateDetailRepository stateDetail { get; private set; }
        public IUniversityDetailRepository universityDetail { get; private set; }
        public IPermanentCityRepository permanentCity { get; private set; }
        public IPermanentCountryRepository permanentCountry { get; private set; }
        public IPermanentDistrictRepository permanentDistrict { get; private set; }
        public IPermanentPincodeRepository permanentPincode { get; private set; }
        public ITemporaryCityRepository temporaryCity { get; private set; }
        public ITemporaryCountryRepository temporaryCountry { get; private set; }
        public ITemporaryDistrictRepository temporaryDistrict { get; private set; }
        public ITemporaryPincodeRepository temporaryPincode { get; private set; }
        public IAccountTypeRepository account { get; private set; }
        public IExamRepository exam { get; private set; }
        public ILeaveRepository leaveRepository { get; private set; }
        public IQuestionRepository questionRepository { get; private set; }
        public IGenderRepository gender { get; private set; }
        public IMPageDetailService pageDetail { get; private set; }
        public ISubPageDetailService subPageDetail { get; private set; }
        public ISubPageFieldService PageField { get; private set; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }




    }
}
