using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseSolution.Ticket.TicketManagment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderTotal = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedAt", "CreatedBy", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { new Guid("14c1fae5-0639-4dd1-9b72-15d522ab394d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "Artificial Intelligence" },
                    { new Guid("3c11b904-afc8-4a78-92a9-96eafe236716"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "Mechine Learning" },
                    { new Guid("4468990c-5382-4a04-b2eb-4ab9275e8d04"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "Cyber Security" },
                    { new Guid("d4d0f53a-d69f-4a4c-b9a0-3739aaabce0d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null, "Software Engineering" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "OrderPaid", "OrderTotal", "UserId" },
                values: new object[,]
                {
                    { new Guid("7ec834cf-bc6b-453b-835d-520b439afb46"), new DateTime(2024, 3, 27, 5, 9, 48, 389, DateTimeKind.Local).AddTicks(7559), false, 175, new Guid("f6d34e22-f93a-4795-8cb9-76850608e9c4") },
                    { new Guid("cf878c8b-0062-4760-9ff3-1e1b50c5ec00"), new DateTime(2024, 3, 27, 5, 9, 48, 389, DateTimeKind.Local).AddTicks(7656), false, 120, new Guid("1c47de68-219d-4802-9261-46df912438e2") },
                    { new Guid("dfa3a946-bc67-4073-8f34-24a36af67088"), new DateTime(2024, 3, 27, 5, 9, 48, 389, DateTimeKind.Local).AddTicks(7541), false, 120, new Guid("de0bdb7f-6dd2-48a4-8f59-553718064d2c") },
                    { new Guid("e30ff405-19d0-4288-9321-a63327197f3f"), new DateTime(2024, 3, 27, 7, 9, 48, 389, DateTimeKind.Local).AddTicks(7482), false, 175, new Guid("13c35229-9be0-407e-8313-cf142d6b34c2") }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Author", "CategoryId", "Date", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("040313f6-c01e-4f9a-84b9-beb77673973e"), "Mohanned Rashid", new Guid("3c11b904-afc8-4a78-92a9-96eafe236716"), new DateTime(2024, 5, 27, 5, 9, 48, 389, DateTimeKind.Local).AddTicks(7410), "Take your machine learning skills to the next level with this advanced course.", "Advanced Machine Learning", 89.99m },
                    { new Guid("47350736-8037-4e28-aa28-bece19b62d58"), "Mohammed alzain", new Guid("4468990c-5382-4a04-b2eb-4ab9275e8d04"), new DateTime(2024, 6, 27, 5, 9, 48, 389, DateTimeKind.Local).AddTicks(7343), "you will know if the cyper security is the right indestury for you or not", "Introduction to Cyber Security", 60.99m },
                    { new Guid("583951e8-2221-477e-9e07-258fe5096478"), "Alice Johnson", new Guid("14c1fae5-0639-4dd1-9b72-15d522ab394d"), new DateTime(2024, 7, 27, 5, 9, 48, 389, DateTimeKind.Local).AddTicks(7447), "Discover the basics of artificial intelligence and its applications in various industries.", "Artificial Intelligence Fundamentals", 65.75m },
                    { new Guid("77995a0c-3fdb-4b96-8e43-337eb638ea23"), "Khalid Mohammed", new Guid("d4d0f53a-d69f-4a4c-b9a0-3739aaabce0d"), new DateTime(2024, 4, 27, 5, 9, 48, 389, DateTimeKind.Local).AddTicks(7429), "Learn to develop mobile applications for both Android and iOS platforms.", "Mobile App Development", 75.50m },
                    { new Guid("c9424aef-44d4-41a6-bfda-987dbe051d87"), "Abdalazim Attya", new Guid("d4d0f53a-d69f-4a4c-b9a0-3739aaabce0d"), new DateTime(2024, 6, 27, 5, 9, 48, 389, DateTimeKind.Local).AddTicks(7393), "you will know if the web development is the right indestury for you or not", "Introduction to Web Development", 60.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
