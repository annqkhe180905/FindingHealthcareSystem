using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessObjects.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnderlying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientUnderlyingDiseases");

            migrationBuilder.DropTable(
                name: "UnderlyingDiseases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnderlyingDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnderlyingDiseases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientUnderlyingDiseases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    UnderlyingDiseaseId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientUnderlyingDiseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientUnderlyingDiseases_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientUnderlyingDiseases_UnderlyingDiseases_UnderlyingDiseaseId",
                        column: x => x.UnderlyingDiseaseId,
                        principalTable: "UnderlyingDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UnderlyingDiseases",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Bệnh lý do rối loạn chuyển hóa đường trong máu", "Tiểu đường" },
                    { 2, "Tăng huyết áp có thể gây nguy cơ bệnh tim mạch", "Huyết áp cao" },
                    { 3, "Bệnh đường hô hấp mãn tính gây khó thở", "Hen suyễn" },
                    { 4, "Tình trạng mỡ thừa tích tụ quá mức gây ảnh hưởng sức khỏe", "Béo phì" },
                    { 5, "Tình trạng tim không bơm đủ máu đến cơ thể", "Suy tim" },
                    { 6, "Suy giảm chức năng thận ảnh hưởng đến bài tiết và lọc độc tố", "Suy thận" },
                    { 7, "Bệnh mãn tính gây khó thở, thường gặp ở người hút thuốc lá", "Bệnh phổi tắc nghẽn mãn tính (COPD)" },
                    { 8, "Suy giảm mật độ xương làm tăng nguy cơ gãy xương", "Loãng xương" },
                    { 9, "Rối loạn thần kinh ảnh hưởng đến vận động", "Bệnh Parkinson" },
                    { 10, "Bệnh thoái hóa thần kinh ảnh hưởng đến trí nhớ và nhận thức", "Bệnh Alzheimer" },
                    { 11, "Bệnh nhiễm virus viêm gan B gây tổn thương gan", "Viêm gan B" },
                    { 12, "Bệnh nhiễm virus viêm gan C có thể gây xơ gan", "Viêm gan C" },
                    { 13, "Mỡ máu cao có thể dẫn đến xơ vữa động mạch", "Rối loạn lipid máu" },
                    { 14, "Tắc nghẽn hoặc vỡ mạch máu não gây tổn thương não", "Đột quỵ" },
                    { 15, "Viêm loét dạ dày hoặc trào ngược dạ dày thực quản", "Bệnh dạ dày - tá tràng" },
                    { 16, "Giảm khả năng đề kháng với bệnh tật", "Suy giảm miễn dịch" },
                    { 17, "Bệnh tự miễn ảnh hưởng nhiều cơ quan trong cơ thể", "Bệnh Lupus ban đỏ hệ thống" },
                    { 18, "Bệnh không dung nạp gluten gây tổn thương ruột non", "Bệnh Celiac" },
                    { 19, "Suy giảm miễn dịch gây nguy cơ nhiễm trùng cao", "HIV/AIDS" },
                    { 20, "Bệnh do rối loạn chuyển hóa purin, gây viêm khớp", "Bệnh gút" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientUnderlyingDiseases_PatientId",
                table: "PatientUnderlyingDiseases",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientUnderlyingDiseases_UnderlyingDiseaseId",
                table: "PatientUnderlyingDiseases",
                column: "UnderlyingDiseaseId");
        }
    }
}
