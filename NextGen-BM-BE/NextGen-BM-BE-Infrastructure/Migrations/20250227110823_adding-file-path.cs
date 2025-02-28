using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextGen_BM_BE_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingfilepath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId",
                table: "RepairRequests");

            migrationBuilder.AddColumn<string>(
                name: "RequestTitle",
                table: "UserBuildings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RepairRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestTitle",
                table: "RepairRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RequestFiles",
                columns: table => new
                {
                    RequestFilesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    RepairRequestId = table.Column<int>(type: "int", nullable: true),
                    UserBuildingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestFiles", x => x.RequestFilesId);
                    table.ForeignKey(
                        name: "FK_RequestFiles_RepairRequests_RepairRequestId",
                        column: x => x.RepairRequestId,
                        principalTable: "RepairRequests",
                        principalColumn: "RepairRequestId");
                    table.ForeignKey(
                        name: "FK_RequestFiles_UserBuildings_UserBuildingsId",
                        column: x => x.UserBuildingsId,
                        principalTable: "UserBuildings",
                        principalColumn: "UserBuildingsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestFiles_RepairRequestId",
                table: "RequestFiles",
                column: "RepairRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestFiles_UserBuildingsId",
                table: "RequestFiles",
                column: "UserBuildingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId",
                table: "RepairRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId",
                table: "RepairRequests");

            migrationBuilder.DropTable(
                name: "RequestFiles");

            migrationBuilder.DropColumn(
                name: "RequestTitle",
                table: "UserBuildings");

            migrationBuilder.DropColumn(
                name: "RequestTitle",
                table: "RepairRequests");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RepairRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId",
                table: "RepairRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
