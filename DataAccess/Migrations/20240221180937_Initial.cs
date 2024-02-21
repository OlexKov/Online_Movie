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
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.CheckConstraint("Name_check2", "[Name] <> ''");
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
                name: "MovieImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieImage_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovieImage_Movie_MovieId",
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
                    { 21, "Шотландія" }
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
                table: "Image",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "78f6bd3dff214a149d2b819d2bb2f596.jpg" },
                    { 2, "e8709c9c252c4d0680054104be5d200a.jpg" },
                    { 3, "9d02da5822204216838b18237d0752bc.jpg" },
                    { 4, "cadc26fad170460196200194d40a718a.jpg" },
                    { 5, "9a43056743774ef592a36559134f5be2.jpg" },
                    { 6, "d14d399aa31d45678ad8cb2b317d6d5b.jpg" },
                    { 7, "342c6b26fb544d43914ad1060677b2b8.jpg" }
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
                    { "028582c83a914a45b330b5234f4131fb", 0, new DateTime(1999, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "3e146ccf-33e8-4d8b-993a-3c2585f14ce3", "User3@gmail.com", true, false, null, "Олег", null, "USER3@GMAIL.COM", "AQAAAAIAAYagAAAAELF/pPd2KolZ5RWbFA40voYXzV8O78xRWs9IAbNLG9s3FJYsy6nZnh69sx69QDmAuw==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "693ab32b-602a-4ee4-8340-1fade105bc8f", "Панасенко", false, "User3@gmail.com" },
                    { "c86dc56aedf549f6afe5ceb4d414ebf1", 0, new DateTime(2000, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "3a9dc195-3f5f-4ef6-bd01-407997acd4f4", "User2@gmail.com", true, false, null, "Петро", null, "USER2@GMAIL.COM", "AQAAAAIAAYagAAAAEGTH1yzV4A4Ja3NesupAfRxDA2fqYJM8oWFy/jVXPcGIcwwgKhUKTS2EHeW0EfO5qw==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "a7786a38-1a27-43bb-b18c-946d1c46670d", "Дякуленко", false, "User2@gmail.com" },
                    { "d1901b2435594da2a255db13fc57509b", 0, new DateTime(1988, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "c6033a0b-4e62-4f2b-a19a-5cde3222fd76", "User1@gmail.com", true, false, null, "Iван", null, "USER1@GMAIL.COM", "AQAAAAIAAYagAAAAEDhHD7zHQzwRcM4L5jHQbG0a/H4Mq+YwK+pDMDIm7MHr56XcuZqK5pNIS3bKjobXMA==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "aacf966f-b3da-46d4-a275-31cb88e67c1f", "Калита", false, "User1@gmail.com" },
                    { "eb05f9548a2c4cf8adcc2be7305fc732", 0, new DateTime(2001, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "87b0728c-107b-45e1-a21a-d32d7eb6d53b", "User4@gmail.com", true, false, null, "Тимофій", null, "USER4@GMAIL.COM", "AQAAAAIAAYagAAAAEDgKlwTa9TBi0QSmSnL1uRQLXAqpKIaRQP8ZwRgR5Tbdr7TaA2qzZdyFxbv3wT1Gmw==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "b437218a-a199-462b-aec3-fc50da481190", "Гнатенко", false, "User4@gmail.com" },
                    { "f66e492517d7414495e988c4c50fd107", 0, new DateTime(1998, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "b88d682f-7491-4419-89f7-dc950763fc3c", "Admin@gmail.com", true, false, null, "Петро", null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEF23O0cX303SgShtP+FddMMYeiAe0/aRQ2my9xNNOrNnZOJbjfsr/0bvGVwsZGLeqw==", null, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "b89ff03f-fec7-4360-93bb-3c0de58823b5", "Левак", false, "Admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "CountryId", "Date", "Description", "MovieUrl", "Name", "OriginalName", "Poster", "PremiumId", "QualityId", "TrailerUrl" },
                values: new object[] { 1, 2, new DateTime(1995, 4, 25, 2, 57, 0, 0, DateTimeKind.Unspecified), "Фільм, що розповідає про боротьбу Шотландського королівства за незалежність проти англійського панування. Головний герой фільму — Вільям Воллес, ватажок шотландців, у виконанні Мела Гібсона.одії фільму починаються 1280 року. Це історія легендарного національного шотландського героя Вільяма Воллеса, який присвятив себе боротьбі з англійцями за часів короля Едуарда Довгоногого. Вільям рано втратив батька, що загинув від рук англійців, але його дядько зумів дати хлопцеві навчання в Європі. На батьківщину Вільям повертається вже дорослим чоловіком, що мріє завести родину і жити мирним життям. Та доля вирішила інакше. Його наречену вбили англійці, і він почав свій «хрестовий похід» за свободу.", "https://pixel.stream.voidboost.cc/c856f28d3535c356286e0fb2128b2cd4:2024022021:43f8ed35-e4ad-4d7d-bd42-7a4fe8d4055e/7/8/1/6/3/byf31.mp4", "Хоробре серце", "Braveheart", "82ff372d46f44895af282106fe13a201.jpg", 1, 3, "https://www.youtube.com/watch?v=277chVHPQSA&t=39s" });

            migrationBuilder.InsertData(
                table: "Staf",
                columns: new[] { "Id", "Birthdate", "CountryId", "Description", "ImageName", "IsOscar", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1956, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Народився 3 січня 1956 року.\r\n\r\nСин ірландців-католиків Гаттона Гібсона та Ен Райлі Гібсон, яка народилася в парафії Колм-Кіллє графства Лонгфорд, Ірландія. Його бабця по батькові Ева Майлот була австралійською оперною співачкою. Мел народився у місті Пікскілл (округ Вестчестер, штат Нью-Йорк) і був шостим з одинадцяти дітей. Один із молодших братів Мела, Донал, також актор.", "d5d49574945f45c8be24f00cc02923af.webp", true, "Мел", "Гибсон" },
                    { 2, new DateTime(1963, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, "Народився у сім'ї лікаря. У дитинстві подорожував між трьома країнами — Філіппінами, Сингапуром і Францією. Вищу освіту Енгус отримав у стінах Університету Единбурга, Шотландія. Паралельно з гризенням граніту науки молодий чоловік відвідував заняття в Центральній школі Мовлення та Драми в Лондоні, Англія.", "da0240d0882b4ec1942342ec6cf72505.jpg", false, "Енгус", "Макфадьєн" },
                    { 3, new DateTime(1966, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Народилася 17 листопада 1966 року в Париж, Франція.\r\n\r\nПрославилася підлітком, дебютувавши у «Вечірці» (La Boum, 1980). Вдало знайдений образ «ідеальної французької дівчини», якою Марсо визнали за підсумками глядацького опитування, було розмножено у фільмах «Вечірка-2» (фр. La Boum 2, 1982), «Щасливого Великодня» (1984), «Студентка» (1988), «Аромат кохання. Фанфан» (1993) тощо. Актрису часто залучали до найамбітніших проектів національної кіноіндустрії: «Форт Саґан», «Шуани!», «Дочка Д'Артаньяна», де вона втілювала ідеальну француженку, перетворившись із чарівного підлітка на одну з найкрасивіших актрис світового кіно.\r\n\r\n1999 року зіграла дівчину Бонда у черговому, 19-му за ліком, епізоді Бондіани — підступну, але дуже вразливу Електру Кінґ. Продовжує активно зніматися.", "c9b0972dd8b6431193cd50e9c272416f.jpg", false, "Софі", "Марсо" }
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
                columns: new[] { "Id", "MovieId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Чудовий фільм", "d1901b2435594da2a255db13fc57509b" },
                    { 2, 1, "Фільм дуже сподобався", "c86dc56aedf549f6afe5ceb4d414ebf1" }
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
                table: "MovieImage",
                columns: new[] { "Id", "ImageId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 7, 7, 1 }
                });

            migrationBuilder.InsertData(
                table: "StafMovie",
                columns: new[] { "Id", "MovieId", "StafId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 }
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
                    { 5, 3, 2 }
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
                name: "IX_MovieImage_ImageId",
                table: "MovieImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieImage_MovieId",
                table: "MovieImage",
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
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "MovieImage");

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
                name: "Image");

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
