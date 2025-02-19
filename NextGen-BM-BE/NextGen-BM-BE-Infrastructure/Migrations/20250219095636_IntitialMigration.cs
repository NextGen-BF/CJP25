using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextGen_BM_BE_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IntitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<int>(type: "int", nullable: false),
                    Entrance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "Enums",
                columns: table => new
                {
                    EnumsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enums", x => x.EnumsId);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNum = table.Column<int>(type: "int", nullable: false),
                    TotalBuildingSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateBuilt = table.Column<DateOnly>(type: "date", nullable: false),
                    NumOfElevators = table.Column<int>(type: "int", nullable: false),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_Buildings_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
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
                name: "PropertyExpenseTemplate",
                columns: table => new
                {
                    PropertyExpenseTemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerResident = table.Column<bool>(type: "bit", nullable: false),
                    RepeatPeriodId = table.Column<int>(type: "int", nullable: false),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyExpenseTemplate", x => x.PropertyExpenseTemplateId);
                    table.ForeignKey(
                        name: "FK_PropertyExpenseTemplate_Enums_RepeatPeriodId",
                        column: x => x.RepeatPeriodId,
                        principalTable: "Enums",
                        principalColumn: "EnumsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingExpenses",
                columns: table => new
                {
                    BuildingExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierIdEnumsId = table.Column<int>(type: "int", nullable: true),
                    DateOpened = table.Column<DateOnly>(type: "date", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PaymentDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTemplate = table.Column<bool>(type: "bit", nullable: false),
                    RepeatPeriodIdEnumsId = table.Column<int>(type: "int", nullable: true),
                    InvoiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingExpenses", x => x.BuildingExpenseId);
                    table.ForeignKey(
                        name: "FK_BuildingExpenses_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingExpenses_Enums_RepeatPeriodIdEnumsId",
                        column: x => x.RepeatPeriodIdEnumsId,
                        principalTable: "Enums",
                        principalColumn: "EnumsId");
                    table.ForeignKey(
                        name: "FK_BuildingExpenses_Enums_SupplierIdEnumsId",
                        column: x => x.SupplierIdEnumsId,
                        principalTable: "Enums",
                        principalColumn: "EnumsId");
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyNumber = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    SizeOfIdealParts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PropertyTypeId = table.Column<int>(type: "int", nullable: false),
                    EntranceIsExternal = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairRequests",
                columns: table => new
                {
                    RepairRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    RequestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestStatusId = table.Column<int>(type: "int", nullable: false),
                    DateOpened = table.Column<DateOnly>(type: "date", nullable: false),
                    DateSettled = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairRequests", x => x.RepairRequestId);
                    table.ForeignKey(
                        name: "FK_RepairRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RepairRequests_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairRequests_Enums_RequestStatusId",
                        column: x => x.RequestStatusId,
                        principalTable: "Enums",
                        principalColumn: "EnumsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBuildings",
                columns: table => new
                {
                    UserBuildingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBuildings", x => x.UserBuildingsId);
                    table.ForeignKey(
                        name: "FK_UserBuildings_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserBuildings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBuildings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyExpense",
                columns: table => new
                {
                    PropertyExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyExpenseTemplateId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyExpense", x => x.PropertyExpenseId);
                    table.ForeignKey(
                        name: "FK_PropertyExpense_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyExpense_PropertyExpenseTemplate_PropertyExpenseTemplateId",
                        column: x => x.PropertyExpenseTemplateId,
                        principalTable: "PropertyExpenseTemplate",
                        principalColumn: "PropertyExpenseTemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyResident",
                columns: table => new
                {
                    PropertyResidentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentTypeId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    EnterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LeaveDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyResident", x => x.PropertyResidentsId);
                    table.ForeignKey(
                        name: "FK_PropertyResident_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyUsers",
                columns: table => new
                {
                    PropertyUsersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PercentOfApartmentOwned = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyUsers", x => x.PropertyUsersId);
                    table.ForeignKey(
                        name: "FK_PropertyUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertyUsers_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestNotes",
                columns: table => new
                {
                    RequestNotesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    NoteText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RepairRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestNotes", x => x.RequestNotesId);
                    table.ForeignKey(
                        name: "FK_RequestNotes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestNotes_RepairRequests_RepairRequestId",
                        column: x => x.RepairRequestId,
                        principalTable: "RepairRequests",
                        principalColumn: "RepairRequestId");
                });

            migrationBuilder.CreateTable(
                name: "PropertyPayments",
                columns: table => new
                {
                    PropertyPaymentsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    AmountOwed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOpened = table.Column<DateOnly>(type: "date", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PropertyExpenseId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    PaymentParentId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true),
                    DeletedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPayments", x => x.PropertyPaymentsId);
                    table.ForeignKey(
                        name: "FK_PropertyPayments_Enums_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "Enums",
                        principalColumn: "EnumsId");
                    table.ForeignKey(
                        name: "FK_PropertyPayments_Enums_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Enums",
                        principalColumn: "EnumsId");
                    table.ForeignKey(
                        name: "FK_PropertyPayments_PropertyExpense_PropertyExpenseId",
                        column: x => x.PropertyExpenseId,
                        principalTable: "PropertyExpense",
                        principalColumn: "PropertyExpenseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyPayments_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingExpenses_BuildingId",
                table: "BuildingExpenses",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingExpenses_RepeatPeriodIdEnumsId",
                table: "BuildingExpenses",
                column: "RepeatPeriodIdEnumsId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingExpenses_SupplierIdEnumsId",
                table: "BuildingExpenses",
                column: "SupplierIdEnumsId");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_AddressId",
                table: "Buildings",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_BuildingId",
                table: "Property",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpense_PropertyExpenseTemplateId",
                table: "PropertyExpense",
                column: "PropertyExpenseTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpense_RoleId",
                table: "PropertyExpense",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyExpenseTemplate_RepeatPeriodId",
                table: "PropertyExpenseTemplate",
                column: "RepeatPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPayments_PaymentMethodId",
                table: "PropertyPayments",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPayments_PropertyExpenseId",
                table: "PropertyPayments",
                column: "PropertyExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPayments_PropertyId",
                table: "PropertyPayments",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPayments_StatusId",
                table: "PropertyPayments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyResident_PropertyId",
                table: "PropertyResident",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyUsers_PropertyId",
                table: "PropertyUsers",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyUsers_RoleId",
                table: "PropertyUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyUsers_UserId",
                table: "PropertyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairRequests_BuildingId",
                table: "RepairRequests",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairRequests_RequestStatusId",
                table: "RepairRequests",
                column: "RequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairRequests_UserId",
                table: "RepairRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestNotes_RepairRequestId",
                table: "RequestNotes",
                column: "RepairRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestNotes_UserId",
                table: "RequestNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuildings_BuildingId",
                table: "UserBuildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuildings_RoleId",
                table: "UserBuildings",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBuildings_UserId",
                table: "UserBuildings",
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
                name: "BuildingExpenses");

            migrationBuilder.DropTable(
                name: "PropertyPayments");

            migrationBuilder.DropTable(
                name: "PropertyResident");

            migrationBuilder.DropTable(
                name: "PropertyUsers");

            migrationBuilder.DropTable(
                name: "RequestNotes");

            migrationBuilder.DropTable(
                name: "UserBuildings");

            migrationBuilder.DropTable(
                name: "PropertyExpense");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "RepairRequests");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PropertyExpenseTemplate");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Enums");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
