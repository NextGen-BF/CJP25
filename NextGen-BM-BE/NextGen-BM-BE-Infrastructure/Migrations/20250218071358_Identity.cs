using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextGen_BM_BE_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyExpense_AspNetRoles_RoleId1",
                table: "PropertyExpense");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyUsers_AspNetRoles_RoleId1",
                table: "PropertyUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyUsers_AspNetUsers_UserId1",
                table: "PropertyUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId1",
                table: "RepairRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBuildings_AspNetRoles_RoleId1",
                table: "UserBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBuildings_AspNetUsers_UserId1",
                table: "UserBuildings");

            migrationBuilder.DropIndex(
                name: "IX_UserBuildings_RoleId1",
                table: "UserBuildings");

            migrationBuilder.DropIndex(
                name: "IX_UserBuildings_UserId1",
                table: "UserBuildings");

            migrationBuilder.DropIndex(
                name: "IX_RepairRequests_UserId1",
                table: "RepairRequests");

            migrationBuilder.DropIndex(
                name: "IX_PropertyUsers_RoleId1",
                table: "PropertyUsers");

            migrationBuilder.DropIndex(
                name: "IX_PropertyUsers_UserId1",
                table: "PropertyUsers");

            migrationBuilder.DropIndex(
                name: "IX_PropertyExpense_RoleId1",
                table: "PropertyExpense");

            /*
            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "UserBuildings");
                */

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserBuildings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "RepairRequests");

            /*
            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "PropertyUsers");
                */

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "PropertyUsers");

            /*
            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "PropertyExpense");
                */

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserBuildings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "UserBuildings",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RepairRequests",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PropertyUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "PropertyUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentParentId",
                table: "PropertyPayments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "PropertyExpense",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            /*
            migrationBuilder.AddColumn<string>(
                name: "ResponsibleRole",
                table: "PropertyExpense",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
                */

            migrationBuilder.CreateIndex(
                name: "IX_UserBuildings_RoleId",
                table: "UserBuildings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuildings_UserId",
                table: "UserBuildings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairRequests_UserId",
                table: "RepairRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyUsers_RoleId",
                table: "PropertyUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyUsers_UserId",
                table: "PropertyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpense_RoleId",
                table: "PropertyExpense",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyExpense_AspNetRoles_RoleId",
                table: "PropertyExpense",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyUsers_AspNetRoles_RoleId",
                table: "PropertyUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyUsers_AspNetUsers_UserId",
                table: "PropertyUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId",
                table: "RepairRequests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuildings_AspNetRoles_RoleId",
                table: "UserBuildings",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuildings_AspNetUsers_UserId",
                table: "UserBuildings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyExpense_AspNetRoles_RoleId",
                table: "PropertyExpense");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyUsers_AspNetRoles_RoleId",
                table: "PropertyUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyUsers_AspNetUsers_UserId",
                table: "PropertyUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId",
                table: "RepairRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBuildings_AspNetRoles_RoleId",
                table: "UserBuildings");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBuildings_AspNetUsers_UserId",
                table: "UserBuildings");

            migrationBuilder.DropIndex(
                name: "IX_UserBuildings_RoleId",
                table: "UserBuildings");

            migrationBuilder.DropIndex(
                name: "IX_UserBuildings_UserId",
                table: "UserBuildings");

            migrationBuilder.DropIndex(
                name: "IX_RepairRequests_UserId",
                table: "RepairRequests");

            migrationBuilder.DropIndex(
                name: "IX_PropertyUsers_RoleId",
                table: "PropertyUsers");

            migrationBuilder.DropIndex(
                name: "IX_PropertyUsers_UserId",
                table: "PropertyUsers");

            migrationBuilder.DropIndex(
                name: "IX_PropertyExpense_RoleId",
                table: "PropertyExpense");

            migrationBuilder.DropColumn(
                name: "ResponsibleRole",
                table: "PropertyExpense");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserBuildings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "UserBuildings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId1",
                table: "UserBuildings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserBuildings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RepairRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "RepairRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PropertyUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "PropertyUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId1",
                table: "PropertyUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "PropertyUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentParentId",
                table: "PropertyPayments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "PropertyExpense",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId1",
                table: "PropertyExpense",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBuildings_RoleId1",
                table: "UserBuildings",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuildings_UserId1",
                table: "UserBuildings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_RepairRequests_UserId1",
                table: "RepairRequests",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyUsers_RoleId1",
                table: "PropertyUsers",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyUsers_UserId1",
                table: "PropertyUsers",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpense_RoleId1",
                table: "PropertyExpense",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyExpense_AspNetRoles_RoleId1",
                table: "PropertyExpense",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyUsers_AspNetRoles_RoleId1",
                table: "PropertyUsers",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyUsers_AspNetUsers_UserId1",
                table: "PropertyUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_AspNetUsers_UserId1",
                table: "RepairRequests",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuildings_AspNetRoles_RoleId1",
                table: "UserBuildings",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBuildings_AspNetUsers_UserId1",
                table: "UserBuildings",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
