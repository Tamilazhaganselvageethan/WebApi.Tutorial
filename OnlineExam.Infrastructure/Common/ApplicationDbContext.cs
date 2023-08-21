using Microsoft.EntityFrameworkCore;
using OnlineExam.Domain.Model.AccountDetailModel;
using OnlineExam.Domain.Model.Master;
using OnlineExam.Domain.Model.PageDetails;
using OnlineExam.Domain.Model.PIMSModel;
namespace OnlineExam.Infrastructure.Common
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<AccountDetails> Account_Details_tbl { get; set; }
        public DbSet<AddressDetails> Address_Detail_tbl { get; set; }
        public DbSet<ContactDetails> Contact_Detail_tbl { get; set; }
        public DbSet<EducationDetails> Education_Details_tbl { get; set; }
        public DbSet<ExperienceDetails> Experience_Details_tbl { get; set; }
        public DbSet<FamilyDetails> Family_Details_tbl { get; set; }
        public DbSet<PersonalDetails> Personal_Details_tbl { get; set; }
        public DbSet<BankNameDetails> BanknameDetails_tbl { get; set; }
        public DbSet<BranchNameDetails> BranchNames_tbl { get; set; }
        public DbSet<IFSCDetail> iFSCDetails_tbl { get; set; }
        public DbSet<PermanentCityDetail> permanentCities_tbl { get; set; }
        public DbSet<PermanentCountryDetail> permanentCountries_tbl { get; set; }
        public DbSet<PermanentDistrictDetail> permanentDistricts_tbl { get; set; }
        public DbSet<PermanentPincodeDetail> permanetPincodes_tbl { get; set; }
        public DbSet<TemporaryCityDetail> temporaryCities_tbl { get; set; }
        public DbSet<TemporaryCountryDetail> temporaryCountries_tbl { get; set; }
        public DbSet<TemporaryDistrictDetail> temporaryDistricts_tbl { get; set; }
        public DbSet<TemporaryPincodeDetail> temporaryPincodes_tbl { get; set; }
        public DbSet<CityDetail> cityDetail_tbl { get; set; }
        public DbSet<CollegeDetails> collegeDetails_tbl { get; set; }
        public DbSet<GradeDetails> gradeDetails_tbl { get; set; }
        public DbSet<NationalityDetail> nationalityDetails_tbl { get; set; }
        public DbSet<StateDetail> StateDetails_tbl { get; set; }
        public DbSet<UniversityDetail> universityDetails_tbl { get; set; }
        public DbSet<CityDetails> cityDetails_tbl { get; set; }
        public DbSet<DesignationGradeDetails> designationGrades_tbl { get; set; }
        public DbSet<ExperienceRoleDetails> experienceRoles_tbl { get; set; }
        public DbSet<OccupationDetails> occupationDetails_tbl { get; set; }
        public DbSet<RelationshipDetails> relationshipDetails_tbl { get; set; }
        public DbSet<BloodGroupDetails> bloodGroups_tbl { get; set; }
        public DbSet<NationalityDetails> nationalities_tbl { get; set; }
        public DbSet<ReligionNameDetail> religionNames_tbl { get; set; }
        public DbSet<AccountTypeDetails> accountTypeDetails_tbl { get; set; }
        public DbSet<GenderDetails> genderDetails { get; set; }
        public DbSet<LeaveDetails> leaveDetails { get; set; }
        public DbSet<ExamDetails> examDetails { get; set; }
        public DbSet<QuestionDetail> questionDetails { get; set; }
        public DbSet<M_PageDetails> M_PageDetails_Tbl { get; set; }
        public DbSet<M_SubPageDetails> SubPageDetails { get; set; }
        public DbSet<M_SubPageFields> SubPageField { get; set; }



        //  public DbSet<M_PageField_Details> M_PageFieldDetails_Tbl { get; set; }

    }
}
