using OnlineExam.Domain.Model.Master;
using OnlineExam.Domain.Model.PIMSModel;
using AutoMapper;
using OnlineExam.Domain.Model.AccountDetailModel;
using OnlineExam.Domain.Model.PageDetails;

namespace OnlineExamApi.Project.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountDetails,AccountDetails>().ReverseMap();
            CreateMap<AddressDetails, AddressDetails>().ReverseMap();
            CreateMap<ContactDetails, ContactDetails>().ReverseMap();
            CreateMap<EducationDetails, EducationDetails>().ReverseMap();
            CreateMap<ExperienceDetails, ExperienceDetails>().ReverseMap();
            CreateMap<PersonalDetails, PersonalDetails>().ReverseMap();
            CreateMap<FamilyDetails, FamilyDetails>().ReverseMap();

            CreateMap<BankNameDetails, BankNameDetails>().ReverseMap();
            CreateMap<BranchNameDetails, BranchNameDetails>().ReverseMap();
            CreateMap<IFSCDetail, IFSCDetail>().ReverseMap();
            CreateMap<BloodGroupDetails, BloodGroupDetails>().ReverseMap();
            CreateMap<NationalityDetails, NationalityDetails>().ReverseMap();
            CreateMap<ReligionNameDetail, ReligionNameDetail>().ReverseMap();
            CreateMap<OccupationDetails, OccupationDetails>().ReverseMap();
            CreateMap<RelationshipDetails, RelationshipDetails>().ReverseMap();
            CreateMap<CityDetails, CityDetails>().ReverseMap();
            CreateMap<DesignationGradeDetails, DesignationGradeDetails>().ReverseMap();
            CreateMap<ExperienceRoleDetails, ExperienceRoleDetails>().ReverseMap();
            CreateMap<CityDetail, CityDetail>().ReverseMap();
            CreateMap<CollegeDetails, CollegeDetails>().ReverseMap();
            CreateMap<GradeDetails, GradeDetails>().ReverseMap();
            CreateMap<NationalityDetail, NationalityDetail>().ReverseMap();
            CreateMap<StateDetail, StateDetail>().ReverseMap();
            CreateMap<UniversityDetail, UniversityDetail>().ReverseMap();
            CreateMap<PermanentCityDetail, PermanentCityDetail>().ReverseMap();
            CreateMap<PermanentCountryDetail, PermanentCountryDetail>().ReverseMap();
            CreateMap<PermanentDistrictDetail, PermanentDistrictDetail>().ReverseMap();
            CreateMap<PermanentPincodeDetail, PermanentPincodeDetail>().ReverseMap();
            CreateMap<TemporaryCityDetail, TemporaryCityDetail>().ReverseMap();
            CreateMap<TemporaryCountryDetail, TemporaryCountryDetail>().ReverseMap();
            CreateMap<TemporaryDistrictDetail, TemporaryDistrictDetail>().ReverseMap();
            CreateMap<TemporaryPincodeDetail, TemporaryPincodeDetail>().ReverseMap();
            CreateMap<AccountTypeDetails, AccountTypeDetails>().ReverseMap();
            CreateMap<ExamDetails, ExamDetails>().ReverseMap();
            CreateMap<GenderDetails, GenderDetails>().ReverseMap();
            CreateMap<LeaveDetails, LeaveDetails>().ReverseMap();
            CreateMap<QuestionDetail, QuestionDetail>().ReverseMap();
            CreateMap<M_PageDetails, M_PageDetails>().ReverseMap();
            CreateMap<M_SubPageDetails, M_SubPageDetails>().ReverseMap();
            CreateMap<M_SubPageFields, M_SubPageFields>().ReverseMap();

        }
    }
}
