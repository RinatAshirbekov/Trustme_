using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Trustme_.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookMarksReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMarksReviews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Complaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complaints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    ApiUrl = table.Column<string>(type: "text", nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    NameService = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IntegrationLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceName = table.Column<string>(type: "text", nullable: true),
                    Parametres = table.Column<string>(type: "text", nullable: true),
                    Values = table.Column<string>(type: "text", nullable: true),
                    ResponseBody = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Okeds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Okeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Verified = table.Column<bool>(type: "boolean", nullable: false),
                    AddressComment = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Payments = table.Column<string>(type: "text", nullable: true),
                    PostCode = table.Column<string>(type: "text", nullable: true),
                    WebSite = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "'0001-01-01 00:00:00'::timestamp without time zone"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "'0001-01-01 00:00:00'::timestamp without time zone")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FIO = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ComplaintId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CommentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintComments_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComplaintId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintCompanies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintCompanies_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComplaintId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintPersons_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComplaintId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintReviews_Complaints_ComplaintId",
                        column: x => x.ComplaintId,
                        principalTable: "Complaints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RegionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    TypeUser = table.Column<int>(type: "integer", nullable: false),
                    TrustPoint = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    PhoneVerification = table.Column<bool>(type: "boolean", nullable: false),
                    VerificationCode = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Reputation = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "'0001-01-01 00:00:00'::timestamp without time zone"),
                    Citizenship = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Education = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Hobby = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    Profession = table.Column<string>(type: "text", nullable: true),
                    UserStatus = table.Column<int>(type: "integer", nullable: false),
                    WorkExperience = table.Column<string>(type: "text", nullable: true),
                    IIN = table.Column<string>(type: "text", nullable: true),
                    VerifiedIin = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<int>(type: "integer", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    BIN = table.Column<string>(type: "text", nullable: true),
                    NameRU = table.Column<string>(type: "text", nullable: true),
                    NameKZ = table.Column<string>(type: "text", nullable: true),
                    NameEN = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    WebSite = table.Column<string>(type: "text", nullable: true),
                    KATO = table.Column<string>(type: "text", nullable: true),
                    DateReg = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: false),
                    OkedId = table.Column<long>(type: "bigint", nullable: false),
                    VisitCount = table.Column<int>(type: "integer", nullable: false),
                    CustomerRating = table.Column<double>(type: "double precision", nullable: false),
                    EmployerRating = table.Column<double>(type: "double precision", nullable: false),
                    ExecutorRating = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companies_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Okeds_OkedId",
                        column: x => x.OkedId,
                        principalTable: "Okeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCompanyReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Evaulation = table.Column<int>(type: "integer", nullable: false),
                    Anonim = table.Column<bool>(type: "boolean", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Plus = table.Column<string>(type: "text", nullable: true),
                    Minus = table.Column<string>(type: "text", nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    ServiceName = table.Column<string[]>(type: "text[]", nullable: true),
                    StartCooperation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StopCooperation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Period = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCompanyReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCompanyReviews_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployerCompanyReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Anonimus = table.Column<bool>(type: "boolean", nullable: false),
                    Evaulation = table.Column<int>(type: "integer", nullable: false),
                    WorkPlace = table.Column<string>(type: "text", nullable: true),
                    Peoples = table.Column<string>(type: "text", nullable: true),
                    DateStartWork = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateStopWork = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateNow = table.Column<bool>(type: "boolean", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: true),
                    TypeOfEmployment = table.Column<string>(type: "text", nullable: true),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    Wage = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    Plus = table.Column<string>(type: "text", nullable: true),
                    Minus = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerCompanyReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployerCompanyReviews_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExecutorCompanyReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Evaulation = table.Column<int>(type: "integer", nullable: false),
                    Anonim = table.Column<bool>(type: "boolean", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Plus = table.Column<string>(type: "text", nullable: true),
                    Minus = table.Column<string>(type: "text", nullable: true),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    ServiceName = table.Column<string>(type: "text", nullable: true),
                    StartCooperation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StopCooperation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PeriodId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExecutorCompanyReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExecutorCompanyReviews_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Evaulation = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PageId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserNameTwoGis = table.Column<string>(type: "text", nullable: true),
                    Minus = table.Column<string>(type: "text", nullable: true),
                    Plus = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Anonim = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PageId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: true),
                    Path = table.Column<string>(type: "text", nullable: true),
                    CustomerCompanyReviewsId = table.Column<Guid>(type: "uuid", nullable: true),
                    EmployerCompanyReviewsId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExecutorCompanyReviewsId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_CustomerCompanyReviews_CustomerCompanyReviewsId",
                        column: x => x.CustomerCompanyReviewsId,
                        principalTable: "CustomerCompanyReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_EmployerCompanyReviews_EmployerCompanyReviewsId",
                        column: x => x.EmployerCompanyReviewsId,
                        principalTable: "EmployerCompanyReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_ExecutorCompanyReviews_ExecutorCompanyReviewsId",
                        column: x => x.ExecutorCompanyReviewsId,
                        principalTable: "ExecutorCompanyReviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReviewLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewLikes_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReviewLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentDislikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentDislikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentDislikes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentDislikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentDislikes_CommentId",
                table: "CommentDislikes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentDislikes_UserId",
                table: "CommentDislikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_CommentId",
                table: "CommentLikes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserId",
                table: "CommentLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewId",
                table: "Comments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OkedId",
                table: "Companies",
                column: "OkedId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RegionId",
                table: "Companies",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintComments_ComplaintId",
                table: "ComplaintComments",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintCompanies_ComplaintId",
                table: "ComplaintCompanies",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintPersons_ComplaintId",
                table: "ComplaintPersons",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintReviews_ComplaintId",
                table: "ComplaintReviews",
                column: "ComplaintId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OrganizationId",
                table: "Contacts",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCompanyReviews_CompanyId",
                table: "CustomerCompanyReviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerCompanyReviews_CompanyId",
                table: "EmployerCompanyReviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ExecutorCompanyReviews_CompanyId",
                table: "ExecutorCompanyReviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_CustomerCompanyReviewsId",
                table: "Files",
                column: "CustomerCompanyReviewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_EmployerCompanyReviewsId",
                table: "Files",
                column: "EmployerCompanyReviewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ExecutorCompanyReviewsId",
                table: "Files",
                column: "ExecutorCompanyReviewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ReviewId",
                table: "Files",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewLikes_ReviewId",
                table: "ReviewLikes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewLikes_UserId",
                table: "ReviewLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CompanyId",
                table: "Reviews",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookMarksReviews");

            migrationBuilder.DropTable(
                name: "CommentDislikes");

            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "ComplaintComments");

            migrationBuilder.DropTable(
                name: "ComplaintCompanies");

            migrationBuilder.DropTable(
                name: "ComplaintPersons");

            migrationBuilder.DropTable(
                name: "ComplaintReviews");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "IntegrationConfigurations");

            migrationBuilder.DropTable(
                name: "IntegrationLogs");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "ReviewLikes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Complaints");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "CustomerCompanyReviews");

            migrationBuilder.DropTable(
                name: "EmployerCompanyReviews");

            migrationBuilder.DropTable(
                name: "ExecutorCompanyReviews");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Okeds");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
