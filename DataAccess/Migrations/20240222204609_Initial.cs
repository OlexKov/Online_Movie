using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.CheckConstraint("Name_check", "[Name] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.CheckConstraint("Name_check1", "[Name] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Premium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.Id);
                    table.CheckConstraint("Name_check4", "[Name] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "Quality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quality", x => x.Id);
                    table.CheckConstraint("Name_check5", "[Name] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "StafRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StafRole", x => x.Id);
                    table.CheckConstraint("Name_check7", "[Name] <> ''");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, defaultValue: "nophoto.jpeg"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsOscar = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staf", x => x.Id);
                    table.CheckConstraint("Name_check6", "[Name] <> ''");
                    table.CheckConstraint("Surname_check", "[Surname] <> ''");
                    table.ForeignKey(
                        name: "FK_Staf_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiumDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PremiumId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Premium_PremiumId",
                        column: x => x.PremiumId,
                        principalTable: "Premium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualityId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "noposter.jpeg"),
                    MovieUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PremiumId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.CheckConstraint("MovieUrl_check", "[MovieUrl] <> ''");
                    table.CheckConstraint("Name_check3", "[Name] <> ''");
                    table.CheckConstraint("OriginalName_check", "[OriginalName] <> ''");
                    table.ForeignKey(
                        name: "FK_Movie_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Premium_PremiumId",
                        column: x => x.PremiumId,
                        principalTable: "Premium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Quality_QualityId",
                        column: x => x.QualityId,
                        principalTable: "Quality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StafStafRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StafId = table.Column<int>(type: "int", nullable: false),
                    StafRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StafStafRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StafStafRole_StafRole_StafRoleId",
                        column: x => x.StafRoleId,
                        principalTable: "StafRole",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StafStafRole_Staf_StafId",
                        column: x => x.StafId,
                        principalTable: "Staf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.CheckConstraint("Text_check", "[Text] <> ''");
                    table.ForeignKey(
                        name: "FK_Feedback_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Feedback_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.CheckConstraint("Name_check2", "[Name] <> ''");
                    table.ForeignKey(
                        name: "FK_Image_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StafMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StafId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StafMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StafMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StafMovie_Staf_StafId",
                        column: x => x.StafId,
                        principalTable: "Staf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserMovie_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserMovie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15b04d9eff654d8d966a172db59e2722", "15b04d9eff654d8d966a172db59e2722", "Admin", "ADMIN" },
                    { "59139483f3d1417db1efee50d14b6a7f", "59139483f3d1417db1efee50d14b6a7f", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Україна" },
                    { 2, "США" },
                    { 3, "Китай" },
                    { 4, "Індія" },
                    { 5, "Бразилія" },
                    { 6, "Німеччина" },
                    { 7, "Японія" },
                    { 8, "Франція" },
                    { 9, "Канада" },
                    { 10, "Італія" },
                    { 11, "Австралія" },
                    { 12, "Іспанія" },
                    { 13, "Мексика" },
                    { 14, "Південна Корея" },
                    { 15, "Індонезія" },
                    { 16, "Нідерланди" },
                    { 17, "Польща" },
                    { 18, "Швеція" },
                    { 19, "Швейцарія" },
                    { 20, "Британія" },
                    { 21, "Шотландія" },
                    { 22, "Англія" },
                    { 23, "Ірландія" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Екшн" },
                    { 2, "Пригоди" },
                    { 3, "Комедія" },
                    { 4, "Драма" },
                    { 5, "Жахи" },
                    { 6, "Фентезі" },
                    { 7, "Фантастика" },
                    { 8, "Романтика" },
                    { 9, "Трилер" },
                    { 10, "Кримінал" },
                    { 11, "Вестерн" },
                    { 12, "Воєнний" },
                    { 13, "Документальний" },
                    { 14, "Містика" },
                    { 15, "Мюзикл" },
                    { 16, "Аніме" },
                    { 17, "Спорт" },
                    { 18, "Історичний" },
                    { 19, "Біографія" },
                    { 20, "Детектив" },
                    { 21, "Хоррор" },
                    { 22, "Мелодрама" }
                });

            migrationBuilder.InsertData(
                table: "Premium",
                columns: new[] { "Id", "Name", "Rate" },
                values: new object[,]
                {
                    { 1, "Free", 0 },
                    { 2, "Light", 20 },
                    { 3, "Midle", 40 },
                    { 5, "Full", 60 }
                });

            migrationBuilder.InsertData(
                table: "Quality",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Web-DL" },
                    { 2, "1080p" },
                    { 3, "720p" },
                    { 5, "480p" },
                    { 6, "2K" },
                    { 7, "4K" },
                    { 8, "8K" }
                });

            migrationBuilder.InsertData(
                table: "StafRole",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Режисер" },
                    { 2, "Актор" },
                    { 3, "Оператор" },
                    { 4, "Продюсер" },
                    { 5, "Автор сценарію" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthdate", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PremiumDate", "PremiumId", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "028582c83a914a45b330b5234f4131fb", 0, new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "0b09a82a-6060-4290-bb06-c672591f2c33", "User3@gmail.com", true, false, null, "Олег", null, "USER3@GMAIL.COM", "AQAAAAIAAYagAAAAEDu1p9wtLmMGShJwRO6uVb0CVDY9lAP2LhLrNFA3/7R6sFD80b7RBLD/sddC9lSIjA==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "87cf9351-74a6-4136-b637-be8e27b22255", "Панасенко", false, "User3@gmail.com" },
                    { "c86dc56aedf549f6afe5ceb4d414ebf1", 0, new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "8b097e84-b1c8-475a-ac54-3b8b1256c560", "User2@gmail.com", true, false, null, "Петро", null, "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEEt48D02Nj5GWxXaJiRgYa995mXs33PAR7psuhSQaR/L5DnskFCfzgZPCoBJ1/Q6JA==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "4f233df2-116b-4ba0-91bf-16496d48f3de", "Дякуленко", false, "User2@gmail.com" },
                    { "d1901b2435594da2a255db13fc57509b", 0, new DateTime(1988, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "b575fdad-1761-4b42-b5be-2d2e9138e308", "User1@gmail.com", true, false, null, "Iван", null, "USER1@GMAIL.COM", "AQAAAAIAAYagAAAAEAxxBWekRvmifB8DEcj9bjuIxdNPDnVplET6DjWCYPLesUZa6eLi9Qds+Bor16hYww==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "67e052f0-a426-48ad-9f26-750d6ca5beb7", "Калита", false, "User1@gmail.com" },
                    { "eb05f9548a2c4cf8adcc2be7305fc732", 0, new DateTime(2001, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "d5035b34-ccc0-4453-8abb-dd73d7dec8d6", "User4@gmail.com", true, false, null, "Тимофій", null, "USER4@GMAIL.COM", "AQAAAAIAAYagAAAAEHPxB/eNnGHbQAZ0siUDXf4ABIjXM9xH9NM2LpqkcH/+bZTgM4I2ik095zPCbRE2QA==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "7a94f900-18ae-4191-b64c-8ca2db949ae4", "Гнатенко", false, "User4@gmail.com" },
                    { "f66e492517d7414495e988c4c50fd107", 0, new DateTime(1998, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "1081e300-9fdb-42ff-acb2-7f72a856f94e", "Admin@gmail.com", true, false, null, "Петро", null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKcl2LRk7Ekv4urKEpqCCbmwlikV547N2bMSlkBtbk/JxCGhWry8QL8SQMi73Fv7dA==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "7b81b2b6-b486-4a02-925f-f1a6ccf79115", "Левак", false, "Admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CountryId", "Date", "Description", "MovieUrl", "Name", "OriginalName", "Poster", "PremiumId", "QualityId", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1995, 4, 25, 2, 57, 0, 0, DateTimeKind.Unspecified), "Фільм, що розповідає про боротьбу Шотландського королівства за незалежність проти англійського панування. Головний герой фільму — Вільям Воллес, ватажок шотландців, у виконанні Мела Гібсона.одії фільму починаються 1280 року. Це історія легендарного національного шотландського героя Вільяма Воллеса, який присвятив себе боротьбі з англійцями за часів короля Едуарда Довгоногого. Вільям рано втратив батька, що загинув від рук англійців, але його дядько зумів дати хлопцеві навчання в Європі. На батьківщину Вільям повертається вже дорослим чоловіком, що мріє завести родину і жити мирним життям. Та доля вирішила інакше. Його наречену вбили англійці, і він почав свій «хрестовий похід» за свободу.", "https://pixel.stream.voidboost.cc/52806ed4b4d47c4a8297f9e4983a9659:2024022221:4c97894d-562e-4330-9154-0facb485bda1/7/8/1/6/3/byf31.mp4", "Хоробре серце", "Braveheart", "82ff372d46f44895af282106fe13a201.jpg", 1, 3, "https://www.youtube.com/watch?v=277chVHPQSA&t=39s" },
                    { 2, 2, new DateTime(2010, 7, 22, 2, 28, 0, 0, DateTimeKind.Unspecified), "Ми звикли, що в нашому розумінні злодій - це людина здатна вкрасти якісь цінності або гроші. Сюжет фантастичного бойовика «Початок» розповідає про злодіїв здатних вкрасти ідею прямо у людини з підсвідомості. Одним з таких є головний герой фільму Домінік Кобб. Після того як його дружина померла, він змушений ховатися, і не може навіть повернутися в країну, щоб побачити дітей. Якось раз Кобб отримує дуже неординарне замовлення: йому потрібно не вкрасти, а навпаки впровадити нову ідею в підсвідомість людини. Домініку не надто хотітися братися за цю справу, але замовник в обмін пропонує можливість повернутися додому. Заручившись підтримкою професіоналів цієї справи, Кобб починає розробляти план як все провернути. Все потрібно дуже добре продумати, адже злодіям доведеться відтворити багатошарову реальність в підсвідомості об'єкта, в результаті чого межі можуть почати стиратися.", "https://aura.stream.voidboost.cc/e86eaadc35a0ecfb807054393e269605:2024022217:a95fa9f9-d7d0-4039-ad6f-4e785486da15/5/9/1/7/7/to9f8.mp4", "Початок", "Inception", "7d4159900afd4481881c42483b369f3e.jpg", 2, 2, "https://www.youtube.com/watch?v=85Zz1CCXyDI" }
                });

            migrationBuilder.InsertData(
                table: "Staf",
                columns: new[] { "Id", "Birthdate", "CountryId", "Description", "ImageName", "IsOscar", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1956, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Народився 3 січня 1956 року.\r\n\r\nСин ірландців-католиків Гаттона Гібсона та Ен Райлі Гібсон, яка народилася в парафії Колм-Кіллє графства Лонгфорд, Ірландія. Його бабця по батькові Ева Майлот була австралійською оперною співачкою. Мел народився у місті Пікскілл (округ Вестчестер, штат Нью-Йорк) і був шостим з одинадцяти дітей. Один із молодших братів Мела, Донал, також актор.", "d5d49574945f45c8be24f00cc02923af.webp", true, "Мел", "Гибсон" },
                    { 2, new DateTime(1963, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Народився у сім'ї лікаря. У дитинстві подорожував між трьома країнами — Філіппінами, Сингапуром і Францією. Вищу освіту Енгус отримав у стінах Університету Единбурга, Шотландія. Паралельно з гризенням граніту науки молодий чоловік відвідував заняття в Центральній школі Мовлення та Драми в Лондоні, Англія.", "da0240d0882b4ec1942342ec6cf72505.jpg", false, "Енгус", "Макфадьєн" },
                    { 3, new DateTime(1966, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Народилася 17 листопада 1966 року в Париж, Франція.\r\n\r\nПрославилася підлітком, дебютувавши у «Вечірці» (La Boum, 1980). Вдало знайдений образ «ідеальної французької дівчини», якою Марсо визнали за підсумками глядацького опитування, було розмножено у фільмах «Вечірка-2» (фр. La Boum 2, 1982), «Щасливого Великодня» (1984), «Студентка» (1988), «Аромат кохання. Фанфан» (1993) тощо. Актрису часто залучали до найамбітніших проектів національної кіноіндустрії: «Форт Саґан», «Шуани!», «Дочка Д'Артаньяна», де вона втілювала ідеальну француженку, перетворившись із чарівного підлітка на одну з найкрасивіших актрис світового кіно.\r\n\r\n1999 року зіграла дівчину Бонда у черговому, 19-му за ліком, епізоді Бондіани — підступну, але дуже вразливу Електру Кінґ. Продовжує активно зніматися.", "c9b0972dd8b6431193cd50e9c272416f.jpg", false, "Софі", "Марсо" },
                    { 4, new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, "Крістофер Джонатан Джеймс Нолан - англійський кінорежисер, сценарист і продюсер, який має британське і американське громадянства.[3][4][5] Його 12 фільмів були схвально прийняті світовою кінокритикою та зібрали понад 4 млрд доларів касових зборів, що робить його одним з найуспішніших режисерів сучасності.\r\n\r\nОтримав перше визнання після виходу психологічного трилера Мементо (2000), композиція якого побудована на викривленнях часу. Це дало йому змогу зняти високобюджетний трилер Безсоння (2002) та драму Престиж (2006). Подальший успіх режисерові принесли трилогія Темний лицар (2005—2012), фільм про проникання в чужі сни Початок (2010), науково-фантастичний фільм Інтерстеллар (2014), військову драму Дюнкерк (2017) та науково-фантастичний бойовик Тенет (2020).", "2dbb31f7096740559fba2c8a22a870b2.jpg", false, "Крістофер", "Нолан" },
                    { 5, new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Леона́рдо Вільгельм Ді Ка́пріо (англ. Leonardo Wilhelm DiCaprio; нар. 11 листопада 1974, Лос-Анджелес, США) — американський актор, кінопродюсер. Лауреат премії «Оскар» за найкращу чоловічу роль у фільмі «Легенда Г'ю Гласса» (2016), та нагороди BAFTA і Гільдії кіноакторів США за виконання ролі Г'ю Гласса. Лауреат трьох премій «Золотий глобус» у категорії «Найкращий актор в драматичній картині» і «Найкращий актор — комедія або мюзикл» за головні ролі в картинах «Авіатор», «Вовк з Уолл-стріт» і «Легенда Г'ю Гласса». Лауреат нагороди Берлінського кінофестивалю «Срібний ведмідь» в категорії «Найкращий актор» за виконання ролі Ромео Монтеккі в картині «Ромео + Джульєтта».\r\n\r\nПовноцінну акторську кар'єру почав в шістнадцять років на початку 1990-х років. У 2000-х роках отримав визнання публіки і критиків за роботу в широкому діапазоні кіно і акторську майстерність.", "1d4e8a9fea6146a887c774ffa2db33d7.jpg", true, "Леонардо", "Ді Капріо" },
                    { 6, new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Едвард Томас Гарді (англ. Edward Thomas Hardy) (нар. 15 вересня 1977, Гаммерсміт, Лондон, Велика Британія), знаніший як Том Гарді (англ. Tom Hardy) — британський актор театру та кіно, відомий за головною роллю у фільмі «Бронсон» (2009), а також завдяки участі в голлівудських блокбастерах «Зоряний шлях: Відплата» (2002), «Початок» (2010), «Воїн» (2011) та «Темний лицар повертається» (2012), «Шалений Макс: Дорога гніву» (2015), «Легенда Г'ю Гласса» (2015)", "42713c2fa8b64141a74b4fa6b3d05a0c.jpg", false, "Том", "Харді" },
                    { 7, new DateTime(1975, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Маріо́н Котія́р (фр. Marion Cotillard; нар. 30 вересня 1975, Париж, Франція) — французька акторка театру, телебачення та кіно. Володарка премій Оскар, Золотий глобус та BAFTA. Кавалерка та офіцерка ордена мистецтв та літератури.\r\n\r\nЗа роль у стрічці «Довгі заручини» (2004) отримала премію «Сезар» у номінації «Найкраща акторка другого плану». 2008 року удостоєна премії «Оскар» у номінації «Найкраща акторка» за фільм «Життя у рожевому кольорі», в якому виконала роль Едіт Піаф. Маріон Котіяр стала другою акторкою, що здобула премію «Оскар» за роль у фільмі іноземною мовою. Раніше цей рекорд утримувала Софі Лорен, володарка «Оскар» 1962 року. Також за фільм «Життя у рожевому кольорі» Котіяр отримала премію «Золотий глобус» у номінації «Найкраща жіноча роль (комедія або мюзикл)» і премію Британської академії телебачення та кіномистецтва (BAFTA) у номінації «Найкраща акторка».", "a9141daeb1e04aff947474ad3f2d07d7.jpg", true, "Маріон", "Котіяр" },
                    { 8, new DateTime(1933, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Сер Мо́ріс Джо́зеф Міклвайт (англ. Sir Maurice Joseph Micklewhite), відоміший за акторським (артистичним) псевдонімом як Майкл Кейн (англ. Michael Caine, народився 14 березня 1933 в Лондоні) — один з найпопулярніших британських акторів (знявся більш ніж у 100 фільмах). Це один з двох акторів (другий — Джек Ніколсон), який був номінований на премію «Оскар» у 1960-х, 1970-х, 1980-х, 1990-х та 2000-х роках.", "7adf0a94c3da4d8ea8809a79c6ea3eda.jpg", true, "Майкл", "Кейн" },
                    { 9, new DateTime(1976, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "Кілліан Мерфі (англ. Cillian Murphy; нар. 25 травня 1976, Дуглас, графство Корк, Ірландія) — ірландський актор театру і кіно. Колишній співак, гітарист та автор пісень гурту The Sons of Mr. Green Genes. Наприкінці 90-х почав свою акторську кар'єру граючи на сцені, в короткометражних та незалежних фільмах. Свою першу помітну роль він зіграв у фільмі \"28 днів потому\" (2002), в чорній комедії \"Розрив\" (2003), в трилері \"Нічний рейс\" (2005). Також зіграв ірландську жінку-трансвестита в комедійній драмі \"Сніданок на Плутоні\" (2005), за що був номінований на премію Золотий глобус в категорії \"найкращий актор в мюзиклі або комедії\". З 2013 по 2022 знімався у кримінально-драматичному серіалі \"Гострі картузи\", де зіграв Томаса Шелбі.", "f39d0a89af744d498bc8aac540fefe4d.jpg", true, "Кілліан", "Мерфі" },
                    { 10, new DateTime(1981, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Джозеф Леонард Гордон-Левітт (англ. Joseph Leonard Gordon-Levitt; нар. 17 лютого 1981, Лос-Анджелес, Каліфорнія, США) — американський актор, режисер, сценарист та продюсер. Отримав популярність завдяки ролі Томмі Соломона у комедійному серіалі «Третя планета від Сонця» (1996—2001), а також фільмам «Цеглина» (2005), «500 днів літа» (2009), «Початок» (2010), «Темний лицар повертається» (2012) та «Петля часу».", "7d4159900afd4481881c42483b369f3e.jpg", false, "Джозеф", "Гордон-Левітт" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "59139483f3d1417db1efee50d14b6a7f", "028582c83a914a45b330b5234f4131fb" },
                    { "59139483f3d1417db1efee50d14b6a7f", "c86dc56aedf549f6afe5ceb4d414ebf1" },
                    { "59139483f3d1417db1efee50d14b6a7f", "d1901b2435594da2a255db13fc57509b" },
                    { "59139483f3d1417db1efee50d14b6a7f", "eb05f9548a2c4cf8adcc2be7305fc732" },
                    { "15b04d9eff654d8d966a172db59e2722", "f66e492517d7414495e988c4c50fd107" }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "Id", "MovieId", "Rating", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 4.0, "Чудовий фільм", "d1901b2435594da2a255db13fc57509b" },
                    { 2, 1, 4.0, "Фільм дуже сподобався", "c86dc56aedf549f6afe5ceb4d414ebf1" },
                    { 3, 2, 4.0, "Один з найкащих фільмів", "028582c83a914a45b330b5234f4131fb" },
                    { 4, 2, 5.0, "Фільм дуже сподобався", "eb05f9548a2c4cf8adcc2be7305fc732" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "MovieId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "78f6bd3dff214a149d2b819d2bb2f596.jpg" },
                    { 2, 1, "e8709c9c252c4d0680054104be5d200a.jpg" },
                    { 3, 1, "9d02da5822204216838b18237d0752bc.jpg" },
                    { 4, 1, "cadc26fad170460196200194d40a718a.jpg" },
                    { 5, 1, "9a43056743774ef592a36559134f5be2.jpg" },
                    { 6, 1, "d14d399aa31d45678ad8cb2b317d6d5b.jpg" },
                    { 7, 1, "342c6b26fb544d43914ad1060677b2b8.jpg" },
                    { 8, 2, "2d0627d1199a466c8486c07dc446e1b1.jpg" },
                    { 9, 2, "fc404272f1b34d2e9f887073b58831b9.jpg" },
                    { 10, 2, "3ad737531a5c4b35b0bf99250208badd.jpg" },
                    { 11, 2, "c0299b7d354d4aa79f21d7e7b49519a5.jpg" },
                    { 12, 2, "978e2ab0753c4161bbd7f3af865df208.jpg" },
                    { 13, 2, "80c0e4e646d8435e9d7a4e9211a3be96.jpg" },
                    { 14, 2, "3484dbfface144648621281a62b40d81.jpg" }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 18, 1 },
                    { 2, 4, 1 },
                    { 3, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "StafMovie",
                columns: new[] { "Id", "MovieId", "StafId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 },
                    { 7, 2, 7 },
                    { 8, 2, 8 },
                    { 9, 2, 9 },
                    { 10, 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "StafStafRole",
                columns: new[] { "Id", "StafId", "StafRoleId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 4 },
                    { 4, 2, 2 },
                    { 5, 3, 2 },
                    { 6, 4, 1 },
                    { 7, 5, 2 },
                    { 8, 6, 2 },
                    { 9, 7, 2 },
                    { 10, 8, 2 },
                    { 11, 9, 2 },
                    { 12, 10, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PremiumId",
                table: "AspNetUsers",
                column: "PremiumId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_MovieId",
                table: "Feedback",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_UserId",
                table: "Feedback",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_Name",
                table: "Genre",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Image_MovieId",
                table: "Image",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_Name",
                table: "Image",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CountryId",
                table: "Movie",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_PremiumId",
                table: "Movie",
                column: "PremiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_QualityId",
                table: "Movie",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreId",
                table: "MovieGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MovieId",
                table: "MovieGenre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Premium_Name",
                table: "Premium",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Quality_Name",
                table: "Quality",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Staf_CountryId",
                table: "Staf",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StafMovie_MovieId",
                table: "StafMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_StafMovie_StafId",
                table: "StafMovie",
                column: "StafId");

            migrationBuilder.CreateIndex(
                name: "IX_StafRole_Name",
                table: "StafRole",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_StafStafRole_StafId",
                table: "StafStafRole",
                column: "StafId");

            migrationBuilder.CreateIndex(
                name: "IX_StafStafRole_StafRoleId",
                table: "StafStafRole",
                column: "StafRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_MovieId",
                table: "UserMovie",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_UserId",
                table: "UserMovie",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "StafMovie");

            migrationBuilder.DropTable(
                name: "StafStafRole");

            migrationBuilder.DropTable(
                name: "UserMovie");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "StafRole");

            migrationBuilder.DropTable(
                name: "Staf");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Premium");

            migrationBuilder.DropTable(
                name: "Quality");
        }
    }
}
