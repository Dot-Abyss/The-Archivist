using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_Archivist.Migrations
{
    public partial class InintializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ArchiveTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    typeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orgnizations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orgName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orgTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgnizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orgnizations_OrgTypes_orgTypesId",
                        column: x => x.orgTypesId,
                        principalSchema: "dbo",
                        principalTable: "OrgTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    depName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orgnizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Orgnizations_orgnizationId",
                        column: x => x.orgnizationId,
                        principalSchema: "dbo",
                        principalTable: "Orgnizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Archives",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    archiveTypeId = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    imageSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    publishDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archives_ArchiveTypes_archiveTypeId",
                        column: x => x.archiveTypeId,
                        principalSchema: "dbo",
                        principalTable: "ArchiveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Archives_Clients_clientId",
                        column: x => x.clientId,
                        principalSchema: "dbo",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Archives_Departments_departmentId",
                        column: x => x.departmentId,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    orgnizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_departmentId",
                        column: x => x.departmentId,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Orgnizations_orgnizationId",
                        column: x => x.orgnizationId,
                        principalSchema: "dbo",
                        principalTable: "Orgnizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ArchiveEmployee",
                schema: "dbo",
                columns: table => new
                {
                    archivesId = table.Column<int>(type: "int", nullable: false),
                    employeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchiveEmployee", x => new { x.archivesId, x.employeesId });
                    table.ForeignKey(
                        name: "FK_ArchiveEmployee_Archives_archivesId",
                        column: x => x.archivesId,
                        principalSchema: "dbo",
                        principalTable: "Archives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArchiveEmployee_Employees_employeesId",
                        column: x => x.employeesId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchiveEmployee_employeesId",
                schema: "dbo",
                table: "ArchiveEmployee",
                column: "employeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Archives_archiveTypeId",
                schema: "dbo",
                table: "Archives",
                column: "archiveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Archives_clientId",
                schema: "dbo",
                table: "Archives",
                column: "clientId");

            migrationBuilder.CreateIndex(
                name: "IX_Archives_departmentId",
                schema: "dbo",
                table: "Archives",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_orgnizationId",
                schema: "dbo",
                table: "Departments",
                column: "orgnizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_departmentId",
                schema: "dbo",
                table: "Employees",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_orgnizationId",
                schema: "dbo",
                table: "Employees",
                column: "orgnizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orgnizations_orgTypesId",
                schema: "dbo",
                table: "Orgnizations",
                column: "orgTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchiveEmployee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Archives",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ArchiveTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Clients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Orgnizations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrgTypes",
                schema: "dbo");
        }
    }
}
