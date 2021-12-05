using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace itu.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelTasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelWorkflows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelWorkflows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelWorkflowTasks",
                columns: table => new
                {
                    ModelWorkflowId = table.Column<int>(type: "int", nullable: false),
                    ModelTaskId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelWorkflowTasks", x => new { x.ModelTaskId, x.ModelWorkflowId });
                    table.ForeignKey(
                        name: "FK_ModelWorkflowTasks_ModelTasks_ModelTaskId",
                        column: x => x.ModelTaskId,
                        principalTable: "ModelTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelWorkflowTasks_ModelWorkflows_ModelWorkflowId",
                        column: x => x.ModelWorkflowId,
                        principalTable: "ModelWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdministratorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Users_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendaModelEntity",
                columns: table => new
                {
                    AgendaId = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaModelEntity", x => new { x.ModelId, x.AgendaId });
                    table.ForeignKey(
                        name: "FK_AgendaModelEntity_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendaModelEntity_ModelWorkflows_ModelId",
                        column: x => x.ModelId,
                        principalTable: "ModelWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgendaRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AgendaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaRoles_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgendaRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workflows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    AgendaId = table.Column<int>(type: "int", nullable: false),
                    ModelWorkflowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workflows_Agendas_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workflows_ModelWorkflows_ModelWorkflowId",
                        column: x => x.ModelWorkflowId,
                        principalTable: "ModelWorkflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MIME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FileDataId = table.Column<int>(type: "int", nullable: false),
                    WorkflowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_FileData_FileDataId",
                        column: x => x.FileDataId,
                        principalTable: "FileData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Workflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Before = table.Column<int>(type: "int", nullable: false),
                    After = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Workflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    DelayReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WorkflowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Workflows_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Acceptations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Benefit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceGues = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acceptations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acceptations_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Archivations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Cancallation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archivations_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Conclusion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assessments_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Benefit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceGues = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<double>(type: "float", nullable: false),
                    PriceChangeReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractType = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estimates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EstimatePrice = table.Column<double>(type: "float", nullable: false),
                    MaxPrice = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimates_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PublishStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublishEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishes_Tasks_Id",
                        column: x => x.Id,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FileData",
                columns: new[] { "Id", "Data" },
                values: new object[,]
                {
                    { 1, new byte[] { 5, 7, 8, 9, 10 } },
                    { 2, new byte[] { 5, 7, 8, 9, 10 } },
                    { 3, new byte[] { 6, 6, 8, 9, 10 } }
                });

            migrationBuilder.InsertData(
                table: "ModelTasks",
                columns: new[] { "Id", "Difficulty", "Type" },
                values: new object[,]
                {
                    { 603, 15, 6 },
                    { 602, 10, 6 },
                    { 601, 5, 6 },
                    { 502, 10, 5 },
                    { 501, 5, 5 },
                    { 403, 15, 4 },
                    { 402, 10, 4 },
                    { 401, 5, 4 },
                    { 303, 15, 2 },
                    { 302, 10, 2 },
                    { 503, 15, 5 },
                    { 203, 15, 3 },
                    { 202, 10, 3 },
                    { 201, 5, 3 },
                    { 103, 15, 1 },
                    { 102, 10, 1 },
                    { 101, 5, 1 },
                    { 3, 15, 0 },
                    { 2, 10, 0 },
                    { 1, 5, 0 },
                    { 301, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "ModelWorkflows",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 6, "Slouží pro velký nákup více položek, u kterých je vyžadováno posouzení a odhad ceny. S dodavatelem je sepsána exkluzivní smlouva.", "Model pro velké nákupy" },
                    { 5, "Slouží pro velké zakázky nad 1 000 000 Kč. Jedná se o nejdůležitější zakázky.", "Výběrové řízení velké zakázky" },
                    { 4, "Slouží pro střední zakázky do 1 000 000 Kč.", "Výběrové řízení střední zakázky" },
                    { 2, "Slouží pro nákup více položek, s dodavatelem je sepsána exkluzivní smlouva.", "Model pro nákup se smlouvou" },
                    { 1, "Slouží pro nákup maximálně několika běžně dostupných položek.", "Rychlý model malého nákupu" },
                    { 3, "Slouží pro malé zakázky do 100 000 Kč.", "Výběrové řízení malé zakázky" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 11, "User", "9", "test", "u9" },
                    { 1, "Super", "User", "test", "su" },
                    { 2, "System", "Admin", "admin", "admin" },
                    { 3, "User", "1", "test", "u1" },
                    { 4, "User", "2", "test", "u2" },
                    { 5, "User", "3", "test", "u3" },
                    { 6, "User", "4", "test", "u4" },
                    { 7, "User", "5", "test", "u5" },
                    { 8, "User", "6", "test", "u6" },
                    { 9, "User", "7", "test", "u7" },
                    { 10, "User", "8", "test", "u8" },
                    { 12, "User", "10", "test", "u10" }
                });

            migrationBuilder.InsertData(
                table: "Agendas",
                columns: new[] { "Id", "AdministratorId", "Creation", "Description", "Name" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2021, 11, 30, 11, 8, 2, 120, DateTimeKind.Local).AddTicks(2145), "Agenda spravující menší a střední zakázky", "Malé a střední zakázky" },
                    { 1, 1, new DateTime(2021, 11, 5, 11, 8, 2, 118, DateTimeKind.Local).AddTicks(9965), "Agenda správující jednoduchuché nákupy bez vúběrových řízení", "Nákupy" },
                    { 3, 1, new DateTime(2021, 10, 6, 11, 8, 2, 120, DateTimeKind.Local).AddTicks(2166), "Agenda spravující důležité velké zakázky", "Velké zakázky" }
                });

            migrationBuilder.InsertData(
                table: "ModelWorkflowTasks",
                columns: new[] { "ModelTaskId", "ModelWorkflowId", "Order" },
                values: new object[,]
                {
                    { 403, 6, 5 },
                    { 302, 6, 4 },
                    { 201, 6, 3 },
                    { 102, 6, 2 },
                    { 2, 6, 1 },
                    { 603, 5, 7 },
                    { 503, 5, 6 },
                    { 403, 5, 5 },
                    { 303, 5, 4 },
                    { 203, 5, 3 },
                    { 103, 5, 2 },
                    { 3, 5, 1 },
                    { 601, 4, 6 },
                    { 502, 4, 5 },
                    { 303, 4, 3 },
                    { 102, 4, 2 },
                    { 2, 4, 1 },
                    { 602, 3, 5 },
                    { 501, 3, 4 },
                    { 402, 3, 3 },
                    { 102, 3, 2 },
                    { 2, 3, 1 },
                    { 603, 2, 4 },
                    { 402, 2, 3 },
                    { 102, 2, 2 },
                    { 1, 2, 1 },
                    { 101, 1, 2 },
                    { 402, 4, 4 },
                    { 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "AgendaModelEntity",
                columns: new[] { "AgendaId", "ModelId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 5 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "AgendaRoles",
                columns: new[] { "Id", "AgendaId", "Type", "UserId" },
                values: new object[,]
                {
                    { 7, 3, 5, 1 },
                    { 8, 3, 6, 1 },
                    { 6, 3, 4, 1 },
                    { 11, 2, 0, 1 },
                    { 13, 2, 3, 2 },
                    { 14, 2, 3, 1 },
                    { 15, 2, 4, 3 },
                    { 16, 2, 4, 1 },
                    { 17, 2, 5, 2 },
                    { 18, 2, 6, 1 },
                    { 12, 2, 1, 2 },
                    { 3, 3, 2, 2 },
                    { 4, 3, 3, 3 },
                    { 23, 1, 6, null },
                    { 1, 3, 0, 1 },
                    { 9, 1, 0, 1 },
                    { 10, 1, 1, 3 },
                    { 21, 1, 1, 2 },
                    { 19, 1, 0, 5 },
                    { 24, 1, 2, 3 },
                    { 20, 1, 3, 1 },
                    { 22, 1, 4, 1 },
                    { 2, 3, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Id", "AgendaId", "Creation", "Description", "ExpectedEnd", "ModelWorkflowId", "Name", "State" },
                values: new object[,]
                {
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Úklid prostor budovy", 0 },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nová kopírka", 0 },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Nákup zahradních strojů", 0 },
                    { 9, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dnec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Výstavba silnice", 1 },
                    { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam rhoncus aliquam metus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Stavba depa", 0 },
                    { 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dnec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Nákup dronů", 2 },
                    { 8, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dnec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nákup kouzelnických hůlek", 3 },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam rhoncus aliquam metus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Nákup dárků na Vánoce", 0 },
                    { 6, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Návrh vzhledu nové stanice", 0 }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileDataId", "MIME", "Name", "Number", "Type", "Version", "WorkflowId" },
                values: new object[,]
                {
                    { 3, 3, "text/plain", "soubor2.txt", "ID_11", 2, 1, 2 },
                    { 1, 1, "text/plain", "test soubor.c", "ID_852", 0, 1, 1 },
                    { 2, 2, "text/plain", "soubor1.txt", "ID_7823", 0, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Active", "DelayReason", "End", "Note", "Order", "Priority", "Start", "UserId", "WorkflowId" },
                values: new object[,]
                {
                    { 19, false, null, new DateTime(2021, 12, 1, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5592), null, 4, 3, new DateTime(2021, 11, 22, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5594), 3, 6 },
                    { 16, false, null, new DateTime(2021, 11, 6, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5572), null, 1, 1, new DateTime(2021, 10, 26, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5573), 1, 6 },
                    { 21, true, null, new DateTime(2021, 12, 21, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6436), null, 6, 3, new DateTime(2021, 12, 3, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6442), 1, 6 },
                    { 17, false, null, new DateTime(2021, 11, 13, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5577), null, 2, 2, new DateTime(2021, 11, 6, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5578), 1, 6 },
                    { 15, true, null, new DateTime(2021, 12, 14, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5488), null, 4, 1, new DateTime(2021, 12, 1, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5496), 2, 5 },
                    { 14, false, null, new DateTime(2021, 12, 1, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4284), "Je to DPP.", 3, 3, new DateTime(2021, 11, 22, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4285), 3, 5 },
                    { 12, false, null, new DateTime(2021, 11, 17, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4275), "Cena je měsíčně.", 1, 1, new DateTime(2021, 11, 10, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4277), 1, 5 },
                    { 13, false, null, new DateTime(2021, 11, 22, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4279), "Cena je měsíčně.", 2, 2, new DateTime(2021, 11, 17, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4281), 1, 5 },
                    { 26, true, null, new DateTime(2021, 12, 15, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6464), null, 1, 3, new DateTime(2021, 12, 4, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6465), 1, 9 },
                    { 3, false, null, new DateTime(2021, 11, 28, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(2785), null, 3, 0, new DateTime(2021, 11, 22, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(2791), 3, 1 },
                    { 5, true, null, new DateTime(2021, 12, 20, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4223), null, 5, 1, new DateTime(2021, 12, 2, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4230), 1, 1 },
                    { 1, false, null, new DateTime(2021, 11, 19, 11, 8, 2, 122, DateTimeKind.Local).AddTicks(8670), "Testovaci předvyplněný úkol obsahující i poznámku.", 1, 3, new DateTime(2021, 11, 15, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(48), 1, 1 },
                    { 4, false, null, new DateTime(2021, 12, 2, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(3732), null, 4, 2, new DateTime(2021, 11, 28, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(3738), 2, 1 },
                    { 2, false, "dovolená", new DateTime(2021, 11, 22, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(1040), "Přijato bez výhrad", 2, 2, new DateTime(2021, 11, 19, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(2527), 2, 1 },
                    { 24, false, null, new DateTime(2021, 11, 9, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6456), null, 1, 1, new DateTime(2021, 11, 3, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6457), 1, 8 },
                    { 25, false, null, new DateTime(2021, 11, 15, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6460), null, 2, 0, new DateTime(2021, 11, 9, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6461), 2, 8 },
                    { 22, false, null, new DateTime(2021, 11, 9, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6447), null, 1, 0, new DateTime(2021, 11, 1, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6448), 1, 7 },
                    { 23, false, null, new DateTime(2021, 11, 15, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6451), null, 2, 2, new DateTime(2021, 11, 9, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(6453), 3, 7 },
                    { 11, true, null, new DateTime(2021, 12, 31, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4272), null, 3, 0, new DateTime(2021, 12, 3, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4273), 1, 4 },
                    { 9, false, null, new DateTime(2021, 11, 30, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4261), null, 1, 2, new DateTime(2021, 11, 20, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4263), 5, 4 },
                    { 10, false, null, new DateTime(2021, 12, 3, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4266), null, 2, 2, new DateTime(2021, 11, 30, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4268), 3, 4 },
                    { 8, true, null, new DateTime(2022, 1, 14, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4257), null, 1, 2, new DateTime(2021, 12, 4, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4259), 1, 3 },
                    { 6, false, null, new DateTime(2021, 11, 30, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4248), null, 1, 3, new DateTime(2021, 11, 27, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4250), 5, 2 },
                    { 7, true, null, new DateTime(2021, 12, 10, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4254), null, 2, 0, new DateTime(2021, 11, 30, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(4255), 2, 2 },
                    { 18, false, null, new DateTime(2021, 11, 22, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5587), null, 3, 2, new DateTime(2021, 11, 13, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5589), 2, 6 },
                    { 20, false, null, new DateTime(2021, 12, 3, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5596), null, 5, 1, new DateTime(2021, 12, 1, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5598), 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "Acceptations",
                columns: new[] { "Id", "Accepted", "Benefit", "Currency", "PriceGues", "Reason" },
                values: new object[,]
                {
                    { 7, false, null, 0, 0.0, null },
                    { 10, true, "Místo 8 zahradnílů nám budou stačit 4.", 2, 3335.4099999999999, "Ano, to by se mělo vyplatit.." },
                    { 17, true, "Uvidíme i pohled z jiného úhlu.", 0, 245321.0, "Ano, tuto investici je možné ospravedlnit." },
                    { 23, true, "Potřebujeme drony pro střežení pozemku!", 2, 1450.0, "To bude super!" },
                    { 13, true, "Nebudeme muset zaměstnancum platit přesčasy za úklid.", 0, 23515.41, "Snad se to vyplatí." },
                    { 25, false, "Musíme se naučit kouzlit.", 1, 8521.0, "Kouzlit si můžete po pracovní době!" },
                    { 2, true, "Testovací předvyplněný úkol obsahující i přínos organizaci.", 1, 7369821.0, "Pěkně vypracováno" }
                });

            migrationBuilder.InsertData(
                table: "Archivations",
                columns: new[] { "Id", "Cancallation", "Location", "Number" },
                values: new object[] { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 });

            migrationBuilder.InsertData(
                table: "Assessments",
                columns: new[] { "Id", "Conclusion" },
                values: new object[] { 4, "Vše se zdá být v pořádku, cena odpovídá." });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Benefit", "Currency", "PriceGues" },
                values: new object[,]
                {
                    { 16, "Uvidíme i pohled z jiného úhlu.", 0, 245321.0 },
                    { 12, "Nebudeme muset zaměstnancum platit přesčasy za úklid.", 0, 23515.41 },
                    { 26, null, 0, 0.0 },
                    { 1, "Testovací předvyplněný úkol obsahující i přínos organizaci.", 1, 7369821.0 },
                    { 24, "Musíme se naučit kouzlit.", 1, 8521.0 },
                    { 22, "Potřebujeme drony pro střežení pozemku!", 2, 1450.0 },
                    { 9, "Místo 8 zahradnílů nám budou stačit 4.", 2, 3335.4099999999999 },
                    { 8, null, 0, 0.0 },
                    { 6, "Všichni nás pak budou mít rádi :).", 0, 26320.0 }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ContractType", "Currency", "FinalPrice", "PriceChangeReason" },
                values: new object[,]
                {
                    { 5, 0, 0, 0.0, null },
                    { 14, 4, 0, 25600.0, "Je teď těžké sehnat uklízeče, nutno zvýčit odměnu." },
                    { 19, 2, 0, 225000.0, null }
                });

            migrationBuilder.InsertData(
                table: "Estimates",
                columns: new[] { "Id", "Currency", "EstimatePrice", "MaxPrice" },
                values: new object[,]
                {
                    { 3, 1, 8632148.0, 10000000.0 },
                    { 11, 0, 0.0, 0.0 },
                    { 18, 0, 225000.0, 275000.0 }
                });

            migrationBuilder.InsertData(
                table: "Publishes",
                columns: new[] { "Id", "PublishEnd", "PublishStart" },
                values: new object[,]
                {
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2022, 1, 29, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5922), new DateTime(2021, 12, 30, 11, 8, 2, 123, DateTimeKind.Local).AddTicks(5600) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaModelEntity_AgendaId",
                table: "AgendaModelEntity",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaRoles_AgendaId",
                table: "AgendaRoles",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaRoles_UserId",
                table: "AgendaRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_AdministratorId",
                table: "Agendas",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FileDataId",
                table: "Files",
                column: "FileDataId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_WorkflowId",
                table: "Files",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelWorkflowTasks_ModelWorkflowId",
                table: "ModelWorkflowTasks",
                column: "ModelWorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_WorkflowId",
                table: "Notes",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorkflowId",
                table: "Tasks",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_AgendaId",
                table: "Workflows",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Workflows_ModelWorkflowId",
                table: "Workflows",
                column: "ModelWorkflowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acceptations");

            migrationBuilder.DropTable(
                name: "AgendaModelEntity");

            migrationBuilder.DropTable(
                name: "AgendaRoles");

            migrationBuilder.DropTable(
                name: "Archivations");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Estimates");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "ModelWorkflowTasks");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Publishes");

            migrationBuilder.DropTable(
                name: "FileData");

            migrationBuilder.DropTable(
                name: "ModelTasks");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Workflows");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "ModelWorkflows");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
