using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_PageDetails_Tbl",
                columns: table => new
                {
                    pageid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageAliasName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    PagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_PageDetails_Tbl", x => x.pageid);
                });

            migrationBuilder.CreateTable(
                name: "SubPageDetails",
                columns: table => new
                {
                    SunpageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubPageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubPageAliasName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    PagePath = table.Column<int>(type: "int", nullable: false),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPageDetails", x => x.SunpageId);
                });

            migrationBuilder.CreateTable(
                name: "SubPageField",
                columns: table => new
                {
                    FieldId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldAliasName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubPageId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNo = table.Column<int>(type: "int", nullable: false),
                    PagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCustom = table.Column<bool>(type: "bit", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: false),
                    DataFieldTypeId = table.Column<int>(type: "int", nullable: false),
                    IsListData = table.Column<bool>(type: "bit", nullable: false),
                    ShowOnList = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubPageField", x => x.FieldId);
                });

            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    data = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountDetailsaccount_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test", x => x.data);
                    table.ForeignKey(
                        name: "FK_test_Account_Details_tbl_AccountDetailsaccount_id",
                        column: x => x.AccountDetailsaccount_id,
                        principalTable: "Account_Details_tbl",
                        principalColumn: "account_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_test_AccountDetailsaccount_id",
                table: "test",
                column: "AccountDetailsaccount_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "M_PageDetails_Tbl");

            migrationBuilder.DropTable(
                name: "SubPageDetails");

            migrationBuilder.DropTable(
                name: "SubPageField");

            migrationBuilder.DropTable(
                name: "test");
        }
    }
}
