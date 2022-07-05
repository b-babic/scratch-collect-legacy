using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace scratch_collect.API.Migrations
{
    public partial class InitialSeedUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserOffers");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GradientStart = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    GradientStop = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "ntext", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    RequiredPrice = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Merchants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchants_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    WalletId = table.Column<int>(type: "int", nullable: true)
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
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UsedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Users_UsedById",
                        column: x => x.UsedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RateCount = table.Column<double>(type: "float", nullable: false),
                    RatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Played = table.Column<bool>(type: "bit", nullable: false),
                    BoughtOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Won = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOffers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOffers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "GradientStart", "GradientStop", "Name" },
                values: new object[,]
                {
                    { 1, "#BDC3C7", "#2C3E50", "Luxury" },
                    { 2, "#36D1DC", "#5B86E5", "Sports" },
                    { 3, "#DAD299", "#B0DAB9", "Food" },
                    { 4, "#E1EEC3", "#F05053", "Travel" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "AF", "Afghanistan" },
                    { 2, "AX", "Åland Islands" },
                    { 3, "AL", "Albania" },
                    { 4, "DZ", "Algeria" },
                    { 5, "AS", "American Samoa" },
                    { 6, "AD", "AndorrA" },
                    { 7, "AO", "Angola" },
                    { 8, "AI", "Anguilla" },
                    { 9, "AQ", "Antarctica" },
                    { 10, "AG", "Antigua and Barbuda" },
                    { 11, "AR", "Argentina" },
                    { 12, "AM", "Armenia" },
                    { 13, "AW", "Aruba" },
                    { 14, "AU", "Australia" },
                    { 15, "AT", "Austria" },
                    { 16, "AZ", "Azerbaijan" },
                    { 17, "BS", "Bahamas" },
                    { 18, "BH", "Bahrain" },
                    { 19, "BD", "Bangladesh" },
                    { 20, "BB", "Barbados" },
                    { 21, "BY", "Belarus" },
                    { 22, "BE", "Belgium" },
                    { 23, "BZ", "Belize" },
                    { 24, "BJ", "Benin" },
                    { 25, "BM", "Bermuda" },
                    { 26, "BT", "Bhutan" },
                    { 27, "BO", "Bolivia" },
                    { 28, "BA", "Bosnia and Herzegovina" },
                    { 29, "BW", "Botswana" },
                    { 30, "BV", "Bouvet Island" },
                    { 31, "BR", "Brazil" },
                    { 32, "IO", "British Indian Ocean Territory" },
                    { 33, "BN", "Brunei Darussalam" },
                    { 34, "BG", "Bulgaria" },
                    { 35, "BF", "Burkina Faso" },
                    { 36, "BI", "Burundi" },
                    { 37, "KH", "Cambodia" },
                    { 38, "CM", "Cameroon" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 39, "CA", "Canada" },
                    { 40, "CV", "Cape Verde" },
                    { 41, "KY", "Cayman Islands" },
                    { 42, "CF", "Central African Republic" },
                    { 43, "TD", "Chad" },
                    { 44, "CL", "Chile" },
                    { 45, "CN", "China" },
                    { 46, "CX", "Christmas Island" },
                    { 47, "CC", "Cocos (Keeling) Islands" },
                    { 48, "CO", "Colombia" },
                    { 49, "KM", "Comoros" },
                    { 50, "CG", "Congo" },
                    { 51, "CD", "Congo, The Democratic Republic of the" },
                    { 52, "CK", "Cook Islands" },
                    { 53, "CR", "Costa Rica" },
                    { 54, "CI", "Cote D'Ivoire" },
                    { 55, "HR", "Croatia" },
                    { 56, "CU", "Cuba" },
                    { 57, "CY", "Cyprus" },
                    { 58, "CZ", "Czech Republic" },
                    { 59, "DK", "Denmark" },
                    { 60, "DJ", "Djibouti" },
                    { 61, "DM", "Dominica" },
                    { 62, "DO", "Dominican Republic" },
                    { 63, "EC", "Ecuador" },
                    { 64, "EG", "Egypt" },
                    { 65, "SV", "El Salvador" },
                    { 66, "GQ", "Equatorial Guinea" },
                    { 67, "ER", "Eritrea" },
                    { 68, "EE", "Estonia" },
                    { 69, "ET", "Ethiopia" },
                    { 70, "FK", "Falkland Islands (Malvinas)" },
                    { 71, "FO", "Faroe Islands" },
                    { 72, "FJ", "Fiji" },
                    { 73, "FI", "Finland" },
                    { 74, "FR", "France" },
                    { 75, "GF", "French Guiana" },
                    { 76, "PF", "French Polynesia" },
                    { 77, "TF", "French Southern Territories" },
                    { 78, "GA", "Gabon" },
                    { 79, "GM", "Gambia" },
                    { 80, "GE", "Georgia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 81, "DE", "Germany" },
                    { 82, "GH", "Ghana" },
                    { 83, "GI", "Gibraltar" },
                    { 84, "GR", "Greece" },
                    { 85, "GL", "Greenland" },
                    { 86, "GD", "Grenada" },
                    { 87, "GP", "Guadeloupe" },
                    { 88, "GU", "Guam" },
                    { 89, "GT", "Guatemala" },
                    { 90, "GG", "Guernsey" },
                    { 91, "GN", "Guinea" },
                    { 92, "GW", "Guinea-Bissau" },
                    { 93, "GY", "Guyana" },
                    { 94, "HT", "Haiti" },
                    { 95, "HM", "Heard Island and Mcdonald Islands" },
                    { 96, "VA", "Holy See (Vatican City State)" },
                    { 97, "HN", "Honduras" },
                    { 98, "HK", "Hong Kong" },
                    { 99, "HU", "Hungary" },
                    { 100, "IS", "Iceland" },
                    { 101, "IN", "India" },
                    { 102, "ID", "Indonesia" },
                    { 103, "IR", "Iran, Islamic Republic Of" },
                    { 104, "IQ", "Iraq" },
                    { 105, "IE", "Ireland" },
                    { 106, "IM", "Isle of Man" },
                    { 107, "IL", "Israel" },
                    { 108, "IT", "Italy" },
                    { 109, "JM", "Jamaica" },
                    { 110, "JP", "Japan" },
                    { 111, "JE", "Jersey" },
                    { 112, "JO", "Jordan" },
                    { 113, "KZ", "Kazakhstan" },
                    { 114, "KE", "Kenya" },
                    { 115, "KI", "Kiribati" },
                    { 116, "KP", "Korea, Democratic People'S Republic of" },
                    { 117, "KR", "Korea, Republic of" },
                    { 118, "KW", "Kuwait" },
                    { 119, "KG", "Kyrgyzstan" },
                    { 120, "LA", "Lao People'S Democratic Republic" },
                    { 121, "LV", "Latvia" },
                    { 122, "LB", "Lebanon" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 123, "LS", "Lesotho" },
                    { 124, "LR", "Liberia" },
                    { 125, "LY", "Libyan Arab Jamahiriya" },
                    { 126, "LI", "Liechtenstein" },
                    { 127, "LT", "Lithuania" },
                    { 128, "LU", "Luxembourg" },
                    { 129, "MO", "Macao" },
                    { 130, "MK", "Macedonia, The Former Yugoslav Republic of" },
                    { 131, "MG", "Madagascar" },
                    { 132, "MW", "Malawi" },
                    { 133, "MY", "Malaysia" },
                    { 134, "MV", "Maldives" },
                    { 135, "ML", "Mali" },
                    { 136, "MT", "Malta" },
                    { 137, "MH", "Marshall Islands" },
                    { 138, "MQ", "Martinique" },
                    { 139, "MR", "Mauritania" },
                    { 140, "MU", "Mauritius" },
                    { 141, "YT", "Mayotte" },
                    { 142, "MX", "Mexico" },
                    { 143, "FM", "Micronesia, Federated States of" },
                    { 144, "MD", "Moldova, Republic of" },
                    { 145, "MC", "Monaco" },
                    { 146, "MN", "Mongolia" },
                    { 147, "MS", "Montserrat" },
                    { 148, "MA", "Morocco" },
                    { 149, "MZ", "Mozambique" },
                    { 150, "MM", "Myanmar" },
                    { 151, "NA", "Namibia" },
                    { 152, "NR", "Nauru" },
                    { 153, "NP", "Nepal" },
                    { 154, "NL", "Netherlands" },
                    { 155, "AN", "Netherlands Antilles" },
                    { 156, "NC", "New Caledonia" },
                    { 157, "NZ", "New Zealand" },
                    { 158, "NI", "Nicaragua" },
                    { 159, "NE", "Niger" },
                    { 160, "NG", "Nigeria" },
                    { 161, "NU", "Niue" },
                    { 162, "NF", "Norfolk Island" },
                    { 163, "MP", "Northern Mariana Islands" },
                    { 164, "NO", "Norway" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 165, "OM", "Oman" },
                    { 166, "PK", "Pakistan" },
                    { 167, "PW", "Palau" },
                    { 168, "PS", "Palestinian Territory, Occupied" },
                    { 169, "PA", "Panama" },
                    { 170, "PG", "Papua New Guinea" },
                    { 171, "PY", "Paraguay" },
                    { 172, "PE", "Peru" },
                    { 173, "PH", "Philippines" },
                    { 174, "PN", "Pitcairn" },
                    { 175, "PL", "Poland" },
                    { 176, "PT", "Portugal" },
                    { 177, "PR", "Puerto Rico" },
                    { 178, "QA", "Qatar" },
                    { 179, "RE", "Reunion" },
                    { 180, "RO", "Romania" },
                    { 181, "RU", "Russian Federation" },
                    { 182, "RW", "RWANDA" },
                    { 183, "SH", "Saint Helena" },
                    { 184, "KN", "Saint Kitts and Nevis" },
                    { 185, "LC", "Saint Lucia" },
                    { 186, "PM", "Saint Pierre and Miquelon" },
                    { 187, "VC", "Saint Vincent and the Grenadines" },
                    { 188, "WS", "Samoa" },
                    { 189, "SM", "San Marino" },
                    { 190, "ST", "Sao Tome and Principe" },
                    { 191, "SA", "Saudi Arabia" },
                    { 192, "SN", "Senegal" },
                    { 193, "CS", "Serbia and Montenegro" },
                    { 194, "SC", "Seychelles" },
                    { 195, "SL", "Sierra Leone" },
                    { 196, "SG", "Singapore" },
                    { 197, "SK", "Slovakia" },
                    { 198, "SI", "Slovenia" },
                    { 199, "SB", "Solomon Islands" },
                    { 200, "SO", "Somalia" },
                    { 201, "ZA", "South Africa" },
                    { 202, "GS", "South Georgia and the South Sandwich Islands" },
                    { 203, "ES", "Spain" },
                    { 204, "LK", "Sri Lanka" },
                    { 205, "SD", "Sudan" },
                    { 206, "SR", "Suriname" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 207, "SJ", "Svalbard and Jan Mayen" },
                    { 208, "SZ", "Swaziland" },
                    { 209, "SE", "Sweden" },
                    { 210, "CH", "Switzerland" },
                    { 211, "SY", "Syrian Arab Republic" },
                    { 212, "TW", "Taiwan, Province of China" },
                    { 213, "TJ", "Tajikistan" },
                    { 214, "TZ", "Tanzania, United Republic of" },
                    { 215, "TH", "Thailand" },
                    { 216, "TL", "Timor-Leste" },
                    { 217, "TG", "Togo" },
                    { 218, "TK", "Tokelau" },
                    { 219, "TO", "Tonga" },
                    { 220, "TT", "Trinidad and Tobago" },
                    { 221, "TN", "Tunisia" },
                    { 222, "TR", "Turkey" },
                    { 223, "TM", "Turkmenistan" },
                    { 224, "TC", "Turks and Caicos Islands" },
                    { 225, "TV", "Tuvalu" },
                    { 226, "UG", "Uganda" },
                    { 227, "UA", "Ukraine" },
                    { 228, "AE", "United Arab Emirates" },
                    { 229, "GB", "United Kingdom" },
                    { 230, "US", "United States" },
                    { 231, "UM", "United States Minor Outlying Islands" },
                    { 232, "UY", "Uruguay" },
                    { 233, "UZ", "Uzbekistan" },
                    { 234, "VU", "Vanuatu" },
                    { 235, "VE", "Venezuela" },
                    { 236, "VN", "Viet Nam" },
                    { 237, "VG", "Virgin Islands, British" },
                    { 238, "VI", "Virgin Islands, U.S." },
                    { 239, "WF", "Wallis and Futuna" },
                    { 240, "EH", "Western Sahara" },
                    { 241, "YE", "Yemen" },
                    { 242, "ZM", "Zambia" },
                    { 243, "ZW", "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CreatedAt", "Text", "UsedAt", "UsedById", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "804C-4D13", null, null, 15 },
                    { 2, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "4422-83E8", null, null, 15 },
                    { 3, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "4492-BD28", null, null, 30 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator role", "Administrator" },
                    { 2, "Client role", "Client" }
                });

            migrationBuilder.InsertData(
                table: "Merchants",
                columns: new[] { "Id", "Address", "CountryId", "CreatedAt", "Name", "Telephone" },
                values: new object[,]
                {
                    { 1, "3899 Forest Avenue", 230, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "Altria Group", "646-836-5972" },
                    { 2, "2610 Apple Lane", 230, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "Halliburton", "309-343-8619" },
                    { 3, "2833 Winifred Way", 229, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "Aramark", "765-676-8245" },
                    { 4, "189 Desert Broom Court", 229, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "DISH Network", "201-705-6273" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Quantity", "RequiredPrice", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 4, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to London, a vibrant city with a diverse range of people and culture in Britain. Relax after check-in at your centrally located hotel or take a stroll down Oxford Street - the most famous shopping streets in the world. Your Local Hosts will be on hand to help you make the most of your time.", 15, 15, "A Week in London by Private Car 2022", new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2022, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isabel Marant's takes on bohemian peasant dresses are exceptionally cool. This 'Caroline' midi style is cut from deep charcoal silk-satin that's gathered throughout and embroidered with folksy floral trims. Wear it with a pair of the designer's chic ankle boots.", 1, 15, "Caroline embroidered silk-satin midi dress", new DateTime(2022, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4, new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to London! Relax after check-in at your centrally located hotel or take a stroll down Oxford Street, one of the most famous shopping streets in the world. This evening, meet your companions and Travel Director for a Welcome Reception, which includes a light meal and drinks.", 1, 15, "Best of London and Edinburgh 2022", new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Men's hiking trousers with capability for quick conversion to shorts, ideal combination of breathability and stretch", 15, 30, "Columbia Men's Silver Ridge 2 Convertible Hiking Trousers", new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keep your food safe and sealed with this set of three airtight storage containers. Their airtight design keeps your food fresher for longer, and the transparent plastic sides mean you'll know when you're running low. The lids fit easily and create an airtight seal using the handy tensioning levers - simply lift the lever up to release the seal, and push it down to reseal. No pulling or yanking required.", 12, 50, "Argos Home Set of 3 Airtight Food Storage Containers", new DateTime(2021, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2022, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Attico's 'Elettra' sandals are ideal for balmy weather. Made in Italy from black patent-leather, they have chic squared toes and slinky ties that fasten around the ankles. Wear yours with cropped pants or midi skirts.", 9, 30, "Elettra patent-leather sandals", new DateTime(2022, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 4, new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to Paris, capital of France and the City of Light. After check-in to your hotel - the ideal spot for your exploration of this magnificent city. you can relax or take a stroll in the local neighbourhood. This afternoon meet your Travel Director and fellow travellers to attend a Welcome Reception in the heart of the city.", 13, 30, "Best Paris Explorer Summer 2022", new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to Madrid. Relax or explore this lively city before meeting up with your fellow travellers and Travel Director. Enjoy an evening drive to take in some of the city's main sights followed by a Welcome Reception.", 10, 30, "Holidays in Spain 2022", new DateTime(2022, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jimmy Choo's 'Memphis' sneakers will look so cool whether you wear them running errands at the weekend or for a post-gym brunch. Designed to slip on, they have tonal leather and neoprene uppers so they feel comfortable and secure. The chunky 30mm rubber soles feature crystal-style embellishments around the back.", 12, 50, "Memphis nylon and leather slip-on sneakers", new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 4, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indulge all your senses in the imperial city of Rome, your introduction to a memorable encounter with Italy which will have you returning for more. Spend your afternoon relaxing after your journey, or explore the ancient city streets before joining your Travel Director and travel companions for a Welcome Reception. This evening, we whet our appetites with an orientation drive past Rome's most magnificent sights which we will have an opportunity to explore tomorrow.", 13, 50, "Italian Holiday Summer 2022", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "FRAME's 'Lounge' jeans are well-named - the shape is nice and slouchy and they have elasticated cuffs just like track pants. The faded wash makes them look and feel lovingly worn-in.", 7, 30, "The Lounge cropped high-rise jeans", new DateTime(2022, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 3, new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lower in calories and fat than our standard adult diets with the addition of L-carnitine may help to increase the conversion of fat to energy and maintain lean body mass", 13, 50, "Arden Grange Light Adult Dry Dog Food", new DateTime(2022, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexander McQueen's 'The Bundle' bag is made from shell reinforced with smooth leather trims. Secured with a drawstring top, it has a front zipped pocket and a sizable interior that'll fit your everyday essentials. Adjust the shoulder strap to carry it cross-body.", 9, 50, "The Bundle medium leather-trimmed metallic printed shell shoulder bag", new DateTime(2021, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 2, new DateTime(2021, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Justo maecenas rhoncus aliquam lacus morbi quis tortor id nulla ultrices aliquet maecenas leo odio condimentum id luctus nec molestie sed justo pellentesque viverra pede ac diam cras pellentesque volutpat dui maecenas tristique est et tempus semper est quam pharetra magna ac", 13, 15, "Bike assembly and maintenance stand", new DateTime(2021, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 2, new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Move your items with ease with this Adventuridge Festival Trolley.", 15, 30, "Adventuridge Folding Camping Festival Trolley", new DateTime(2021, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 4, new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Welcome to Rome. After check-in, relax and unwind. Later meet with your Travel Director and fellow travellers. This evening, stroll around this fascinating city and take in the vibrant atmosphere.", 13, 50, "Italian Scene - Costsaver Summer 2022", new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 2, new DateTime(2021, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Vitus Sommet 297 CRX is a high-quality enduro race bike that is engineered and equipped to offer the greatest performance imaginable. It features a carbon/alloy frame adorned with 170mm-travel Kashima-coated Fox Float Factory suspension and a 12-Speed Shimano XT M8100 wide-range groupset.", 1, 15, "Vitus Sommet Enduro Bike Top Spec Fox Factory", new DateTime(2021, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 3, new DateTime(2021, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quick Chopping & Mixing - With the 600W powerful motor, Nestling Electric Food Chopper can easily chop and mix kinds of meats, fruits and vegetables in 6~8 seconds. Very convenient to make kinds of meatballs & meat pies, or to prepare food for your pets.", 6, 15, "Nestling 600W Kitchen Mini Food Chopper", new DateTime(2021, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 3, new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "40 piece set includes 20 containers with 20 lids. Store and transport entrees and soups confidently with our revolutionary snap-lock containers. Also great for small arts and crafts supplies like beads.", 13, 50, "Set of 40 Airtight Food Storage Container Set", new DateTime(2022, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 2, new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "The NRGY Comet is all about energized cushioning, and a flexible and lightweight running experience.", 1, 30, "Puma NRGY Comet Running Trainers", new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "RegisteredAt", "RoleId", "Token", "UserPhoto", "Username", "WalletId" },
                values: new object[,]
                {
                    { 1, "Hogwarts 10", "desktop@test.com", "John", "Doe", "lZjMPngWFTVkSHSrTDtHDBXuuB4=", "TFnNKEmsjdYcyDMXeYXLwQ==", new DateTime(2020, 8, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 2, 0, 0, 0, 2, 0, 8, 3, 0, 0, 0, 195, 166, 36, 200, 0, 0, 0, 33, 80, 76, 84, 69, 76, 105, 113, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 155, 45, 34, 217, 0, 0, 0, 10, 116, 82, 78, 83, 0, 23, 240, 165, 48, 79, 138, 111, 219, 196, 176, 138, 215, 89, 0, 0, 9, 112, 73, 68, 65, 84, 120, 218, 237, 221, 9, 114, 235, 214, 14, 132, 225, 203, 121, 216, 255, 130, 95, 37, 55, 201, 155, 108, 89, 20, 15, 135, 195, 254, 254, 5, 184, 84, 2, 4, 116, 3, 32, 253, 235, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 127, 211, 52, 125, 63, 12, 211, 52, 141, 227, 52, 77, 195, 208, 247, 77, 227, 91, 137, 136, 252, 48, 117, 75, 187, 126, 73, 187, 116, 211, 32, 15, 158, 27, 250, 177, 155, 215, 55, 152, 187, 81, 26, 60, 47, 248, 203, 186, 137, 69, 18, 60, 134, 126, 107, 240, 255, 157, 4, 189, 111, 175, 118, 134, 174, 93, 119, 208, 118, 131, 239, 176, 230, 223, 254, 174, 232, 255, 149, 3, 234, 64, 165, 125, 127, 154, 215, 66, 204, 19, 61, 80, 27, 211, 178, 22, 101, 153, 124, 167, 53, 133, 127, 94, 139, 51, 75, 129, 106, 106, 127, 187, 30, 66, 171, 19, 212, 16, 254, 241, 160, 240, 255, 22, 132, 82, 32, 56, 252, 82, 224, 254, 189, 255, 224, 240, 255, 78, 1, 223, 243, 93, 135, 62, 243, 122, 10, 179, 225, 208, 45, 171, 127, 183, 158, 70, 167, 15, 68, 86, 255, 255, 52, 4, 190, 241, 91, 209, 207, 235, 201, 232, 3, 119, 162, 91, 47, 64, 31, 200, 253, 249, 255, 85, 4, 108, 137, 2, 187, 63, 37, 160, 252, 107, 3, 202, 191, 54, 16, 95, 254, 181, 129, 248, 242, 255, 79, 27, 16, 135, 171, 88, 214, 91, 176, 136, 196, 37, 52, 55, 137, 255, 186, 46, 164, 224, 21, 241, 159, 215, 219, 48, 203, 128, 56, 249, 207, 12, 92, 28, 255, 118, 189, 21, 173, 12, 56, 149, 225, 102, 241, 95, 215, 214, 114, 232, 204, 248, 175, 55, 68, 6, 196, 214, 127, 93, 64, 252, 101, 64, 166, 255, 227, 6, 197, 95, 6, 100, 206, 127, 77, 133, 197, 95, 6, 92, 64, 183, 222, 28, 187, 193, 67, 153, 214, 219, 227, 62, 224, 72, 3, 184, 86, 0, 51, 24, 105, 0, 88, 1, 2, 128, 12, 32, 0, 200, 128, 192, 9, 176, 153, 48, 1, 64, 6, 16, 0, 100, 192, 193, 12, 107, 85, 56, 14, 40, 205, 92, 87, 2, 204, 34, 22, 234, 0, 56, 129, 99, 20, 96, 91, 91, 2, 180, 116, 96, 172, 2, 164, 3, 211, 21, 32, 29, 24, 174, 0, 233, 192, 194, 140, 107, 149, 120, 163, 100, 41, 5, 184, 86, 10, 29, 24, 93, 0, 148, 128, 88, 11, 200, 10, 42, 0, 74, 128, 2, 160, 4, 196, 23, 0, 37, 32, 188, 0, 40, 1, 5, 152, 214, 170, 177, 19, 218, 75, 91, 119, 2, 180, 34, 24, 93, 0, 148, 128, 189, 44, 181, 39, 128, 135, 5, 119, 209, 175, 213, 227, 66, 56, 214, 3, 114, 130, 251, 153, 235, 79, 0, 91, 225, 236, 14, 160, 7, 236, 161, 123, 66, 2, 184, 13, 139, 29, 2, 24, 5, 236, 100, 88, 31, 129, 227, 192, 232, 14, 160, 7, 124, 206, 250, 16, 68, 50, 186, 3, 232, 1, 193, 83, 32, 179, 160, 232, 61, 128, 125, 192, 46, 154, 245, 49, 56, 11, 137, 150, 0, 68, 64, 184, 4, 32, 2, 98, 23, 65, 22, 66, 36, 0, 17, 64, 2, 16, 1, 233, 18, 128, 8, 8, 94, 4, 88, 7, 208, 128, 84, 96, 244, 38, 200, 62, 232, 51, 250, 103, 37, 128, 187, 176, 104, 19, 192, 6, 108, 103, 122, 86, 2, 120, 64, 40, 218, 4, 176, 1, 219, 89, 158, 149, 0, 54, 194, 91, 105, 159, 149, 0, 78, 131, 147, 55, 1, 182, 1, 18, 64, 2, 100, 143, 1, 12, 2, 36, 128, 152, 38, 207, 129, 76, 130, 36, 128, 152, 74, 0, 196, 78, 130, 205, 130, 37, 128, 152, 110, 98, 124, 90, 2, 56, 10, 147, 0, 144, 0, 144, 0, 32, 2, 33, 1, 32, 1, 96, 18, 8, 9, 0, 9, 128, 47, 112, 15, 32, 1, 36, 64, 52, 79, 75, 0, 17, 221, 200, 252, 172, 248, 123, 60, 120, 43, 30, 12, 9, 199, 163, 97, 182, 65, 118, 65, 6, 1, 198, 0, 124, 32, 23, 152, 201, 195, 158, 13, 243, 100, 216, 102, 30, 245, 120, 176, 135, 131, 195, 125, 32, 23, 24, 110, 3, 152, 128, 112, 27, 192, 4, 132, 171, 64, 26, 48, 123, 27, 96, 19, 16, 62, 12, 54, 8, 254, 132, 7, 221, 133, 186, 8, 13, 159, 5, 154, 3, 102, 139, 0, 18, 32, 124, 18, 96, 10, 16, 62, 9, 48, 5, 200, 94, 7, 88, 4, 132, 27, 65, 38, 48, 188, 7, 232, 0, 217, 61, 64, 7, 8, 239, 1, 58, 64, 120, 15, 208, 1, 178, 123, 128, 14, 16, 62, 11, 50, 5, 10, 223, 7, 216, 3, 236, 162, 250, 203, 64, 215, 128, 225, 50, 144, 4, 204, 150, 129, 36, 96, 184, 12, 36, 1, 247, 82, 249, 109, 168, 107, 208, 236, 105, 160, 41, 96, 120, 9, 80, 0, 178, 85, 0, 5, 80, 164, 4, 84, 107, 4, 90, 5, 32, 187, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 202, 81, 229, 83, 98, 158, 7, 43, 72, 133, 75, 65, 107, 192, 146, 84, 120, 23, 224, 14, 32, 91, 7, 82, 128, 133, 169, 236, 73, 81, 207, 131, 150, 166, 178, 203, 16, 119, 32, 197, 169, 106, 43, 104, 11, 120, 192, 48, 160, 162, 38, 48, 27, 1, 100, 59, 1, 14, 32, 123, 28, 100, 4, 148, 45, 3, 8, 128, 108, 25, 64, 0, 132, 203, 0, 2, 32, 91, 6, 16, 0, 217, 50, 128, 0, 200, 206, 0, 241, 63, 156, 91, 111, 134, 237, 128, 179, 173, 0, 3, 112, 74, 6, 220, 246, 64, 204, 17, 216, 73, 102, 240, 166, 25, 208, 50, 128, 209, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 167, 103, 192, 173, 220, 224, 44, 254, 209, 243, 0, 254, 255, 146, 12, 184, 205, 76, 112, 17, 255, 107, 184, 201, 94, 192, 252, 255, 50, 110, 177, 29, 182, 255, 189, 144, 225, 114, 51, 208, 122, 2, 32, 218, 12, 144, 255, 151, 75, 193, 75, 133, 64, 71, 254, 221, 64, 8, 92, 214, 6, 90, 237, 255, 204, 159, 250, 216, 220, 204, 15, 126, 235, 254, 190, 255, 168, 216, 243, 59, 255, 126, 220, 58, 221, 234, 231, 223, 183, 106, 67, 113, 181, 63, 191, 86, 220, 253, 233, 69, 96, 233, 95, 59, 147, 153, 59, 40, 40, 245, 255, 9, 239, 247, 223, 234, 201, 111, 144, 248, 254, 253, 15, 195, 207, 41, 130, 207, 117, 254, 244, 235, 14, 69, 224, 69, 108, 39, 30, 225, 88, 145, 63, 254, 212, 39, 78, 240, 254, 47, 170, 251, 200, 38, 28, 61, 232, 233, 46, 118, 132, 47, 131, 218, 25, 20, 149, 101, 220, 184, 123, 105, 198, 131, 83, 160, 125, 233, 240, 186, 77, 106, 1, 239, 105, 255, 109, 219, 215, 99, 39, 131, 47, 187, 250, 55, 243, 8, 126, 160, 248, 144, 247, 245, 2, 230, 176, 42, 240, 250, 215, 255, 98, 49, 69, 12, 126, 244, 243, 111, 63, 114, 97, 127, 166, 192, 116, 128, 28, 156, 167, 102, 115, 183, 178, 50, 60, 224, 231, 255, 222, 17, 206, 80, 216, 20, 46, 63, 132, 240, 167, 113, 180, 34, 80, 240, 231, 255, 222, 143, 170, 239, 138, 117, 130, 182, 235, 143, 255, 188, 216, 58, 214, 251, 89, 94, 15, 37, 114, 160, 237, 134, 179, 62, 47, 222, 43, 167, 91, 110, 49, 119, 230, 192, 59, 209, 47, 250, 121, 177, 229, 204, 235, 173, 65, 91, 51, 116, 31, 74, 194, 185, 27, 222, 9, 217, 251, 211, 39, 109, 224, 29, 54, 249, 248, 55, 7, 109, 219, 147, 224, 205, 224, 111, 189, 73, 211, 6, 202, 126, 159, 91, 228, 117, 51, 140, 203, 91, 191, 213, 118, 25, 135, 183, 255, 232, 214, 177, 147, 21, 97, 169, 242, 255, 217, 194, 165, 233, 135, 177, 251, 46, 15, 218, 165, 27, 135, 126, 75, 163, 254, 96, 247, 160, 13, 236, 86, 211, 5, 126, 85, 77, 223, 15, 195, 48, 77, 227, 216, 117, 227, 56, 77, 195, 48, 244, 253, 102, 137, 246, 225, 2, 218, 134, 176, 76, 251, 255, 175, 214, 122, 129, 190, 110, 62, 62, 65, 241, 36, 209, 62, 55, 245, 117, 31, 56, 57, 5, 154, 61, 155, 103, 126, 240, 203, 130, 186, 111, 104, 211, 158, 89, 5, 246, 238, 155, 92, 9, 20, 145, 127, 87, 165, 64, 129, 117, 35, 41, 88, 70, 254, 93, 145, 2, 133, 182, 205, 38, 2, 101, 228, 223, 255, 9, 172, 131, 139, 107, 95, 238, 147, 138, 250, 1, 241, 255, 227, 139, 61, 176, 186, 14, 69, 63, 168, 184, 23, 144, 255, 159, 109, 111, 63, 252, 241, 23, 190, 52, 98, 6, 142, 137, 255, 159, 50, 187, 180, 26, 104, 198, 3, 142, 140, 100, 192, 175, 3, 95, 246, 180, 148, 27, 13, 52, 211, 65, 15, 157, 120, 185, 212, 177, 111, 120, 232, 166, 2, 189, 160, 159, 14, 188, 51, 54, 16, 56, 250, 133, 143, 237, 174, 36, 232, 167, 238, 232, 207, 215, 139, 255, 241, 143, 114, 117, 159, 116, 131, 102, 234, 206, 120, 212, 44, 59, 3, 206, 123, 225, 235, 220, 141, 211, 187, 251, 190, 166, 159, 198, 238, 180, 119, 15, 37, 103, 192, 233, 47, 252, 109, 151, 110, 26, 94, 124, 225, 253, 48, 117, 203, 233, 31, 170, 23, 255, 179, 191, 242, 121, 94, 150, 191, 47, 1, 126, 95, 5, 44, 203, 60, 95, 246, 113, 66, 51, 160, 166, 127, 7, 126, 112, 127, 106, 196, 95, 6, 136, 191, 12, 48, 255, 205, 37, 110, 42, 44, 254, 255, 155, 1, 89, 241, 239, 68, 60, 122, 59, 60, 138, 119, 244, 141, 208, 32, 218, 95, 17, 115, 39, 216, 139, 245, 215, 132, 12, 132, 238, 251, 191, 127, 175, 38, 227, 127, 15, 27, 0, 132, 143, 3, 24, 192, 108, 51, 200, 0, 100, 91, 1, 6, 32, 219, 10, 244, 4, 224, 79, 66, 240, 217, 86, 128, 0, 252, 89, 8, 154, 0, 155, 9, 63, 149, 73, 116, 163, 101, 0, 1, 144, 45, 3, 76, 128, 194, 101, 0, 1, 144, 45, 3, 8, 128, 108, 25, 96, 5, 20, 190, 22, 178, 2, 200, 110, 2, 26, 64, 118, 19, 208, 0, 194, 155, 0, 7, 144, 221, 4, 236, 0, 179, 155, 128, 6, 16, 222, 4, 52, 128, 236, 38, 160, 1, 132, 55, 1, 59, 128, 236, 157, 128, 43, 192, 143, 25, 41, 64, 58, 144, 2, 164, 3, 41, 64, 58, 144, 2, 164, 3, 45, 129, 34, 153, 40, 64, 58, 144, 5, 100, 5, 43, 197, 155, 0, 10, 80, 243, 141, 48, 11, 152, 109, 5, 21, 128, 240, 18, 160, 0, 100, 151, 0, 5, 32, 188, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 194, 75, 128, 2, 144, 93, 2, 26, 81, 43, 73, 125, 27, 1, 91, 128, 240, 141, 128, 53, 96, 81, 90, 119, 0, 225, 212, 118, 23, 224, 16, 168, 48, 149, 157, 6, 185, 4, 44, 78, 93, 215, 129, 60, 96, 182, 19, 228, 1, 195, 157, 32, 15, 24, 238, 4, 121, 192, 108, 39, 200, 3, 134, 59, 65, 111, 4, 59, 132, 133, 4, 36, 3, 117, 0, 61, 192, 20, 208, 52, 208, 37, 72, 40, 117, 220, 133, 24, 2, 132, 143, 2, 116, 128, 236, 30, 96, 15, 116, 32, 53, 108, 132, 236, 129, 14, 164, 134, 141, 144, 49, 112, 246, 56, 88, 7, 8, 239, 1, 60, 64, 184, 15, 224, 1, 178, 125, 128, 41, 80, 248, 44, 200, 30, 224, 96, 238, 190, 15, 176, 9, 62, 152, 155, 239, 132, 109, 130, 15, 231, 222, 59, 97, 38, 48, 220, 8, 26, 3, 134, 15, 3, 141, 1, 179, 135, 129, 76, 96, 184, 17, 100, 2, 195, 141, 32, 9, 16, 46, 2, 204, 129, 179, 167, 193, 166, 0, 225, 147, 0, 83, 128, 240, 73, 128, 85, 240, 41, 220, 119, 37, 108, 17, 112, 10, 247, 93, 7, 136, 205, 57, 24, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 209, 128, 84, 32, 13, 72, 5, 154, 3, 154, 5, 50, 1, 108, 0, 19, 192, 6, 24, 4, 27, 6, 187, 7, 124, 62, 183, 188, 11, 116, 12, 112, 34, 13, 19, 192, 6, 48, 1, 108, 128, 107, 144, 84, 70, 9, 32, 1, 36, 128, 4, 160, 1, 104, 0, 46, 128, 11, 184, 203, 28, 192, 32, 232, 188, 65, 208, 45, 31, 13, 176, 11, 56, 141, 123, 238, 2, 220, 3, 156, 198, 77, 175, 66, 249, 128, 96, 15, 96, 31, 120, 30, 247, 125, 48, 164, 145, 1, 103, 196, 255, 198, 175, 137, 146, 1, 217, 241, 255, 99, 28, 196, 12, 30, 107, 0, 111, 255, 143, 163, 154, 78, 10, 28, 23, 254, 174, 138, 255, 28, 55, 140, 203, 44, 11, 74, 199, 126, 94, 198, 186, 254, 131, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 247, 231, 95, 23, 190, 217, 98, 181, 249, 103, 109, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "desktop", null },
                    { 2, "Hogwarts 11", "mobile@test.com", "Jane", "Doe", "AT+j0mc/FSQSqhwwcGOAzTg6VbQ=", "6A/p2PwGYsrquhu1AK9eIw==", new DateTime(2020, 9, 7, 22, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 2, 0, 0, 0, 2, 0, 8, 3, 0, 0, 0, 195, 166, 36, 200, 0, 0, 0, 33, 80, 76, 84, 69, 76, 105, 113, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 155, 45, 34, 217, 0, 0, 0, 10, 116, 82, 78, 83, 0, 23, 240, 165, 48, 79, 138, 111, 219, 196, 176, 138, 215, 89, 0, 0, 9, 112, 73, 68, 65, 84, 120, 218, 237, 221, 9, 114, 235, 214, 14, 132, 225, 203, 121, 216, 255, 130, 95, 37, 55, 201, 155, 108, 89, 20, 15, 135, 195, 254, 254, 5, 184, 84, 2, 4, 116, 3, 32, 253, 235, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 127, 211, 52, 125, 63, 12, 211, 52, 141, 227, 52, 77, 195, 208, 247, 77, 227, 91, 137, 136, 252, 48, 117, 75, 187, 126, 73, 187, 116, 211, 32, 15, 158, 27, 250, 177, 155, 215, 55, 152, 187, 81, 26, 60, 47, 248, 203, 186, 137, 69, 18, 60, 134, 126, 107, 240, 255, 157, 4, 189, 111, 175, 118, 134, 174, 93, 119, 208, 118, 131, 239, 176, 230, 223, 254, 174, 232, 255, 149, 3, 234, 64, 165, 125, 127, 154, 215, 66, 204, 19, 61, 80, 27, 211, 178, 22, 101, 153, 124, 167, 53, 133, 127, 94, 139, 51, 75, 129, 106, 106, 127, 187, 30, 66, 171, 19, 212, 16, 254, 241, 160, 240, 255, 22, 132, 82, 32, 56, 252, 82, 224, 254, 189, 255, 224, 240, 255, 78, 1, 223, 243, 93, 135, 62, 243, 122, 10, 179, 225, 208, 45, 171, 127, 183, 158, 70, 167, 15, 68, 86, 255, 255, 52, 4, 190, 241, 91, 209, 207, 235, 201, 232, 3, 119, 162, 91, 47, 64, 31, 200, 253, 249, 255, 85, 4, 108, 137, 2, 187, 63, 37, 160, 252, 107, 3, 202, 191, 54, 16, 95, 254, 181, 129, 248, 242, 255, 79, 27, 16, 135, 171, 88, 214, 91, 176, 136, 196, 37, 52, 55, 137, 255, 186, 46, 164, 224, 21, 241, 159, 215, 219, 48, 203, 128, 56, 249, 207, 12, 92, 28, 255, 118, 189, 21, 173, 12, 56, 149, 225, 102, 241, 95, 215, 214, 114, 232, 204, 248, 175, 55, 68, 6, 196, 214, 127, 93, 64, 252, 101, 64, 166, 255, 227, 6, 197, 95, 6, 100, 206, 127, 77, 133, 197, 95, 6, 92, 64, 183, 222, 28, 187, 193, 67, 153, 214, 219, 227, 62, 224, 72, 3, 184, 86, 0, 51, 24, 105, 0, 88, 1, 2, 128, 12, 32, 0, 200, 128, 192, 9, 176, 153, 48, 1, 64, 6, 16, 0, 100, 192, 193, 12, 107, 85, 56, 14, 40, 205, 92, 87, 2, 204, 34, 22, 234, 0, 56, 129, 99, 20, 96, 91, 91, 2, 180, 116, 96, 172, 2, 164, 3, 211, 21, 32, 29, 24, 174, 0, 233, 192, 194, 140, 107, 149, 120, 163, 100, 41, 5, 184, 86, 10, 29, 24, 93, 0, 148, 128, 88, 11, 200, 10, 42, 0, 74, 128, 2, 160, 4, 196, 23, 0, 37, 32, 188, 0, 40, 1, 5, 152, 214, 170, 177, 19, 218, 75, 91, 119, 2, 180, 34, 24, 93, 0, 148, 128, 189, 44, 181, 39, 128, 135, 5, 119, 209, 175, 213, 227, 66, 56, 214, 3, 114, 130, 251, 153, 235, 79, 0, 91, 225, 236, 14, 160, 7, 236, 161, 123, 66, 2, 184, 13, 139, 29, 2, 24, 5, 236, 100, 88, 31, 129, 227, 192, 232, 14, 160, 7, 124, 206, 250, 16, 68, 50, 186, 3, 232, 1, 193, 83, 32, 179, 160, 232, 61, 128, 125, 192, 46, 154, 245, 49, 56, 11, 137, 150, 0, 68, 64, 184, 4, 32, 2, 98, 23, 65, 22, 66, 36, 0, 17, 64, 2, 16, 1, 233, 18, 128, 8, 8, 94, 4, 88, 7, 208, 128, 84, 96, 244, 38, 200, 62, 232, 51, 250, 103, 37, 128, 187, 176, 104, 19, 192, 6, 108, 103, 122, 86, 2, 120, 64, 40, 218, 4, 176, 1, 219, 89, 158, 149, 0, 54, 194, 91, 105, 159, 149, 0, 78, 131, 147, 55, 1, 182, 1, 18, 64, 2, 100, 143, 1, 12, 2, 36, 128, 152, 38, 207, 129, 76, 130, 36, 128, 152, 74, 0, 196, 78, 130, 205, 130, 37, 128, 152, 110, 98, 124, 90, 2, 56, 10, 147, 0, 144, 0, 144, 0, 32, 2, 33, 1, 32, 1, 96, 18, 8, 9, 0, 9, 128, 47, 112, 15, 32, 1, 36, 64, 52, 79, 75, 0, 17, 221, 200, 252, 172, 248, 123, 60, 120, 43, 30, 12, 9, 199, 163, 97, 182, 65, 118, 65, 6, 1, 198, 0, 124, 32, 23, 152, 201, 195, 158, 13, 243, 100, 216, 102, 30, 245, 120, 176, 135, 131, 195, 125, 32, 23, 24, 110, 3, 152, 128, 112, 27, 192, 4, 132, 171, 64, 26, 48, 123, 27, 96, 19, 16, 62, 12, 54, 8, 254, 132, 7, 221, 133, 186, 8, 13, 159, 5, 154, 3, 102, 139, 0, 18, 32, 124, 18, 96, 10, 16, 62, 9, 48, 5, 200, 94, 7, 88, 4, 132, 27, 65, 38, 48, 188, 7, 232, 0, 217, 61, 64, 7, 8, 239, 1, 58, 64, 120, 15, 208, 1, 178, 123, 128, 14, 16, 62, 11, 50, 5, 10, 223, 7, 216, 3, 236, 162, 250, 203, 64, 215, 128, 225, 50, 144, 4, 204, 150, 129, 36, 96, 184, 12, 36, 1, 247, 82, 249, 109, 168, 107, 208, 236, 105, 160, 41, 96, 120, 9, 80, 0, 178, 85, 0, 5, 80, 164, 4, 84, 107, 4, 90, 5, 32, 187, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 202, 81, 229, 83, 98, 158, 7, 43, 72, 133, 75, 65, 107, 192, 146, 84, 120, 23, 224, 14, 32, 91, 7, 82, 128, 133, 169, 236, 73, 81, 207, 131, 150, 166, 178, 203, 16, 119, 32, 197, 169, 106, 43, 104, 11, 120, 192, 48, 160, 162, 38, 48, 27, 1, 100, 59, 1, 14, 32, 123, 28, 100, 4, 148, 45, 3, 8, 128, 108, 25, 64, 0, 132, 203, 0, 2, 32, 91, 6, 16, 0, 217, 50, 128, 0, 200, 206, 0, 241, 63, 156, 91, 111, 134, 237, 128, 179, 173, 0, 3, 112, 74, 6, 220, 246, 64, 204, 17, 216, 73, 102, 240, 166, 25, 208, 50, 128, 209, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 167, 103, 192, 173, 220, 224, 44, 254, 209, 243, 0, 254, 255, 146, 12, 184, 205, 76, 112, 17, 255, 107, 184, 201, 94, 192, 252, 255, 50, 110, 177, 29, 182, 255, 189, 144, 225, 114, 51, 208, 122, 2, 32, 218, 12, 144, 255, 151, 75, 193, 75, 133, 64, 71, 254, 221, 64, 8, 92, 214, 6, 90, 237, 255, 204, 159, 250, 216, 220, 204, 15, 126, 235, 254, 190, 255, 168, 216, 243, 59, 255, 126, 220, 58, 221, 234, 231, 223, 183, 106, 67, 113, 181, 63, 191, 86, 220, 253, 233, 69, 96, 233, 95, 59, 147, 153, 59, 40, 40, 245, 255, 9, 239, 247, 223, 234, 201, 111, 144, 248, 254, 253, 15, 195, 207, 41, 130, 207, 117, 254, 244, 235, 14, 69, 224, 69, 108, 39, 30, 225, 88, 145, 63, 254, 212, 39, 78, 240, 254, 47, 170, 251, 200, 38, 28, 61, 232, 233, 46, 118, 132, 47, 131, 218, 25, 20, 149, 101, 220, 184, 123, 105, 198, 131, 83, 160, 125, 233, 240, 186, 77, 106, 1, 239, 105, 255, 109, 219, 215, 99, 39, 131, 47, 187, 250, 55, 243, 8, 126, 160, 248, 144, 247, 245, 2, 230, 176, 42, 240, 250, 215, 255, 98, 49, 69, 12, 126, 244, 243, 111, 63, 114, 97, 127, 166, 192, 116, 128, 28, 156, 167, 102, 115, 183, 178, 50, 60, 224, 231, 255, 222, 17, 206, 80, 216, 20, 46, 63, 132, 240, 167, 113, 180, 34, 80, 240, 231, 255, 222, 143, 170, 239, 138, 117, 130, 182, 235, 143, 255, 188, 216, 58, 214, 251, 89, 94, 15, 37, 114, 160, 237, 134, 179, 62, 47, 222, 43, 167, 91, 110, 49, 119, 230, 192, 59, 209, 47, 250, 121, 177, 229, 204, 235, 173, 65, 91, 51, 116, 31, 74, 194, 185, 27, 222, 9, 217, 251, 211, 39, 109, 224, 29, 54, 249, 248, 55, 7, 109, 219, 147, 224, 205, 224, 111, 189, 73, 211, 6, 202, 126, 159, 91, 228, 117, 51, 140, 203, 91, 191, 213, 118, 25, 135, 183, 255, 232, 214, 177, 147, 21, 97, 169, 242, 255, 217, 194, 165, 233, 135, 177, 251, 46, 15, 218, 165, 27, 135, 126, 75, 163, 254, 96, 247, 160, 13, 236, 86, 211, 5, 126, 85, 77, 223, 15, 195, 48, 77, 227, 216, 117, 227, 56, 77, 195, 48, 244, 253, 102, 137, 246, 225, 2, 218, 134, 176, 76, 251, 255, 175, 214, 122, 129, 190, 110, 62, 62, 65, 241, 36, 209, 62, 55, 245, 117, 31, 56, 57, 5, 154, 61, 155, 103, 126, 240, 203, 130, 186, 111, 104, 211, 158, 89, 5, 246, 238, 155, 92, 9, 20, 145, 127, 87, 165, 64, 129, 117, 35, 41, 88, 70, 254, 93, 145, 2, 133, 182, 205, 38, 2, 101, 228, 223, 255, 9, 172, 131, 139, 107, 95, 238, 147, 138, 250, 1, 241, 255, 227, 139, 61, 176, 186, 14, 69, 63, 168, 184, 23, 144, 255, 159, 109, 111, 63, 252, 241, 23, 190, 52, 98, 6, 142, 137, 255, 159, 50, 187, 180, 26, 104, 198, 3, 142, 140, 100, 192, 175, 3, 95, 246, 180, 148, 27, 13, 52, 211, 65, 15, 157, 120, 185, 212, 177, 111, 120, 232, 166, 2, 189, 160, 159, 14, 188, 51, 54, 16, 56, 250, 133, 143, 237, 174, 36, 232, 167, 238, 232, 207, 215, 139, 255, 241, 143, 114, 117, 159, 116, 131, 102, 234, 206, 120, 212, 44, 59, 3, 206, 123, 225, 235, 220, 141, 211, 187, 251, 190, 166, 159, 198, 238, 180, 119, 15, 37, 103, 192, 233, 47, 252, 109, 151, 110, 26, 94, 124, 225, 253, 48, 117, 203, 233, 31, 170, 23, 255, 179, 191, 242, 121, 94, 150, 191, 47, 1, 126, 95, 5, 44, 203, 60, 95, 246, 113, 66, 51, 160, 166, 127, 7, 126, 112, 127, 106, 196, 95, 6, 136, 191, 12, 48, 255, 205, 37, 110, 42, 44, 254, 255, 155, 1, 89, 241, 239, 68, 60, 122, 59, 60, 138, 119, 244, 141, 208, 32, 218, 95, 17, 115, 39, 216, 139, 245, 215, 132, 12, 132, 238, 251, 191, 127, 175, 38, 227, 127, 15, 27, 0, 132, 143, 3, 24, 192, 108, 51, 200, 0, 100, 91, 1, 6, 32, 219, 10, 244, 4, 224, 79, 66, 240, 217, 86, 128, 0, 252, 89, 8, 154, 0, 155, 9, 63, 149, 73, 116, 163, 101, 0, 1, 144, 45, 3, 76, 128, 194, 101, 0, 1, 144, 45, 3, 8, 128, 108, 25, 96, 5, 20, 190, 22, 178, 2, 200, 110, 2, 26, 64, 118, 19, 208, 0, 194, 155, 0, 7, 144, 221, 4, 236, 0, 179, 155, 128, 6, 16, 222, 4, 52, 128, 236, 38, 160, 1, 132, 55, 1, 59, 128, 236, 157, 128, 43, 192, 143, 25, 41, 64, 58, 144, 2, 164, 3, 41, 64, 58, 144, 2, 164, 3, 45, 129, 34, 153, 40, 64, 58, 144, 5, 100, 5, 43, 197, 155, 0, 10, 80, 243, 141, 48, 11, 152, 109, 5, 21, 128, 240, 18, 160, 0, 100, 151, 0, 5, 32, 188, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 194, 75, 128, 2, 144, 93, 2, 26, 81, 43, 73, 125, 27, 1, 91, 128, 240, 141, 128, 53, 96, 81, 90, 119, 0, 225, 212, 118, 23, 224, 16, 168, 48, 149, 157, 6, 185, 4, 44, 78, 93, 215, 129, 60, 96, 182, 19, 228, 1, 195, 157, 32, 15, 24, 238, 4, 121, 192, 108, 39, 200, 3, 134, 59, 65, 111, 4, 59, 132, 133, 4, 36, 3, 117, 0, 61, 192, 20, 208, 52, 208, 37, 72, 40, 117, 220, 133, 24, 2, 132, 143, 2, 116, 128, 236, 30, 96, 15, 116, 32, 53, 108, 132, 236, 129, 14, 164, 134, 141, 144, 49, 112, 246, 56, 88, 7, 8, 239, 1, 60, 64, 184, 15, 224, 1, 178, 125, 128, 41, 80, 248, 44, 200, 30, 224, 96, 238, 190, 15, 176, 9, 62, 152, 155, 239, 132, 109, 130, 15, 231, 222, 59, 97, 38, 48, 220, 8, 26, 3, 134, 15, 3, 141, 1, 179, 135, 129, 76, 96, 184, 17, 100, 2, 195, 141, 32, 9, 16, 46, 2, 204, 129, 179, 167, 193, 166, 0, 225, 147, 0, 83, 128, 240, 73, 128, 85, 240, 41, 220, 119, 37, 108, 17, 112, 10, 247, 93, 7, 136, 205, 57, 24, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 209, 128, 84, 32, 13, 72, 5, 154, 3, 154, 5, 50, 1, 108, 0, 19, 192, 6, 24, 4, 27, 6, 187, 7, 124, 62, 183, 188, 11, 116, 12, 112, 34, 13, 19, 192, 6, 48, 1, 108, 128, 107, 144, 84, 70, 9, 32, 1, 36, 128, 4, 160, 1, 104, 0, 46, 128, 11, 184, 203, 28, 192, 32, 232, 188, 65, 208, 45, 31, 13, 176, 11, 56, 141, 123, 238, 2, 220, 3, 156, 198, 77, 175, 66, 249, 128, 96, 15, 96, 31, 120, 30, 247, 125, 48, 164, 145, 1, 103, 196, 255, 198, 175, 137, 146, 1, 217, 241, 255, 99, 28, 196, 12, 30, 107, 0, 111, 255, 143, 163, 154, 78, 10, 28, 23, 254, 174, 138, 255, 28, 55, 140, 203, 44, 11, 74, 199, 126, 94, 198, 186, 254, 131, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 247, 231, 95, 23, 190, 217, 98, 181, 249, 103, 109, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "mobile", null },
                    { 3, "Merchant Port 28", "foo@bar.com", "John", "Merchant II", "uG6HUw6hi/v6/9HLhsz6N1NXxQ4=", "PoOLHSMTfb1SPnB1VwtC9Q==", new DateTime(2020, 9, 7, 22, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 2, 0, 0, 0, 2, 0, 8, 3, 0, 0, 0, 195, 166, 36, 200, 0, 0, 0, 33, 80, 76, 84, 69, 76, 105, 113, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 126, 125, 125, 155, 45, 34, 217, 0, 0, 0, 10, 116, 82, 78, 83, 0, 23, 240, 165, 48, 79, 138, 111, 219, 196, 176, 138, 215, 89, 0, 0, 9, 112, 73, 68, 65, 84, 120, 218, 237, 221, 9, 114, 235, 214, 14, 132, 225, 203, 121, 216, 255, 130, 95, 37, 55, 201, 155, 108, 89, 20, 15, 135, 195, 254, 254, 5, 184, 84, 2, 4, 116, 3, 32, 253, 235, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 127, 211, 52, 125, 63, 12, 211, 52, 141, 227, 52, 77, 195, 208, 247, 77, 227, 91, 137, 136, 252, 48, 117, 75, 187, 126, 73, 187, 116, 211, 32, 15, 158, 27, 250, 177, 155, 215, 55, 152, 187, 81, 26, 60, 47, 248, 203, 186, 137, 69, 18, 60, 134, 126, 107, 240, 255, 157, 4, 189, 111, 175, 118, 134, 174, 93, 119, 208, 118, 131, 239, 176, 230, 223, 254, 174, 232, 255, 149, 3, 234, 64, 165, 125, 127, 154, 215, 66, 204, 19, 61, 80, 27, 211, 178, 22, 101, 153, 124, 167, 53, 133, 127, 94, 139, 51, 75, 129, 106, 106, 127, 187, 30, 66, 171, 19, 212, 16, 254, 241, 160, 240, 255, 22, 132, 82, 32, 56, 252, 82, 224, 254, 189, 255, 224, 240, 255, 78, 1, 223, 243, 93, 135, 62, 243, 122, 10, 179, 225, 208, 45, 171, 127, 183, 158, 70, 167, 15, 68, 86, 255, 255, 52, 4, 190, 241, 91, 209, 207, 235, 201, 232, 3, 119, 162, 91, 47, 64, 31, 200, 253, 249, 255, 85, 4, 108, 137, 2, 187, 63, 37, 160, 252, 107, 3, 202, 191, 54, 16, 95, 254, 181, 129, 248, 242, 255, 79, 27, 16, 135, 171, 88, 214, 91, 176, 136, 196, 37, 52, 55, 137, 255, 186, 46, 164, 224, 21, 241, 159, 215, 219, 48, 203, 128, 56, 249, 207, 12, 92, 28, 255, 118, 189, 21, 173, 12, 56, 149, 225, 102, 241, 95, 215, 214, 114, 232, 204, 248, 175, 55, 68, 6, 196, 214, 127, 93, 64, 252, 101, 64, 166, 255, 227, 6, 197, 95, 6, 100, 206, 127, 77, 133, 197, 95, 6, 92, 64, 183, 222, 28, 187, 193, 67, 153, 214, 219, 227, 62, 224, 72, 3, 184, 86, 0, 51, 24, 105, 0, 88, 1, 2, 128, 12, 32, 0, 200, 128, 192, 9, 176, 153, 48, 1, 64, 6, 16, 0, 100, 192, 193, 12, 107, 85, 56, 14, 40, 205, 92, 87, 2, 204, 34, 22, 234, 0, 56, 129, 99, 20, 96, 91, 91, 2, 180, 116, 96, 172, 2, 164, 3, 211, 21, 32, 29, 24, 174, 0, 233, 192, 194, 140, 107, 149, 120, 163, 100, 41, 5, 184, 86, 10, 29, 24, 93, 0, 148, 128, 88, 11, 200, 10, 42, 0, 74, 128, 2, 160, 4, 196, 23, 0, 37, 32, 188, 0, 40, 1, 5, 152, 214, 170, 177, 19, 218, 75, 91, 119, 2, 180, 34, 24, 93, 0, 148, 128, 189, 44, 181, 39, 128, 135, 5, 119, 209, 175, 213, 227, 66, 56, 214, 3, 114, 130, 251, 153, 235, 79, 0, 91, 225, 236, 14, 160, 7, 236, 161, 123, 66, 2, 184, 13, 139, 29, 2, 24, 5, 236, 100, 88, 31, 129, 227, 192, 232, 14, 160, 7, 124, 206, 250, 16, 68, 50, 186, 3, 232, 1, 193, 83, 32, 179, 160, 232, 61, 128, 125, 192, 46, 154, 245, 49, 56, 11, 137, 150, 0, 68, 64, 184, 4, 32, 2, 98, 23, 65, 22, 66, 36, 0, 17, 64, 2, 16, 1, 233, 18, 128, 8, 8, 94, 4, 88, 7, 208, 128, 84, 96, 244, 38, 200, 62, 232, 51, 250, 103, 37, 128, 187, 176, 104, 19, 192, 6, 108, 103, 122, 86, 2, 120, 64, 40, 218, 4, 176, 1, 219, 89, 158, 149, 0, 54, 194, 91, 105, 159, 149, 0, 78, 131, 147, 55, 1, 182, 1, 18, 64, 2, 100, 143, 1, 12, 2, 36, 128, 152, 38, 207, 129, 76, 130, 36, 128, 152, 74, 0, 196, 78, 130, 205, 130, 37, 128, 152, 110, 98, 124, 90, 2, 56, 10, 147, 0, 144, 0, 144, 0, 32, 2, 33, 1, 32, 1, 96, 18, 8, 9, 0, 9, 128, 47, 112, 15, 32, 1, 36, 64, 52, 79, 75, 0, 17, 221, 200, 252, 172, 248, 123, 60, 120, 43, 30, 12, 9, 199, 163, 97, 182, 65, 118, 65, 6, 1, 198, 0, 124, 32, 23, 152, 201, 195, 158, 13, 243, 100, 216, 102, 30, 245, 120, 176, 135, 131, 195, 125, 32, 23, 24, 110, 3, 152, 128, 112, 27, 192, 4, 132, 171, 64, 26, 48, 123, 27, 96, 19, 16, 62, 12, 54, 8, 254, 132, 7, 221, 133, 186, 8, 13, 159, 5, 154, 3, 102, 139, 0, 18, 32, 124, 18, 96, 10, 16, 62, 9, 48, 5, 200, 94, 7, 88, 4, 132, 27, 65, 38, 48, 188, 7, 232, 0, 217, 61, 64, 7, 8, 239, 1, 58, 64, 120, 15, 208, 1, 178, 123, 128, 14, 16, 62, 11, 50, 5, 10, 223, 7, 216, 3, 236, 162, 250, 203, 64, 215, 128, 225, 50, 144, 4, 204, 150, 129, 36, 96, 184, 12, 36, 1, 247, 82, 249, 109, 168, 107, 208, 236, 105, 160, 41, 96, 120, 9, 80, 0, 178, 85, 0, 5, 80, 164, 4, 84, 107, 4, 90, 5, 32, 187, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 202, 81, 229, 83, 98, 158, 7, 43, 72, 133, 75, 65, 107, 192, 146, 84, 120, 23, 224, 14, 32, 91, 7, 82, 128, 133, 169, 236, 73, 81, 207, 131, 150, 166, 178, 203, 16, 119, 32, 197, 169, 106, 43, 104, 11, 120, 192, 48, 160, 162, 38, 48, 27, 1, 100, 59, 1, 14, 32, 123, 28, 100, 4, 148, 45, 3, 8, 128, 108, 25, 64, 0, 132, 203, 0, 2, 32, 91, 6, 16, 0, 217, 50, 128, 0, 200, 206, 0, 241, 63, 156, 91, 111, 134, 237, 128, 179, 173, 0, 3, 112, 74, 6, 220, 246, 64, 204, 17, 216, 73, 102, 240, 166, 25, 208, 50, 128, 209, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 217, 25, 32, 254, 167, 103, 192, 173, 220, 224, 44, 254, 209, 243, 0, 254, 255, 146, 12, 184, 205, 76, 112, 17, 255, 107, 184, 201, 94, 192, 252, 255, 50, 110, 177, 29, 182, 255, 189, 144, 225, 114, 51, 208, 122, 2, 32, 218, 12, 144, 255, 151, 75, 193, 75, 133, 64, 71, 254, 221, 64, 8, 92, 214, 6, 90, 237, 255, 204, 159, 250, 216, 220, 204, 15, 126, 235, 254, 190, 255, 168, 216, 243, 59, 255, 126, 220, 58, 221, 234, 231, 223, 183, 106, 67, 113, 181, 63, 191, 86, 220, 253, 233, 69, 96, 233, 95, 59, 147, 153, 59, 40, 40, 245, 255, 9, 239, 247, 223, 234, 201, 111, 144, 248, 254, 253, 15, 195, 207, 41, 130, 207, 117, 254, 244, 235, 14, 69, 224, 69, 108, 39, 30, 225, 88, 145, 63, 254, 212, 39, 78, 240, 254, 47, 170, 251, 200, 38, 28, 61, 232, 233, 46, 118, 132, 47, 131, 218, 25, 20, 149, 101, 220, 184, 123, 105, 198, 131, 83, 160, 125, 233, 240, 186, 77, 106, 1, 239, 105, 255, 109, 219, 215, 99, 39, 131, 47, 187, 250, 55, 243, 8, 126, 160, 248, 144, 247, 245, 2, 230, 176, 42, 240, 250, 215, 255, 98, 49, 69, 12, 126, 244, 243, 111, 63, 114, 97, 127, 166, 192, 116, 128, 28, 156, 167, 102, 115, 183, 178, 50, 60, 224, 231, 255, 222, 17, 206, 80, 216, 20, 46, 63, 132, 240, 167, 113, 180, 34, 80, 240, 231, 255, 222, 143, 170, 239, 138, 117, 130, 182, 235, 143, 255, 188, 216, 58, 214, 251, 89, 94, 15, 37, 114, 160, 237, 134, 179, 62, 47, 222, 43, 167, 91, 110, 49, 119, 230, 192, 59, 209, 47, 250, 121, 177, 229, 204, 235, 173, 65, 91, 51, 116, 31, 74, 194, 185, 27, 222, 9, 217, 251, 211, 39, 109, 224, 29, 54, 249, 248, 55, 7, 109, 219, 147, 224, 205, 224, 111, 189, 73, 211, 6, 202, 126, 159, 91, 228, 117, 51, 140, 203, 91, 191, 213, 118, 25, 135, 183, 255, 232, 214, 177, 147, 21, 97, 169, 242, 255, 217, 194, 165, 233, 135, 177, 251, 46, 15, 218, 165, 27, 135, 126, 75, 163, 254, 96, 247, 160, 13, 236, 86, 211, 5, 126, 85, 77, 223, 15, 195, 48, 77, 227, 216, 117, 227, 56, 77, 195, 48, 244, 253, 102, 137, 246, 225, 2, 218, 134, 176, 76, 251, 255, 175, 214, 122, 129, 190, 110, 62, 62, 65, 241, 36, 209, 62, 55, 245, 117, 31, 56, 57, 5, 154, 61, 155, 103, 126, 240, 203, 130, 186, 111, 104, 211, 158, 89, 5, 246, 238, 155, 92, 9, 20, 145, 127, 87, 165, 64, 129, 117, 35, 41, 88, 70, 254, 93, 145, 2, 133, 182, 205, 38, 2, 101, 228, 223, 255, 9, 172, 131, 139, 107, 95, 238, 147, 138, 250, 1, 241, 255, 227, 139, 61, 176, 186, 14, 69, 63, 168, 184, 23, 144, 255, 159, 109, 111, 63, 252, 241, 23, 190, 52, 98, 6, 142, 137, 255, 159, 50, 187, 180, 26, 104, 198, 3, 142, 140, 100, 192, 175, 3, 95, 246, 180, 148, 27, 13, 52, 211, 65, 15, 157, 120, 185, 212, 177, 111, 120, 232, 166, 2, 189, 160, 159, 14, 188, 51, 54, 16, 56, 250, 133, 143, 237, 174, 36, 232, 167, 238, 232, 207, 215, 139, 255, 241, 143, 114, 117, 159, 116, 131, 102, 234, 206, 120, 212, 44, 59, 3, 206, 123, 225, 235, 220, 141, 211, 187, 251, 190, 166, 159, 198, 238, 180, 119, 15, 37, 103, 192, 233, 47, 252, 109, 151, 110, 26, 94, 124, 225, 253, 48, 117, 203, 233, 31, 170, 23, 255, 179, 191, 242, 121, 94, 150, 191, 47, 1, 126, 95, 5, 44, 203, 60, 95, 246, 113, 66, 51, 160, 166, 127, 7, 126, 112, 127, 106, 196, 95, 6, 136, 191, 12, 48, 255, 205, 37, 110, 42, 44, 254, 255, 155, 1, 89, 241, 239, 68, 60, 122, 59, 60, 138, 119, 244, 141, 208, 32, 218, 95, 17, 115, 39, 216, 139, 245, 215, 132, 12, 132, 238, 251, 191, 127, 175, 38, 227, 127, 15, 27, 0, 132, 143, 3, 24, 192, 108, 51, 200, 0, 100, 91, 1, 6, 32, 219, 10, 244, 4, 224, 79, 66, 240, 217, 86, 128, 0, 252, 89, 8, 154, 0, 155, 9, 63, 149, 73, 116, 163, 101, 0, 1, 144, 45, 3, 76, 128, 194, 101, 0, 1, 144, 45, 3, 8, 128, 108, 25, 96, 5, 20, 190, 22, 178, 2, 200, 110, 2, 26, 64, 118, 19, 208, 0, 194, 155, 0, 7, 144, 221, 4, 236, 0, 179, 155, 128, 6, 16, 222, 4, 52, 128, 236, 38, 160, 1, 132, 55, 1, 59, 128, 236, 157, 128, 43, 192, 143, 25, 41, 64, 58, 144, 2, 164, 3, 41, 64, 58, 144, 2, 164, 3, 45, 129, 34, 153, 40, 64, 58, 144, 5, 100, 5, 43, 197, 155, 0, 10, 80, 243, 141, 48, 11, 152, 109, 5, 21, 128, 240, 18, 160, 0, 100, 151, 0, 5, 32, 188, 4, 40, 0, 217, 37, 64, 1, 8, 47, 1, 10, 64, 118, 9, 80, 0, 194, 75, 128, 2, 144, 93, 2, 26, 81, 43, 73, 125, 27, 1, 91, 128, 240, 141, 128, 53, 96, 81, 90, 119, 0, 225, 212, 118, 23, 224, 16, 168, 48, 149, 157, 6, 185, 4, 44, 78, 93, 215, 129, 60, 96, 182, 19, 228, 1, 195, 157, 32, 15, 24, 238, 4, 121, 192, 108, 39, 200, 3, 134, 59, 65, 111, 4, 59, 132, 133, 4, 36, 3, 117, 0, 61, 192, 20, 208, 52, 208, 37, 72, 40, 117, 220, 133, 24, 2, 132, 143, 2, 116, 128, 236, 30, 96, 15, 116, 32, 53, 108, 132, 236, 129, 14, 164, 134, 141, 144, 49, 112, 246, 56, 88, 7, 8, 239, 1, 60, 64, 184, 15, 224, 1, 178, 125, 128, 41, 80, 248, 44, 200, 30, 224, 96, 238, 190, 15, 176, 9, 62, 152, 155, 239, 132, 109, 130, 15, 231, 222, 59, 97, 38, 48, 220, 8, 26, 3, 134, 15, 3, 141, 1, 179, 135, 129, 76, 96, 184, 17, 100, 2, 195, 141, 32, 9, 16, 46, 2, 204, 129, 179, 167, 193, 166, 0, 225, 147, 0, 83, 128, 240, 73, 128, 85, 240, 41, 220, 119, 37, 108, 17, 112, 10, 247, 93, 7, 136, 205, 57, 24, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 25, 3, 25, 5, 209, 128, 84, 32, 13, 72, 5, 154, 3, 154, 5, 50, 1, 108, 0, 19, 192, 6, 24, 4, 27, 6, 187, 7, 124, 62, 183, 188, 11, 116, 12, 112, 34, 13, 19, 192, 6, 48, 1, 108, 128, 107, 144, 84, 70, 9, 32, 1, 36, 128, 4, 160, 1, 104, 0, 46, 128, 11, 184, 203, 28, 192, 32, 232, 188, 65, 208, 45, 31, 13, 176, 11, 56, 141, 123, 238, 2, 220, 3, 156, 198, 77, 175, 66, 249, 128, 96, 15, 96, 31, 120, 30, 247, 125, 48, 164, 145, 1, 103, 196, 255, 198, 175, 137, 146, 1, 217, 241, 255, 99, 28, 196, 12, 30, 107, 0, 111, 255, 143, 163, 154, 78, 10, 28, 23, 254, 174, 138, 255, 28, 55, 140, 203, 44, 11, 74, 199, 126, 94, 198, 186, 254, 131, 60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 247, 231, 95, 23, 190, 217, 98, 181, 249, 103, 109, 0, 0, 0, 0, 73, 69, 78, 68, 174, 66, 96, 130 }, "merchant", null }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CreatedAt", "Text", "UsedAt", "UsedById", "Value" },
                values: new object[,]
                {
                    { 4, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "497D-A613", null, 2, 30 },
                    { 5, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "47E7-9714", null, 2, 50 },
                    { 6, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "497C-A113", null, 3, 30 },
                    { 7, new DateTime(2022, 6, 9, 22, 50, 36, 40, DateTimeKind.Unspecified).AddTicks(6503), "27E8-9714", null, 3, 15 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "OfferId", "RateCount", "RatedOn", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 3.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, 4.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 2, 3.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 2, 4.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 3, 5.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 3, 4.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 4, 4.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 4, 4.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, 5, 5.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, 5, 4.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, 6, 5.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, 6, 5.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 13, 7, 2.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, 7, 3.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 15, 8, 2.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, 8, 4.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, 9, 5.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, 9, 4.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 19, 10, 5.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 10, 4.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, 11, 2.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, 11, 4.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 23, 12, 5.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 24, 12, 5.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 25, 13, 5.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, 13, 5.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 27, 14, 1.0, new DateTime(2022, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 28, 14, 2.0, new DateTime(2022, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 29, 1, 4.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 30, 2, 2.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 31, 3, 5.0, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 32, 4, 5.0, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 33, 5, 5.0, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 34, 6, 4.0, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 35, 7, 3.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 36, 8, 4.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 37, 9, 4.0, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 38, 10, 3.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "OfferId", "RateCount", "RatedOn", "UserId" },
                values: new object[,]
                {
                    { 39, 11, 2.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 40, 12, 2.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 41, 13, 3.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 42, 14, 3.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 43, 15, 4.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 44, 16, 4.0, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 45, 17, 3.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 46, 18, 4.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 47, 19, 1.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 48, 20, 4.5, new DateTime(2022, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "UserOffers",
                columns: new[] { "Id", "BoughtOn", "OfferId", "Played", "PlayedOn", "UserId", "Won" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, null, 2, false },
                    { 2, new DateTime(2022, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false, null, 2, false },
                    { 3, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, null, 2, false },
                    { 4, new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, null, 2, false },
                    { 5, new DateTime(2021, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, false, null, 2, false },
                    { 6, new DateTime(2021, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, false, null, 2, false },
                    { 7, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, false, null, 2, false },
                    { 8, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, true, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false },
                    { 9, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 10, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, true, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 11, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, true, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 12, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, true, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 13, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, true, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 14, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, true, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false },
                    { 15, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, true, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 16, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true },
                    { 17, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false },
                    { 18, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "Id", "Balance", "CreatedAt", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 50.0, new DateTime(2020, 9, 7, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 7, 22, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 50.0, new DateTime(2020, 9, 7, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 7, 22, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_UsedById",
                table: "Coupons",
                column: "UsedById");

            migrationBuilder.CreateIndex(
                name: "IX_Merchants_CountryId",
                table: "Merchants",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CategoryId",
                table: "Offers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_OfferId",
                table: "Ratings",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOffers_OfferId",
                table: "UserOffers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOffers_UserId",
                table: "UserOffers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Merchants");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UserOffers");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
