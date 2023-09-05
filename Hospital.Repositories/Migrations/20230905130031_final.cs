using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HospitalInfos_HospitalId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HospitalId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "HospitalInfoId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HospitalInfoId",
                table: "Rooms",
                column: "HospitalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HospitalInfos_HospitalInfoId",
                table: "Rooms",
                column: "HospitalInfoId",
                principalTable: "HospitalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_HospitalInfos_HospitalInfoId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HospitalInfoId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HospitalInfoId",
                table: "Rooms");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HospitalId",
                table: "Rooms",
                column: "HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_HospitalInfos_HospitalId",
                table: "Rooms",
                column: "HospitalId",
                principalTable: "HospitalInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
