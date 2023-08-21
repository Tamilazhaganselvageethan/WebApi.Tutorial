using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account_Details_tbl",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_holder_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    account_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_register_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bank_id = table.Column<int>(type: "int", nullable: false),
                    branch_id = table.Column<int>(type: "int", nullable: false),
                    ifsc_code_id = table.Column<int>(type: "int", nullable: false),
                    account_type_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_Details_tbl", x => x.account_id);
                });

            migrationBuilder.CreateTable(
                name: "accountTypeDetails_tbl",
                columns: table => new
                {
                    AccountTypeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccoutTYpeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountTypeDetails_tbl", x => x.AccountTypeid);
                });

            migrationBuilder.CreateTable(
                name: "Address_Detail_tbl",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permanent_line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permanent_line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permanent_line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permanent_land_mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityid = table.Column<int>(type: "int", nullable: false),
                    districtid = table.Column<int>(type: "int", nullable: false),
                    countryid = table.Column<int>(type: "int", nullable: false),
                    pincodeid = table.Column<int>(type: "int", nullable: false),
                    temp_line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    temp_line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    temp_line3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    temp_land_mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    district_id = table.Column<int>(type: "int", nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: false),
                    pincode_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address_Detail_tbl", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "BanknameDetails_tbl",
                columns: table => new
                {
                    bank_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bank_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanknameDetails_tbl", x => x.bank_id);
                });

            migrationBuilder.CreateTable(
                name: "bloodGroups_tbl",
                columns: table => new
                {
                    BG_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Blood_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloodGroups_tbl", x => x.BG_id);
                });

            migrationBuilder.CreateTable(
                name: "BranchNames_tbl",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    branch_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchNames_tbl", x => x.branch_id);
                });

            migrationBuilder.CreateTable(
                name: "cityDetail_tbl",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityDetail_tbl", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "cityDetails_tbl",
                columns: table => new
                {
                    cityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityDetails_tbl", x => x.cityid);
                });

            migrationBuilder.CreateTable(
                name: "collegeDetails_tbl",
                columns: table => new
                {
                    college_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    college_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collegeDetails_tbl", x => x.college_id);
                });

            migrationBuilder.CreateTable(
                name: "Contact_Detail_tbl",
                columns: table => new
                {
                    contact_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contact_no1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_no2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_no3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_tele1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_tele2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    official_mail_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    personal_email_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_Detail_tbl", x => x.contact_id);
                });

            migrationBuilder.CreateTable(
                name: "designationGrades_tbl",
                columns: table => new
                {
                    designation_grade_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    designation_grade_name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designationGrades_tbl", x => x.designation_grade_id);
                });

            migrationBuilder.CreateTable(
                name: "Education_Details_tbl",
                columns: table => new
                {
                    degree_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    degree_type_id = table.Column<int>(type: "int", nullable: false),
                    degree_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    grade_percentage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeId = table.Column<int>(type: "int", nullable: false),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    nationalityid = table.Column<int>(type: "int", nullable: false),
                    gradeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education_Details_tbl", x => x.degree_id);
                });

            migrationBuilder.CreateTable(
                name: "examDetails",
                columns: table => new
                {
                    ExamTypeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_examDetails", x => x.ExamTypeid);
                });

            migrationBuilder.CreateTable(
                name: "Experience_Details_tbl",
                columns: table => new
                {
                    experience_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    exp_duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    company_website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleid = table.Column<int>(type: "int", nullable: false),
                    cityid = table.Column<int>(type: "int", nullable: false),
                    designation_grade_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience_Details_tbl", x => x.experience_id);
                });

            migrationBuilder.CreateTable(
                name: "experienceRoles_tbl",
                columns: table => new
                {
                    roleid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_experienceRoles_tbl", x => x.roleid);
                });

            migrationBuilder.CreateTable(
                name: "Family_Details_tbl",
                columns: table => new
                {
                    familymemberid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    familymembername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    family_member_dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    relationshipid = table.Column<int>(type: "int", nullable: false),
                    occupationid = table.Column<int>(type: "int", nullable: false),
                    member_contact_number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family_Details_tbl", x => x.familymemberid);
                });

            migrationBuilder.CreateTable(
                name: "genderDetails",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genderDetails", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "gradeDetails_tbl",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grade_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradeDetails_tbl", x => x.grade_id);
                });

            migrationBuilder.CreateTable(
                name: "iFSCDetails_tbl",
                columns: table => new
                {
                    ifsc_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ifsc_code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iFSCDetails_tbl", x => x.ifsc_id);
                });

            migrationBuilder.CreateTable(
                name: "leaveDetails",
                columns: table => new
                {
                    LeaveTypeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveDetails", x => x.LeaveTypeid);
                });

            migrationBuilder.CreateTable(
                name: "nationalities_tbl",
                columns: table => new
                {
                    nationalityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nationalityname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationalities_tbl", x => x.nationalityid);
                });

            migrationBuilder.CreateTable(
                name: "nationalityDetails_tbl",
                columns: table => new
                {
                    nationality_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nationality_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationalityDetails_tbl", x => x.nationality_id);
                });

            migrationBuilder.CreateTable(
                name: "occupationDetails_tbl",
                columns: table => new
                {
                    occupation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    occupation_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_occupationDetails_tbl", x => x.occupation_id);
                });

            migrationBuilder.CreateTable(
                name: "permanentCities_tbl",
                columns: table => new
                {
                    cityid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permanentCities_tbl", x => x.cityid);
                });

            migrationBuilder.CreateTable(
                name: "permanentCountries_tbl",
                columns: table => new
                {
                    countryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permanentCountries_tbl", x => x.countryid);
                });

            migrationBuilder.CreateTable(
                name: "permanentDistricts_tbl",
                columns: table => new
                {
                    districtid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    districtname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permanentDistricts_tbl", x => x.districtid);
                });

            migrationBuilder.CreateTable(
                name: "permanetPincodes_tbl",
                columns: table => new
                {
                    pincodeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pincodename = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permanetPincodes_tbl", x => x.pincodeid);
                });

            migrationBuilder.CreateTable(
                name: "Personal_Details_tbl",
                columns: table => new
                {
                    personal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middle_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BGId = table.Column<int>(type: "int", nullable: false),
                    genderId = table.Column<int>(type: "int", nullable: false),
                    religionId = table.Column<int>(type: "int", nullable: false),
                    nationalityId = table.Column<int>(type: "int", nullable: false),
                    Created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified_On = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal_Details_tbl", x => x.personal_id);
                });

            migrationBuilder.CreateTable(
                name: "questionDetails",
                columns: table => new
                {
                    QuestionTypeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuetionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionDetails", x => x.QuestionTypeid);
                });

            migrationBuilder.CreateTable(
                name: "relationshipDetails_tbl",
                columns: table => new
                {
                    relationshipid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    relationshipname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relationshipDetails_tbl", x => x.relationshipid);
                });

            migrationBuilder.CreateTable(
                name: "religionNames_tbl",
                columns: table => new
                {
                    Religionid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Religion_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_religionNames_tbl", x => x.Religionid);
                });

            migrationBuilder.CreateTable(
                name: "StateDetails_tbl",
                columns: table => new
                {
                    state_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateDetails_tbl", x => x.state_id);
                });

            migrationBuilder.CreateTable(
                name: "temporaryCities_tbl",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temporaryCities_tbl", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "temporaryCountries_tbl",
                columns: table => new
                {
                    Country_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temporaryCountries_tbl", x => x.Country_id);
                });

            migrationBuilder.CreateTable(
                name: "temporaryDistricts_tbl",
                columns: table => new
                {
                    district_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    district_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temporaryDistricts_tbl", x => x.district_id);
                });

            migrationBuilder.CreateTable(
                name: "temporaryPincodes_tbl",
                columns: table => new
                {
                    pincode_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pincode_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_temporaryPincodes_tbl", x => x.pincode_id);
                });

            migrationBuilder.CreateTable(
                name: "universityDetails_tbl",
                columns: table => new
                {
                    university_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    university_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universityDetails_tbl", x => x.university_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account_Details_tbl");

            migrationBuilder.DropTable(
                name: "accountTypeDetails_tbl");

            migrationBuilder.DropTable(
                name: "Address_Detail_tbl");

            migrationBuilder.DropTable(
                name: "BanknameDetails_tbl");

            migrationBuilder.DropTable(
                name: "bloodGroups_tbl");

            migrationBuilder.DropTable(
                name: "BranchNames_tbl");

            migrationBuilder.DropTable(
                name: "cityDetail_tbl");

            migrationBuilder.DropTable(
                name: "cityDetails_tbl");

            migrationBuilder.DropTable(
                name: "collegeDetails_tbl");

            migrationBuilder.DropTable(
                name: "Contact_Detail_tbl");

            migrationBuilder.DropTable(
                name: "designationGrades_tbl");

            migrationBuilder.DropTable(
                name: "Education_Details_tbl");

            migrationBuilder.DropTable(
                name: "examDetails");

            migrationBuilder.DropTable(
                name: "Experience_Details_tbl");

            migrationBuilder.DropTable(
                name: "experienceRoles_tbl");

            migrationBuilder.DropTable(
                name: "Family_Details_tbl");

            migrationBuilder.DropTable(
                name: "genderDetails");

            migrationBuilder.DropTable(
                name: "gradeDetails_tbl");

            migrationBuilder.DropTable(
                name: "iFSCDetails_tbl");

            migrationBuilder.DropTable(
                name: "leaveDetails");

            migrationBuilder.DropTable(
                name: "nationalities_tbl");

            migrationBuilder.DropTable(
                name: "nationalityDetails_tbl");

            migrationBuilder.DropTable(
                name: "occupationDetails_tbl");

            migrationBuilder.DropTable(
                name: "permanentCities_tbl");

            migrationBuilder.DropTable(
                name: "permanentCountries_tbl");

            migrationBuilder.DropTable(
                name: "permanentDistricts_tbl");

            migrationBuilder.DropTable(
                name: "permanetPincodes_tbl");

            migrationBuilder.DropTable(
                name: "Personal_Details_tbl");

            migrationBuilder.DropTable(
                name: "questionDetails");

            migrationBuilder.DropTable(
                name: "relationshipDetails_tbl");

            migrationBuilder.DropTable(
                name: "religionNames_tbl");

            migrationBuilder.DropTable(
                name: "StateDetails_tbl");

            migrationBuilder.DropTable(
                name: "temporaryCities_tbl");

            migrationBuilder.DropTable(
                name: "temporaryCountries_tbl");

            migrationBuilder.DropTable(
                name: "temporaryDistricts_tbl");

            migrationBuilder.DropTable(
                name: "temporaryPincodes_tbl");

            migrationBuilder.DropTable(
                name: "universityDetails_tbl");
        }
    }
}
