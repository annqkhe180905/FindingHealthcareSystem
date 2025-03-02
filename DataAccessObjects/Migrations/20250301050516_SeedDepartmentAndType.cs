using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class SeedDepartmentAndType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FacilityTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Cơ sở y tế chuyên điều trị các bệnh lý đa dạng.", "Bệnh viện" },
                    { 2, "Cơ sở y tế nhỏ, chủ yếu khám chữa bệnh ngoại trú.", "Phòng khám" },
                    { 3, "Cửa hàng cung cấp thuốc và các sản phẩm y tế.", "Nhà thuốc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FacilityTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
