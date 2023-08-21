﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineExam.Infrastructure.Common;

#nullable disable

namespace OnlineExam.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineExam.Domain.Model.AccountDetailModel.AccountDetails", b =>
                {
                    b.Property<int>("account_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("account_id"));

                    b.Property<string>("account_holder_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("account_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("account_type_id")
                        .HasColumnType("int");

                    b.Property<int>("bank_id")
                        .HasColumnType("int");

                    b.Property<string>("bank_register_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("branch_id")
                        .HasColumnType("int");

                    b.Property<int>("ifsc_code_id")
                        .HasColumnType("int");

                    b.HasKey("account_id");

                    b.ToTable("Account_Details_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.AccountDetailModel.test", b =>
                {
                    b.Property<int>("data")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("data"));

                    b.Property<int?>("AccountDetailsaccount_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("data");

                    b.HasIndex("AccountDetailsaccount_id");

                    b.ToTable("test");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.AccountTypeDetails", b =>
                {
                    b.Property<int>("AccountTypeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountTypeid"));

                    b.Property<string>("AccoutTYpeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountTypeid");

                    b.ToTable("accountTypeDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.BankNameDetails", b =>
                {
                    b.Property<int>("bank_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bank_id"));

                    b.Property<string>("bank_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bank_id");

                    b.ToTable("BanknameDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.BloodGroupDetails", b =>
                {
                    b.Property<int>("BG_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BG_id"));

                    b.Property<string>("Blood_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BG_id");

                    b.ToTable("bloodGroups_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.BranchNameDetails", b =>
                {
                    b.Property<int>("branch_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("branch_id"));

                    b.Property<string>("branch_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("branch_id");

                    b.ToTable("BranchNames_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.CityDetail", b =>
                {
                    b.Property<int>("city_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("city_id"));

                    b.Property<string>("city_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("city_id");

                    b.ToTable("cityDetail_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.CityDetails", b =>
                {
                    b.Property<int>("cityid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cityid"));

                    b.Property<string>("cityname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cityid");

                    b.ToTable("cityDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.CollegeDetails", b =>
                {
                    b.Property<int>("college_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("college_id"));

                    b.Property<string>("college_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("college_id");

                    b.ToTable("collegeDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.DesignationGradeDetails", b =>
                {
                    b.Property<int>("designation_grade_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("designation_grade_id"));

                    b.Property<int>("designation_grade_name")
                        .HasColumnType("int");

                    b.HasKey("designation_grade_id");

                    b.ToTable("designationGrades_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.ExamDetails", b =>
                {
                    b.Property<int>("ExamTypeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamTypeid"));

                    b.Property<string>("ExamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamTypeid");

                    b.ToTable("examDetails");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.ExperienceRoleDetails", b =>
                {
                    b.Property<int>("roleid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleid"));

                    b.Property<string>("rolename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleid");

                    b.ToTable("experienceRoles_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.GenderDetails", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderId"));

                    b.Property<string>("GenderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderId");

                    b.ToTable("genderDetails");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.GradeDetails", b =>
                {
                    b.Property<int>("grade_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("grade_id"));

                    b.Property<string>("grade_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("grade_id");

                    b.ToTable("gradeDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.IFSCDetail", b =>
                {
                    b.Property<int>("ifsc_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ifsc_id"));

                    b.Property<string>("ifsc_code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ifsc_id");

                    b.ToTable("iFSCDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.LeaveDetails", b =>
                {
                    b.Property<int>("LeaveTypeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveTypeid"));

                    b.Property<string>("LeaveTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeaveTypeid");

                    b.ToTable("leaveDetails");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.NationalityDetail", b =>
                {
                    b.Property<int>("nationality_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("nationality_id"));

                    b.Property<string>("nationality_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nationality_id");

                    b.ToTable("nationalityDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.NationalityDetails", b =>
                {
                    b.Property<int>("nationalityid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("nationalityid"));

                    b.Property<string>("nationalityname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nationalityid");

                    b.ToTable("nationalities_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.OccupationDetails", b =>
                {
                    b.Property<int>("occupation_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("occupation_id"));

                    b.Property<string>("occupation_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("occupation_id");

                    b.ToTable("occupationDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.PermanentCityDetail", b =>
                {
                    b.Property<int>("cityid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cityid"));

                    b.Property<string>("city_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cityid");

                    b.ToTable("permanentCities_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.PermanentCountryDetail", b =>
                {
                    b.Property<int>("countryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("countryid"));

                    b.Property<string>("countryname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("countryid");

                    b.ToTable("permanentCountries_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.PermanentDistrictDetail", b =>
                {
                    b.Property<int>("districtid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("districtid"));

                    b.Property<string>("districtname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("districtid");

                    b.ToTable("permanentDistricts_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.PermanentPincodeDetail", b =>
                {
                    b.Property<int>("pincodeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pincodeid"));

                    b.Property<string>("pincodename")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pincodeid");

                    b.ToTable("permanetPincodes_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.QuestionDetail", b =>
                {
                    b.Property<int>("QuestionTypeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionTypeid"));

                    b.Property<string>("QuetionTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionTypeid");

                    b.ToTable("questionDetails");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.RelationshipDetails", b =>
                {
                    b.Property<int>("relationshipid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("relationshipid"));

                    b.Property<string>("relationshipname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("relationshipid");

                    b.ToTable("relationshipDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.ReligionNameDetail", b =>
                {
                    b.Property<int>("Religionid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Religionid"));

                    b.Property<string>("Religion_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Religionid");

                    b.ToTable("religionNames_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.StateDetail", b =>
                {
                    b.Property<int>("state_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("state_id"));

                    b.Property<string>("state_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("state_id");

                    b.ToTable("StateDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.TemporaryCityDetail", b =>
                {
                    b.Property<int>("city_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("city_id"));

                    b.Property<string>("city_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("city_id");

                    b.ToTable("temporaryCities_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.TemporaryCountryDetail", b =>
                {
                    b.Property<int>("Country_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Country_id"));

                    b.Property<string>("Country_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Country_id");

                    b.ToTable("temporaryCountries_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.TemporaryDistrictDetail", b =>
                {
                    b.Property<int>("district_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("district_id"));

                    b.Property<string>("district_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("district_id");

                    b.ToTable("temporaryDistricts_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.TemporaryPincodeDetail", b =>
                {
                    b.Property<int>("pincode_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pincode_id"));

                    b.Property<string>("pincode_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pincode_id");

                    b.ToTable("temporaryPincodes_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.Master.UniversityDetail", b =>
                {
                    b.Property<int>("university_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("university_id"));

                    b.Property<string>("university_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("university_id");

                    b.ToTable("universityDetails_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.PIMSModel.AddressDetails", b =>
                {
                    b.Property<int>("address_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("address_id"));

                    b.Property<int>("city_id")
                        .HasColumnType("int");

                    b.Property<int>("cityid")
                        .HasColumnType("int");

                    b.Property<int>("country_id")
                        .HasColumnType("int");

                    b.Property<int>("countryid")
                        .HasColumnType("int");

                    b.Property<int>("district_id")
                        .HasColumnType("int");

                    b.Property<int>("districtid")
                        .HasColumnType("int");

                    b.Property<string>("permanent_land_mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permanent_line1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permanent_line2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("permanent_line3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pincode_id")
                        .HasColumnType("int");

                    b.Property<int>("pincodeid")
                        .HasColumnType("int");

                    b.Property<string>("temp_land_mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp_line1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp_line2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("temp_line3")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("address_id");

                    b.ToTable("Address_Detail_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.PIMSModel.ContactDetails", b =>
                {
                    b.Property<int>("contact_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("contact_id"));

                    b.Property<string>("contact_no1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_no2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_no3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_tele1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_tele2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("official_mail_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("personal_email_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("contact_id");

                    b.ToTable("Contact_Detail_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.PIMSModel.EducationDetails", b =>
                {
                    b.Property<int>("degree_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("degree_id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CollegeId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.Property<string>("degree_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("degree_type_id")
                        .HasColumnType("int");

                    b.Property<string>("duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("grade_percentage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gradeid")
                        .HasColumnType("int");

                    b.Property<int>("nationalityid")
                        .HasColumnType("int");

                    b.Property<DateTime>("start_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("subject_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("degree_id");

                    b.ToTable("Education_Details_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.PIMSModel.ExperienceDetails", b =>
                {
                    b.Property<int>("experience_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("experience_id"));

                    b.Property<int>("cityid")
                        .HasColumnType("int");

                    b.Property<string>("company_website")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contact_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("designation_grade_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("end_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("exp_duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleid")
                        .HasColumnType("int");

                    b.Property<DateTime>("start_date")
                        .HasColumnType("datetime2");

                    b.HasKey("experience_id");

                    b.ToTable("Experience_Details_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.PIMSModel.FamilyDetails", b =>
                {
                    b.Property<int>("familymemberid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("familymemberid"));

                    b.Property<string>("family_member_dob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("familymembername")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("member_contact_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("occupationid")
                        .HasColumnType("int");

                    b.Property<int>("relationshipid")
                        .HasColumnType("int");

                    b.HasKey("familymemberid");

                    b.ToTable("Family_Details_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.PIMSModel.PersonalDetails", b =>
                {
                    b.Property<int>("personal_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("personal_id"));

                    b.Property<int>("BGId")
                        .HasColumnType("int");

                    b.Property<string>("Created_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_on")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Modified_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified_On")
                        .HasColumnType("datetime2");

                    b.Property<string>("dob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("genderId")
                        .HasColumnType("int");

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middle_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("nationalityId")
                        .HasColumnType("int");

                    b.Property<int>("religionId")
                        .HasColumnType("int");

                    b.HasKey("personal_id");

                    b.ToTable("Personal_Details_tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.PageDetails.M_PageDetails", b =>
                {
                    b.Property<int>("pageid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pageid"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCustom")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PageAliasName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("SequenceNo")
                        .HasColumnType("int");

                    b.HasKey("pageid");

                    b.ToTable("M_PageDetails_Tbl");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.PageDetails.M_SubPageDetails", b =>
                {
                    b.Property<int>("SunpageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SunpageId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCustom")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<int>("PagePath")
                        .HasColumnType("int");

                    b.Property<int>("SequenceNo")
                        .HasColumnType("int");

                    b.Property<string>("SubPageAliasName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubPageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SunpageId");

                    b.ToTable("SubPageDetails");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.PageDetails.M_SubPageFields", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FieldId"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DataFieldTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldAliasName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCustom")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsListData")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SequenceNo")
                        .HasColumnType("int");

                    b.Property<bool>("ShowOnList")
                        .HasColumnType("bit");

                    b.Property<int>("SubPageId")
                        .HasColumnType("int");

                    b.HasKey("FieldId");

                    b.ToTable("SubPageField");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.AccountDetailModel.test", b =>
                {
                    b.HasOne("OnlineExam.Domain.Model.AccountDetailModel.AccountDetails", null)
                        .WithMany("test")
                        .HasForeignKey("AccountDetailsaccount_id");
                });

            modelBuilder.Entity("OnlineExam.Domain.Model.AccountDetailModel.AccountDetails", b =>
                {
                    b.Navigation("test");
                });
#pragma warning restore 612, 618
        }
    }
}
