using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
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
                    Price = table.Column<int>(type: "int", nullable: false),
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
                    ImageName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, defaultValue: "nophoto.jpg"),
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
                    PremiumDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PremiumId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
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
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "nophoto.jpg"),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StafStafRole_Staf_StafId",
                        column: x => x.StafId,
                        principalTable: "Staf",
                        principalColumn: "Id");
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
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.CheckConstraint("Token_check", "[Token] <> ''");
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_UserId",
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
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StafMovieRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StafId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    StafRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StafMovieRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StafMovieRole_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StafMovieRole_StafRole_StafRoleId",
                        column: x => x.StafRoleId,
                        principalTable: "StafRole",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StafMovieRole_Staf_StafId",
                        column: x => x.StafId,
                        principalTable: "Staf",
                        principalColumn: "Id");
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "Name", "Price", "Rate" },
                values: new object[,]
                {
                    { 1, "Free", 0, 0 },
                    { 2, "Light", 100, 20 },
                    { 3, "Middle", 200, 40 },
                    { 5, "Full", 350, 60 }
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
                    { "028582c83a914a45b330b5234f4131fb", 0, new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ff6ec5d9-9548-4a2a-a8b4-5d1cdd10a499", "User3@gmail.com", true, false, null, "Олег", "USER3@GMAIL.COM", "USER3@GMAIL.COM", "AQAAAAIAAYagAAAAEIiDZ0evwAKASbFViveHsKTA5EXnfzH+xZ0M0vSO3IBtIB8t8A8XJwdZpy9Ut08p1g==", null, false, new DateTime(2024, 5, 30, 20, 46, 31, 139, DateTimeKind.Utc).AddTicks(9434), 3, "af8bb652-63dc-4016-8a14-19f1ea14fd0b", "Панасенко", false, "User3@gmail.com" },
                    { "c86dc56aedf549f6afe5ceb4d414ebf1", 0, new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "8720c7bc-0304-4204-bf86-2318b7bfe528", "User2@gmail.com", true, false, null, "Петро", "USER2@GMAIL.COM", "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEK96VlMWMx2xtia17z6wUq3ZofEkDQ3fNfpNQzXxUdykAErDQSti51EL+hOzffJw9w==", null, false, new DateTime(2024, 5, 30, 20, 46, 31, 50, DateTimeKind.Utc).AddTicks(8030), 2, "25e4e3ce-01f0-463f-8797-8e970204e45f", "Дякуленко", false, "User2@gmail.com" },
                    { "d1901b2435594da2a255db13fc57509b", 0, new DateTime(1988, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "296609ff-dcf3-4cb2-be7e-6a62a80288d1", "User1@gmail.com", true, false, null, "Iван", "USER1@GMAIL.COM", "USER1@GMAIL.COM", "AQAAAAIAAYagAAAAEJYTe8cF4/0MdlnQa7IG4B7j0dTcLLhsp8dGVT35N37ViyjmfyR79P4pXaR2sWa8Ww==", null, false, new DateTime(2024, 5, 30, 20, 46, 30, 936, DateTimeKind.Utc).AddTicks(7862), 1, "9841d633-5c19-40eb-a115-07eaa408389e", "Калита", false, "User1@gmail.com" },
                    { "eb05f9548a2c4cf8adcc2be7305fc732", 0, new DateTime(2001, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "f0a709b9-fd01-4ab9-88cb-06f2f8773bc4", "User4@gmail.com", true, false, null, "Тимофій", "USER4@GMAIL.COM", "USER4@GMAIL.COM", "AQAAAAIAAYagAAAAEAlabXW4OrIebZEooqsXY9UrBo578rUJ0Y03M9afFXq/dT0OnSO1935Q6iDYgVhJfw==", null, false, new DateTime(2024, 5, 30, 20, 46, 31, 228, DateTimeKind.Utc).AddTicks(9235), 2, "98408a82-7cf2-4999-b420-01c719402b37", "Гнатенко", false, "User4@gmail.com" },
                    { "f66e492517d7414495e988c4c50fd107", 0, new DateTime(1998, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "5a66eb8e-0f02-451e-804b-54823b005f71", "Admin@gmail.com", true, false, null, "Петро", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEEhZGrWq2ISRKwhsP5XB1YE2xn263UNChHYL9PaaK7ei4GiaMzXuUzUkArD1cSiIxQ==", null, false, new DateTime(2024, 5, 30, 20, 46, 30, 819, DateTimeKind.Utc).AddTicks(4514), 1, "e5de787c-707a-4b60-a523-8be2fc69439f", "Левак", false, "Admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CountryId", "Date", "Description", "MovieUrl", "Name", "OriginalName", "Poster", "PremiumId", "QualityId", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(1995, 4, 25, 2, 57, 0, 0, DateTimeKind.Unspecified), "Фільм, що розповідає про боротьбу Шотландського королівства за незалежність проти англійського панування. Головний герой фільму — Вільям Воллес, ватажок шотландців, у виконанні Мела Гібсона.одії фільму починаються 1280 року. Це історія легендарного національного шотландського героя Вільяма Воллеса, який присвятив себе боротьбі з англійцями за часів короля Едуарда Довгоногого. Вільям рано втратив батька, що загинув від рук англійців, але його дядько зумів дати хлопцеві навчання в Європі. На батьківщину Вільям повертається вже дорослим чоловіком, що мріє завести родину і жити мирним життям. Та доля вирішила інакше. Його наречену вбили англійці, і він почав свій «хрестовий похід» за свободу.", "https://pixel.stream.voidboost.cc/52806ed4b4d47c4a8297f9e4983a9659:2024022221:4c97894d-562e-4330-9154-0facb485bda1/7/8/1/6/3/byf31.mp4", "Хоробре серце", "Braveheart", "82ff372d46f44895af282106fe13a201.jpg", 1, 3, "https://www.youtube.com/watch?v=277chVHPQSA&t=39s" },
                    { 2, 2, new DateTime(2010, 7, 22, 2, 28, 0, 0, DateTimeKind.Unspecified), "Ми звикли, що в нашому розумінні злодій - це людина здатна вкрасти якісь цінності або гроші. Сюжет фантастичного бойовика «Початок» розповідає про злодіїв здатних вкрасти ідею прямо у людини з підсвідомості. Одним з таких є головний герой фільму Домінік Кобб. Після того як його дружина померла, він змушений ховатися, і не може навіть повернутися в країну, щоб побачити дітей. Якось раз Кобб отримує дуже неординарне замовлення: йому потрібно не вкрасти, а навпаки впровадити нову ідею в підсвідомість людини. Домініку не надто хотітися братися за цю справу, але замовник в обмін пропонує можливість повернутися додому. Заручившись підтримкою професіоналів цієї справи, Кобб починає розробляти план як все провернути. Все потрібно дуже добре продумати, адже злодіям доведеться відтворити багатошарову реальність в підсвідомості об'єкта, в результаті чого межі можуть почати стиратися.", "https://aura.stream.voidboost.cc/e86eaadc35a0ecfb807054393e269605:2024022217:a95fa9f9-d7d0-4039-ad6f-4e785486da15/5/9/1/7/7/to9f8.mp4", "Початок", "Inception", "7d4159900afd4481881c42483b369f3e.jpeg", 2, 2, "https://www.youtube.com/watch?v=85Zz1CCXyDI" },
                    { 3, 2, new DateTime(2010, 2, 13, 2, 18, 0, 0, DateTimeKind.Unspecified), "Фільм «Острів проклятих» - психологічний ретро-трилер, знятий за романом письменника і кіносценариста Денніса Ліхейна.\r\n\r\n1954 рік. Два бостонських федеральних маршала - досвідчений Тедді Деніелс і нещодавно переведений з Сіетла Чак Аулі - пливуть на острів Шаттер (Острів проклятих). Там знаходиться психлікарня, яка добре охороняється а порядками нагадує в'язницю, куди поміщені божевільні злочинці. Незважаючи на охорону, замки і справну сигналізацію з режимної лікарні примудрилася втекти особливо небезпечна божевільна - Рейчел Соландо, яка в божевіллі втопила своїх дітей.\r\n\r\nНа ділі для Деніелса це відрядження - лише привід відвідати каземати для божевільних: на острові міститься піроман Ендрю Леддіс, винуватець загибелі дружини маршала. Знайти його і утікачку Рейчел - ось завдання для Деніелса, проте розслідування чиновників наштовхується на опір двох завідуючих лікарнею і всього медперсоналу. У їхніх діях змученому головним болем федеральному маршалу починає бачитися якась змова, яка заважає розпочатому розслідуванню.", "https://pixel.stream.voidboost.cc/52806ed4b4d47c4a8297f9e4983a9659:2024022221:4c97894d-562e-4330-9154-0facb485bda1/7/8/1/6/3/byf31.mp4", "Острів проклятих", "Shutter Island", "9c5c4b7d933b436fa7ff5f8971d7ffb6.jpg", 2, 3, "https://www.youtube.com/watch?v=1jERdYDWG8g" },
                    { 4, 2, new DateTime(2010, 6, 3, 1, 56, 0, 0, DateTimeKind.Unspecified), "Фільм 'Принц Персії: Піски часу' - пригодницький бойовик від режисера Майка Н'юелла, знятий за мотивами однойменної комп'ютерної гри. Головний герой фільму - Дастан. Одного разу в юнацькому віці він рятує від смерті свого кращого друга, якого впіймали вартові за злодійство, тим самим, мимоволі демонструючи свої дивовижні навички та хоробрість, перед королем Персії, який випадково опинився поруч, Захопившись настільки цінними задатками хлопчика, правитель робить юнака одним зі своїх приймачів, і з перших же днів починає навчати його військовому ремеслу.", "https://aura.stream.voidboost.cc/e86eaadc35a0ecfb807054393e269605:2024022217:a95fa9f9-d7d0-4039-ad6f-4e785486da15/5/9/1/7/7/to9f8.mp4", "Принц Персії:Піски часу", "Prince of Persia: The Sands of Time", "d4cfbb16be9b4ae384a612d336e18bdb.webp", 1, 2, "https://www.youtube.com/watch?v=WcN_kcbSsMU" },
                    { 5, 2, new DateTime(2011, 12, 16, 2, 9, 0, 0, DateTimeKind.Unspecified), "Шерлок Холмс знову береться за справу, після того як трапляється серія терактів у Відні і Страсбурзі, які на думку уряду влаштували анархісти. До всього іншого, в Європі відбувається серія вбивств, які з боку здаються ніяк не пов'язаними між собою. Однак Холмса не так просто провести, і вивчивши всі докази, він розуміє, що це справа рук професора Моріарті - злого генія і його давнього ворога.\r\nДоктор Ватсон тільки одружився, і дуже цьому радий, і більше не бажає брати участь в справах свого друга детектива. Однак завдяки збігу обставин, вони все ж об'єднують свої зусилля, і відправляються на пошуки Моріарті, щоб зруйнувати підступні плани злого професора.", "https://pixel.stream.voidboost.cc/52806ed4b4d47c4a8297f9e4983a9659:2024022221:4c97894d-562e-4330-9154-0facb485bda1/7/8/1/6/3/byf31.mp4", "Шерлок Холмс: Гра тіней", "Sherlock Holmes: A Game of Shadows", "3d1d88ddddaa4dafaad6da31477b6ef6.webp", 2, 3, "https://www.youtube.com/watch?v=wvKznq9CUuY" }
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
                    { 10, new DateTime(1981, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Джозеф Леонард Гордон-Левітт (англ. Joseph Leonard Gordon-Levitt; нар. 17 лютого 1981, Лос-Анджелес, Каліфорнія, США) — американський актор, режисер, сценарист та продюсер. Отримав популярність завдяки ролі Томмі Соломона у комедійному серіалі «Третя планета від Сонця» (1996—2001), а також фільмам «Цеглина» (2005), «500 днів літа» (2009), «Початок» (2010), «Темний лицар повертається» (2012) та «Петля часу».", "7d4159900afd4481881c42483b369f3e.jpg", false, "Джозеф", "Гордон-Левітт" },
                    { 11, new DateTime(1942, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Aмериканський кінорежисер, сценарист, продюсер та історик кіно, знаний також під зменшувальним ім'ям Марті.\r\n\r\nВін є засновником «Світового фонду кіно» та лауреатом премії Американського інституту кіномистецтва за внесок у кінематограф. Скорсезе є також лауреатом численних премій, серед яких «Оскар», «Золотий глобус», БАФТА та премія Гільдії кінорежисерів Америки.", "787ac3b0103c491fbf323f6830551bd4.webp", true, "Мартін", "Скорсезе" },
                    { 12, new DateTime(1967, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Aмериканський актор, режисер, сценарист і продюсер. Народився в Кеноші, Вісконсін, США. Повне ім'я — Марк Алан Руффало. \r\n\r\nБатько Марка — художник, мати — перукар. Окрім Марка в сім'ї було ще троє дітей. Дитинство Руффало пройшло у Вісконсіні, а пізніше — в Сан-Дієго. Закінчивши школу, Марк вчився в Консерваторії Стелли Адлер у Лос- Анджелесі", "7bb3ad83cc8f486296ad7953dcdc8985.jpg", true, "Mapk", "Руффало" },
                    { 13, new DateTime(1943, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Бен Кінґслі народився 31 грудня 1943 року в Скарборо, графство Йоркшир. Батько — лікар індійського походження з острова Занзібар (Танзанія), мати — британська акторка та модель російського єврейського походження. Свою кар'єру почав з театральної сцени. За порадою батька взяв сценічний псевдонім. Із 1967 член трупи Королівського Шекспірівського театру. Перша роль у кіно — у фільмі «Страх - це ключ» (1972). Після цього знімається в телесеріалах. У 1982 зіграв у картині Річарда Аттенборо «Ганді», за роль у якій отримав премію «Оскар».", "8302c710ae0c4ff2aa68c7d41d4ea795.jpg", true, "Бен", "Кінґслі" },
                    { 14, new DateTime(1980, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Американська акторка телебачення, театру та кіно, кінорежисерка.Народилась у місті Каліспелл (штат Монтана, США)[6] в сім'ї домогосподарки Карли Свенсон та трейдера Ларрі Вільямса[7][8]. Має норвезькі корені[9]. Коли їй було 9, сім'я переїхала до Сан-Дієго, й дівчинка стала цікавитись акторським мистецтвом.", "238f660b10ed449bbca6bf5ab913a457.jpg", true, "Мішель", "Вільямс" },
                    { 15, new DateTime(1942, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Англійський режисер і продюсер кіно і телебачення. Він отримав премію BAFTA за найкращу режисуру за фільм «Чотири весілля і похорон», який також отримав премію BAFTA за найкращий фільм, а також зняв фільми «Донні Браско» та «Гаррі Поттер і келих вогню».", "65f199489b9a4e84aed0428cb9d5621c.jpg", false, "Майк", "Ньюелл" },
                    { 16, new DateTime(1980, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Американський актор, номінант на премію «Оскар» у 2006 році, лауреат премії BAFTA. Син режисера Стівена Джилленгола і сценаристки Наомі Фонер, молодший брат актриси Меггі Джилленгол.Народився 19 грудня 1980 року в Лос-Анджелес, США. Син режисера Стівена Джилленгола і сценаристки Наомі Фонер. Мати Джилленгола — єврейка, яка народилася в сім'ї іммігрантів зі Східної Європи (Латвія та Польща).", "05c1fa41bf324157a1df9c1eb6f556e4.jpg", true, "Джейк", "Джилленгол" },
                    { 17, new DateTime(1986, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Aнглійська акторка, найвідоміші ролі у фільмах «Квант милосердя» (2008), «Битва титанів» (2010), «Принц Персії: піски часу» (2009), «Тамара і секс» (2010) та «Мисливці за відьмами» (2013).Народилася 2 лютого 1986 в Грейвсенді, графство Кент, Велика Британія. Її мати Саллі-Енн була прибиральницею, а батько Баррі Артертон зварювальником.[5] Молодша сестра Ханна Джейн Артертон. Артертон народилася зі шістьма пальцями на кожній руці,полідактилія була усунена хірургічним методом ще в дитинстві", "b0b532cb865a4271a6de3352c6c70cf1.jpg", true, "Джемма", "Артертон" },
                    { 18, new DateTime(1982, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Aнглійський кіно- та телеактор, відомий за ролями у фільмах «Олександр», «Рок-н-рольник», «Принц Персії: Піски часу», «Учень чаклуна», «Бойовий кінь» та «Бен-Гур».", "4a3a7e7116614e4d990abf7e9cb94438.jpg", false, "Тобі", "Кеббелл" },
                    { 19, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Aмериканський актор, продюсер і музикант. Став широко відомий після релізу байопіку «Чаплін», в якому виконав головну роль коміка Чарлі Чапліна. Лауреат премії «Оскар» (2024), триразовий лауреат «Золотого глобуса» (2001, 2010, 2024), дворазовий володар премії BAFTA (1993, 2024). Почав акторську кар'єру ще дитиною, зігравши у фільмі свого батька «Загін» (1970). Ближче до початку 1990-х Дауні став популярним актором, зокрема, завдяки ролям у фільмах «Ейр Америка» (1990), «Велика піна» (1991) і «Природжені вбивці» (1994). Найбільш відомою й успішною роллю Роберта в XX столітті вважається роль Чарлі Чапліна в однойменному байопіку Річарда Аттенборо, що принесла йому премію BAFTA і першу номінацію на «Оскар».", "4e36bbaa11564827bb141b4db1b5238b.jpg", false, "Роберт", "Дауні (молодший)" },
                    { 20, new DateTime(1968, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Народився у Гатфілді, графстві Гартфордшир. У віці п'ятнадцяти років покинув школу і почав працювати посильним. Сертифікат про середню освіту Річі отримав пізніше. Мріяв стати режисером, проте в кіношколу йти не збирався, бо, на його думку, вона „плодить нудних, одноманітних кінорежисерів“, тому намагався навчатись самостійно. Спочатку знімав рекламні і музичні кліпи. Після перших успіхів, заробивши трохи грошей, поставив свою першу короткометражну стрічку «Важка справа» (1995). Того ж року написав сценарій до свого наступного фільму, але фінансування для нього вдалось знайти тільки за три роки, за допомогою фірми «Поліграм».", "6cf090472b844901b58aa971368e3b51.jpg", false, "Ґай", "Річі" },
                    { 21, new DateTime(1972, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Британський кіноактор і театральний актор. Дворазовий номінант на премію «Оскар» (2000, 2004), чотириразовий — на премію «Золотий глобус». Найбільшу популярність отримав після фільмів «Талановитий містер Ріплі» (1999, премія БАФТА за найкращу чоловічу роль другого плану), «Холодна гора» (2003, номінації на «Оскар» і «Золотий глобус»), «Близькість» (2004).", "06c07b4b9d9e493f8141626f1ce4e4ec.jpg", true, "Джуд", "Лоу" },
                    { 22, new DateTime(1961, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Гарріс народився у Лондоні, він є одним з трьох синів ірландського актора Річарда Гарріса і його першої дружини, уельської актриси Елізабет Ріс-Вільямс. Його молодший брат актор Джеймі Гарріс, старший — режисер Деміан Гарріс. З 1971 по 1975 актор Рекс Гаррісон був одружений з його матір'ю. В 1984 він отримав бакалавр витончених мистецтв (Bachelor of Fine Arts, BFA) в Дюкському університеті.", "1bb5b31e95fb4d8d9b835793a946b34d.jpg", false, "Джаред", "Гарріс" },
                    { 23, new DateTime(1978, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Гарріс народився у Лондоні, він є одним з трьох синів ірландського актора Річарда Гарріса і його першої дружини, уельської актриси Елізабет Ріс-Вільямс. Його молодший брат актор Джеймі Гарріс, старший — режисер Деміан Гарріс. З 1971 по 1975 актор Рекс Гаррісон був одружений з його матір'ю. В 1984 він отримав бакалавр витончених мистецтв (Bachelor of Fine Arts, BFA) в Дюкському університеті.", "a6d715ddc91e47b1a5f5fbaa514b1358.jpg", false, "Рейчел", "МакАдамс" },
                    { 24, new DateTime(1979, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, "Шведська актриса, найбільш відома за головною роллю у шведсько-данській-німецько-норвезькій екранізації трилогії Стіґа Ларссона «Міленіум»: «Дівчина з татуюванням дракона», «Дівчина, яка грала з вогнем» і «Дівчина, яка підривала повітряні замки». У 2011 році вона зіграла одну з головних ролей у фільмі «Шерлок Холмс: Гра тіней».", "7ddc87bfddd4183a366b371fa3d57d8.jpg", false, "Нумі", "Рапас" }
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
                columns: new[] { "Id", "Approved", "Date", "MovieId", "Rating", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2017, 7, 22, 12, 28, 0, 0, DateTimeKind.Unspecified), 1, 4.0, "Чудовий фільм", "d1901b2435594da2a255db13fc57509b" },
                    { 2, true, new DateTime(2021, 5, 3, 15, 40, 0, 0, DateTimeKind.Unspecified), 1, 4.0, "Фільм дуже сподобався", "c86dc56aedf549f6afe5ceb4d414ebf1" },
                    { 3, true, new DateTime(2022, 1, 12, 16, 16, 0, 0, DateTimeKind.Unspecified), 2, 4.0, "Один з найкащих фільмів", "028582c83a914a45b330b5234f4131fb" },
                    { 4, true, new DateTime(2020, 2, 20, 0, 8, 0, 0, DateTimeKind.Unspecified), 2, 5.0, "Фільм дуже сподобався", "eb05f9548a2c4cf8adcc2be7305fc732" },
                    { 5, true, new DateTime(2012, 5, 5, 10, 18, 0, 0, DateTimeKind.Unspecified), 3, 5.0, "Один з найкащих фільмів", "eb05f9548a2c4cf8adcc2be7305fc732" },
                    { 6, true, new DateTime(2016, 1, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 5.0, "Фільм дуже сподобався", "d1901b2435594da2a255db13fc57509b" },
                    { 7, true, new DateTime(2017, 3, 23, 13, 23, 0, 0, DateTimeKind.Unspecified), 4, 5.0, "Чудовий фільм", "d1901b2435594da2a255db13fc57509b" },
                    { 8, true, new DateTime(2019, 11, 21, 11, 18, 0, 0, DateTimeKind.Unspecified), 4, 5.0, "Один з найкащих фільмів", "028582c83a914a45b330b5234f4131fb" },
                    { 9, true, new DateTime(2019, 9, 11, 17, 45, 0, 0, DateTimeKind.Unspecified), 5, 5.0, "Фільм дуже сподобався", "c86dc56aedf549f6afe5ceb4d414ebf1" },
                    { 10, true, new DateTime(2022, 1, 1, 1, 1, 0, 0, DateTimeKind.Unspecified), 5, 4.0, "Один з найкащих фільмів", "028582c83a914a45b330b5234f4131fb" }
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
                    { 14, 2, "3484dbfface144648621281a62b40d81.jpg" },
                    { 15, 3, "9c5c4b7d933b436fa7ff5f8971d7ffb6.webp" },
                    { 16, 3, "05c1fa41bf324157a1df9c1eb6f556e4.webp" },
                    { 17, 3, "bc68599bf067498bba00894694b36a41.webp" },
                    { 18, 3, "fc1dfd25a97646ea8576c6785666dcc5.webp" },
                    { 19, 4, "4fc5360c83e548b5bda7db0d237ea701.webp" },
                    { 20, 4, "cc3b110a147a4bef9a04598974409199.webp" },
                    { 21, 4, "6f91954d9fd949f690f4d9f8bba4bc0d.webp" },
                    { 22, 4, "e97a5e1f56ab443f9484bd52fcd38325.webp" },
                    { 23, 5, "8eda6b7d745644229ef6ea0830fa4034.webp" },
                    { 24, 5, "88acda2dbc9741a08fcc66a288edf169.webp" },
                    { 25, 5, "3b4eed90465840c78b5160d8613b4350.webp" },
                    { 26, 5, "bc68599bf067498bba00894694b36a412.webp" }
                });

            migrationBuilder.InsertData(
                table: "MovieGenre",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 18, 1 },
                    { 2, 4, 1 },
                    { 3, 2, 1 },
                    { 4, 1, 2 },
                    { 5, 7, 2 },
                    { 6, 2, 2 },
                    { 7, 20, 3 },
                    { 8, 9, 3 },
                    { 9, 4, 3 },
                    { 10, 2, 4 },
                    { 11, 1, 4 },
                    { 12, 6, 4 },
                    { 13, 8, 4 },
                    { 14, 9, 5 },
                    { 15, 2, 5 },
                    { 16, 1, 5 },
                    { 17, 10, 5 },
                    { 18, 20, 5 }
                });

            migrationBuilder.InsertData(
                table: "StafMovieRole",
                columns: new[] { "Id", "MovieId", "StafId", "StafRoleId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 1, 2 },
                    { 3, 1, 1, 4 },
                    { 4, 1, 2, 2 },
                    { 5, 1, 3, 2 },
                    { 6, 2, 4, 1 },
                    { 7, 2, 5, 2 },
                    { 8, 2, 6, 2 },
                    { 9, 2, 7, 2 },
                    { 10, 2, 8, 2 },
                    { 11, 2, 9, 2 },
                    { 12, 2, 10, 2 },
                    { 13, 3, 5, 2 },
                    { 14, 3, 11, 1 },
                    { 15, 3, 12, 2 },
                    { 16, 3, 13, 2 },
                    { 17, 3, 14, 2 },
                    { 18, 4, 13, 2 },
                    { 19, 4, 15, 1 },
                    { 20, 4, 16, 2 },
                    { 21, 4, 17, 2 },
                    { 22, 4, 18, 2 },
                    { 23, 5, 19, 2 },
                    { 24, 5, 20, 1 },
                    { 25, 5, 21, 2 },
                    { 26, 5, 22, 2 },
                    { 27, 5, 23, 2 },
                    { 28, 5, 24, 2 }
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
                    { 12, 10, 2 },
                    { 13, 11, 1 },
                    { 14, 12, 2 },
                    { 16, 12, 1 },
                    { 17, 13, 2 },
                    { 18, 14, 2 },
                    { 19, 15, 1 },
                    { 20, 16, 2 },
                    { 21, 17, 2 },
                    { 22, 18, 2 },
                    { 23, 19, 2 },
                    { 24, 20, 1 },
                    { 25, 21, 2 },
                    { 26, 22, 2 },
                    { 27, 23, 2 },
                    { 28, 24, 2 }
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
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Staf_CountryId",
                table: "Staf",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StafMovieRole_MovieId",
                table: "StafMovieRole",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_StafMovieRole_StafId",
                table: "StafMovieRole",
                column: "StafId");

            migrationBuilder.CreateIndex(
                name: "IX_StafMovieRole_StafRoleId",
                table: "StafMovieRole",
                column: "StafRoleId");

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
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "StafMovieRole");

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
