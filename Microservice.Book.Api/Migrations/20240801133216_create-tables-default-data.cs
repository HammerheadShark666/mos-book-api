using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Microservice.Book.Api.Migrations
{
    /// <inheritdoc />
    public partial class createtablesdefaultdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MSOS_Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSOS_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MSOS_DiscountType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSOS_DiscountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MSOS_Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSOS_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MSOS_Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSOS_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MSOS_Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: true),
                    SeriesId = table.Column<int>(type: "int", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Condition = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NumberInStock = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(19,2)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(19,2)", nullable: true),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MSOS_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MSOS_Book_MSOS_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "MSOS_Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MSOS_Book_MSOS_DiscountType_DiscountTypeId",
                        column: x => x.DiscountTypeId,
                        principalTable: "MSOS_DiscountType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MSOS_Book_MSOS_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "MSOS_Publisher",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MSOS_Book_MSOS_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "MSOS_Series",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "MSOS_Author",
                columns: new[] { "Id", "FirstName", "MiddleName", "Surname" },
                values: new object[,]
                {
                    { new Guid("2385de72-2302-4ced-866a-fa199116ca6e"), "Sam", "John", "Mateal" },
                    { new Guid("47417642-87d9-4047-ae13-4c721d99ab48"), "Emily", null, "Henry" },
                    { new Guid("55b431ff-693e-4664-8f65-cfd8d0b14b1b"), "Paul", null, "Cooper" },
                    { new Guid("5ff79dfe-c1fa-4dd9-996f-bc96649d6dfc"), "Francesca", "De", "Tores" },
                    { new Guid("aa1dc96f-3be5-41cd-8a1b-207284af3fdd"), "Elsie", null, "Silver" },
                    { new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"), "Shusterman", null, "Neal" },
                    { new Guid("af95fb7e-8d97-4892-8da3-5e6e51c54044"), "Arthur", "Henry", "James" },
                    { new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), "Silvera", null, "Adam" },
                    { new Guid("f07e88ac-53b2-4def-af07-957cbb18523c"), "Megan", "Whalen", "Turner" },
                    { new Guid("ff4d5a80-81e3-42e3-8052-92cf5c51e797"), "A.F.", null, "Steadman" }
                });

            migrationBuilder.InsertData(
                table: "MSOS_DiscountType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Percentage" },
                    { 2, "Monetary" }
                });

            migrationBuilder.InsertData(
                table: "MSOS_Publisher",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Simon & Schuster Books for Young Readers" },
                    { 2, "Bulletin Blue Ribbon" },
                    { 3, "Quill Tree Books" },
                    { 4, "Bloomsbury Publishing PLC" },
                    { 5, "Penguin Books Ltd" },
                    { 6, "Duckworth Books" },
                    { 7, "Little, Brown Book Group" }
                });

            migrationBuilder.InsertData(
                table: "MSOS_Series",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "The Arc of a Scythe" },
                    { 2, "The Infinity Cycle" },
                    { 3, "Queen’s Thief" }
                });

            migrationBuilder.InsertData(
                table: "MSOS_Book",
                columns: new[] { "Id", "AuthorId", "Condition", "Created", "Discount", "DiscountTypeId", "ISBN", "LastUpdated", "NumberInStock", "Price", "PublisherId", "SeriesId", "Summary", "Title" },
                values: new object[,]
                {
                    { new Guid("01f54aa7-c51a-4b92-a72b-68e0965bf246"), new Guid("47417642-87d9-4047-ae13-4c721d99ab48"), "New", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3171), null, null, "2928377225186", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3172), 20, 11.99m, 5, null, "From the bestselling author of Happy Place and Book Lovers comes another witty and romantic tale, as two wronged exes hatch a plan to make their former partners' lives hell.", "Funny Story" },
                    { new Guid("07c06c3f-0897-44b6-ae05-a70540e73a12"), new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), "New", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3109), null, null, "9780063376120", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3111), 50, 7.50m, 3, 2, "Growing up in New York, brothers Emil and Brighton always idolized the Spell Walkers—a vigilante group sworn to rid the world of specters. While the Spell Walkers and other celestials are born with powers, specters take them, violently stealing the essence of endangered magical creatures.", "Infinity Son" },
                    { new Guid("23608dce-2142-4d2b-b909-948316b5efaf"), new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"), "Used", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3137), null, null, "9781442472433", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3138), 1, 3.50m, 1, 1, "A world with no hunger, no disease, no war, no misery: humanity has conquered all those things, and has even conquered death. Now Scythes are the only ones who can end life—and they are commanded to do so, in order to keep the size of the population under control.", "Scythe" },
                    { new Guid("285c81bc-f257-4ffb-b6ce-7ab5fa9e5c81"), new Guid("ff4d5a80-81e3-42e3-8052-92cf5c51e797"), "New", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3162), null, null, "9781398529687", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3164), 20, 12.99m, 1, null, "More heart-pounding adventures lie in wait for Skandar Smith in the third instalment of Steadman's blockbuster children's fantasy saga, as the friends must take part in a series of dangerous challenges across the island.", "Skandar and the Chaos Trials" },
                    { new Guid("29a75938-ce2d-473b-b7fe-2903fe97fd6e"), new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), "New", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3129), null, null, "9781398504974", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3130), 23, 9.99m, 3, 2, "After the ultimate betrayal, Emil must rise up as a leader to stop his brother, Brighton, before he becomes too powerful. Even if that means pushing away Ness and Wyatt as they compete for his heart so he can focus on the war.", "Infinity Kings" },
                    { new Guid("37544155-da95-49e8-b7fe-3c937eb1de98"), new Guid("aa1dc96f-3be5-41cd-8a1b-207284af3fdd"), "New", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3188), null, null, "9780349441634", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3189), 10, 9.99m, 7, null, "Pure romantic escapism from the author of the Chestnut Springs series, as the 'world's hottest billionaire' unexpectedly finds himself a new parent whilst trying to keep his hands off his best friend's little sister.", "Wild Love" },
                    { new Guid("6131ce7e-fb11-4608-a3d3-f01caee2c465"), new Guid("c95ba8ff-06a1-49d0-bc45-83f89b3ce820"), "New", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3119), null, null, "9780062882318", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3121), 34, 8.50m, 3, 2, "Emil and Brighton Rey defied the odds. They beat the Blood Casters and escaped with their lives–or so they thought. When Brighton drank the Reaper’s Blood, he believed it would make him invincible, but instead the potion is killing him.", "Infinity Reaper" },
                    { new Guid("6b85f863-7991-4f93-bf86-8c756fdeac87"), new Guid("55b431ff-693e-4664-8f65-cfd8d0b14b1b"), "New", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3179), 10.0m, 1, "9780715655009", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3180), 10, 15.99m, 6, null, "Ranging from Mesopotamia to Roman Britain, Cooper's engrossing volume – based on his hit history podcast – charts the rise and decline of several ancient civilizations.", "Fall of Civilizations: Stories of Greatness and Decline" },
                    { new Guid("ecf65c56-5670-473b-9f20-fb0b191c2f0f"), new Guid("5ff79dfe-c1fa-4dd9-996f-bc96649d6dfc"), "New", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3154), null, null, "9781526680266", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3156), 30, 15.99m, 4, null, "Reimagining the life of groundbreaking seventeenth-century woman pirate Mary Read, de Tores' dynamic debut entwines themes of gender and survival into a rollicking period adventure story.", "Saltblood" },
                    { new Guid("f3fcab1f-1c11-47f5-9e11-7868a88408e6"), new Guid("ae55b0d1-ba02-41e1-9efa-9b4d4ac15eec"), "Used", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3144), null, null, "9781442472457", new DateTime(2024, 8, 1, 14, 32, 14, 917, DateTimeKind.Local).AddTicks(3146), 3, 2.5m, 1, 1, "The Thunderhead is the perfect ruler of a perfect world, but it has no control over the scythedom. A year has passed since Rowan had gone off grid. Since then, he has become an urban legend, a vigilante snuffing out corrupt scythes in a trial by fire. His story is told in whispers across the continent.", "Thunderhead" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MSOS_Book_AuthorId",
                table: "MSOS_Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MSOS_Book_DiscountTypeId",
                table: "MSOS_Book",
                column: "DiscountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MSOS_Book_PublisherId",
                table: "MSOS_Book",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_MSOS_Book_SeriesId",
                table: "MSOS_Book",
                column: "SeriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MSOS_Book");

            migrationBuilder.DropTable(
                name: "MSOS_Author");

            migrationBuilder.DropTable(
                name: "MSOS_DiscountType");

            migrationBuilder.DropTable(
                name: "MSOS_Publisher");

            migrationBuilder.DropTable(
                name: "MSOS_Series");
        }
    }
}
