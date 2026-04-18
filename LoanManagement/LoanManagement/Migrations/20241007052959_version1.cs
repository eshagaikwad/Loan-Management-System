using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    /// <inheritdoc />
    public partial class version1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "EligibilityCriterias",
                columns: table => new
                {
                    EligibilityCriteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumIncome = table.Column<double>(type: "float", nullable: false),
                    MinimumAge = table.Column<int>(type: "int", nullable: false),
                    MaximumAge = table.Column<int>(type: "int", nullable: false),
                    MinimumCreditScore = table.Column<double>(type: "float", nullable: false),
                    EmploymentYears = table.Column<int>(type: "int", nullable: false),
                    Documents = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibilityCriterias", x => x.EligibilityCriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "LoanOfficers",
                columns: table => new
                {
                    LoanOfficerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanOfficerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanOfficerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanOfficerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanOfficerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficerRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    RegisterationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanOfficers", x => x.LoanOfficerId);
                });

            migrationBuilder.CreateTable(
                name: "LoanSchemes",
                columns: table => new
                {
                    LoanSchemeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanSchemeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAmount = table.Column<double>(type: "float", nullable: false),
                    InterestRate = table.Column<double>(type: "float", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Tenure = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanSchemes", x => x.LoanSchemeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AdminAnalytics",
                columns: table => new
                {
                    AnalyticsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationsCount = table.Column<int>(type: "int", nullable: false),
                    ApprovedLoansCount = table.Column<int>(type: "int", nullable: false),
                    RejectedLoansCount = table.Column<int>(type: "int", nullable: false),
                    TotalLoanAmount = table.Column<double>(type: "float", nullable: false),
                    TotalRepaymentCollected = table.Column<double>(type: "float", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanSchemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAnalytics", x => x.AnalyticsId);
                    table.ForeignKey(
                        name: "FK_AdminAnalytics_LoanSchemes_LoanSchemeId",
                        column: x => x.LoanSchemeId,
                        principalTable: "LoanSchemes",
                        principalColumn: "LoanSchemeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    LoanApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    LoanStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RepaymentStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DocumentFileName1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentUrl1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentFileName2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentVerificationStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NPAStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomineeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NomineePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IFSCCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoanOfficerId = table.Column<int>(type: "int", nullable: false),
                    LoanSchemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.LoanApplicationId);
                    table.ForeignKey(
                        name: "FK_LoanApplications_LoanOfficers_LoanOfficerId",
                        column: x => x.LoanOfficerId,
                        principalTable: "LoanOfficers",
                        principalColumn: "LoanOfficerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplications_LoanSchemes_LoanSchemeId",
                        column: x => x.LoanSchemeId,
                        principalTable: "LoanSchemes",
                        principalColumn: "LoanSchemeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollateralDocuments",
                columns: table => new
                {
                    CollateralDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base64FileContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollateralDocuments", x => x.CollateralDocumentId);
                    table.ForeignKey(
                        name: "FK_CollateralDocuments_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanRepayments",
                columns: table => new
                {
                    LoanRepaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalLoanAmount = table.Column<double>(type: "float", nullable: false),
                    EMIAmount = table.Column<double>(type: "float", nullable: false),
                    PrincipalAmount = table.Column<double>(type: "float", nullable: false),
                    InterestAmount = table.Column<double>(type: "float", nullable: false),
                    PrincipalPaid = table.Column<double>(type: "float", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfInstallments = table.Column<int>(type: "int", nullable: false),
                    LastPaid = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsNPA = table.Column<bool>(type: "bit", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRepayments", x => x.LoanRepaymentId);
                    table.ForeignKey(
                        name: "FK_LoanRepayments_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "LoanApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepaymentHistories",
                columns: table => new
                {
                    PaymentHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountPaid = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoanRepaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepaymentHistories", x => x.PaymentHistoryId);
                    table.ForeignKey(
                        name: "FK_RepaymentHistories_LoanRepayments_LoanRepaymentId",
                        column: x => x.LoanRepaymentId,
                        principalTable: "LoanRepayments",
                        principalColumn: "LoanRepaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminAnalytics_LoanSchemeId",
                table: "AdminAnalytics",
                column: "LoanSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollateralDocuments_LoanApplicationId",
                table: "CollateralDocuments",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_LoanOfficerId",
                table: "LoanApplications",
                column: "LoanOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_LoanSchemeId",
                table: "LoanApplications",
                column: "LoanSchemeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_UserId",
                table: "LoanApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepayments_LoanApplicationId",
                table: "LoanRepayments",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_RepaymentHistories_LoanRepaymentId",
                table: "RepaymentHistories",
                column: "LoanRepaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminAnalytics");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CollateralDocuments");

            migrationBuilder.DropTable(
                name: "EligibilityCriterias");

            migrationBuilder.DropTable(
                name: "RepaymentHistories");

            migrationBuilder.DropTable(
                name: "LoanRepayments");

            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "LoanOfficers");

            migrationBuilder.DropTable(
                name: "LoanSchemes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
