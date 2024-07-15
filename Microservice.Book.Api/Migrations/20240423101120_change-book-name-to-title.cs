using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Microservice.Book.Api.Migrations
{
    /// <inheritdoc />
    public partial class changebooknametotitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MSOS_Book",
                newName: "Title");

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("01f54aa7-c51a-4b92-a72b-68e0965bf246"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5632), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5633) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("07c06c3f-0897-44b6-ae05-a70540e73a12"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5569), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5571) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("23608dce-2142-4d2b-b909-948316b5efaf"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5597), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5599) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("285c81bc-f257-4ffb-b6ce-7ab5fa9e5c81"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5624), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5625) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("29a75938-ce2d-473b-b7fe-2903fe97fd6e"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5589), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5590) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("37544155-da95-49e8-b7fe-3c937eb1de98"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5650), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5651) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("6131ce7e-fb11-4608-a3d3-f01caee2c465"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5580), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5582) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("6b85f863-7991-4f93-bf86-8c756fdeac87"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5640), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5642) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("ecf65c56-5670-473b-9f20-fb0b191c2f0f"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5615), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5617) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("f3fcab1f-1c11-47f5-9e11-7868a88408e6"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5606), new DateTime(2024, 4, 23, 11, 11, 20, 269, DateTimeKind.Local).AddTicks(5607) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "MSOS_Book",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("01f54aa7-c51a-4b92-a72b-68e0965bf246"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(9022), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(9025) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("07c06c3f-0897-44b6-ae05-a70540e73a12"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8859), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8862) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("23608dce-2142-4d2b-b909-948316b5efaf"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8914), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("285c81bc-f257-4ffb-b6ce-7ab5fa9e5c81"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8964), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8967) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("29a75938-ce2d-473b-b7fe-2903fe97fd6e"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8897), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8900) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("37544155-da95-49e8-b7fe-3c937eb1de98"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(9058), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(9060) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("6131ce7e-fb11-4608-a3d3-f01caee2c465"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8881), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8884) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("6b85f863-7991-4f93-bf86-8c756fdeac87"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(9039), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("ecf65c56-5670-473b-9f20-fb0b191c2f0f"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8948), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8951) });

            migrationBuilder.UpdateData(
                table: "MSOS_Book",
                keyColumn: "Id",
                keyValue: new Guid("f3fcab1f-1c11-47f5-9e11-7868a88408e6"),
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8930), new DateTime(2024, 4, 22, 17, 14, 51, 587, DateTimeKind.Local).AddTicks(8933) });
        }
    }
}
