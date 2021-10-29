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
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Before = table.Column<int>(type: "int", nullable: false),
                    After = table.Column<int>(type: "int", nullable: false),
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
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    DelayReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    PreviousId = table.Column<int>(type: "int", nullable: true),
                    NextId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WorkflowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks_NextId",
                        column: x => x.NextId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
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
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ContractType = table.Column<int>(type: "int", nullable: false)
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
                    MaxPrice = table.Column<double>(type: "float", nullable: false)
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
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FileDataId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Files_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 3, new byte[] { 5, 7, 8, 9, 10 } }
                });

            migrationBuilder.InsertData(
                table: "ModelTasks",
                columns: new[] { "Id", "Difficulty", "Type" },
                values: new object[,]
                {
                    { 603, 15, 1 },
                    { 602, 10, 1 },
                    { 601, 5, 1 },
                    { 502, 10, 6 },
                    { 501, 5, 6 },
                    { 403, 15, 4 },
                    { 402, 10, 4 },
                    { 401, 5, 4 },
                    { 303, 15, 5 },
                    { 302, 10, 5 },
                    { 503, 15, 6 },
                    { 203, 15, 2 },
                    { 202, 10, 2 },
                    { 201, 5, 2 },
                    { 103, 15, 0 },
                    { 102, 10, 0 },
                    { 101, 5, 0 },
                    { 3, 15, 3 },
                    { 2, 10, 3 },
                    { 1, 5, 3 },
                    { 301, 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "ModelWorkflows",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 5, "Slouží pro zakázky nad 1 000 000 Kč.", "Výběrové řízení velké zakázky" },
                    { 3, "Slouží pro zakázky do 100 000 Kč.", "Výběrové řízení malé zakázky" },
                    { 4, "Slouží pro zakázky do 1 000 000 Kč.", "Výběrové řízení střední zakázky" },
                    { 1, "Slouží pro nákup maximálně několika běžně dostupných položek.", "Rychlý model malého nákupu" },
                    { 2, "Slouží pro nákup více položek, s dodavatelem je sepsána exkluzivní smlouva.", "Model pro nákup se smlouvou" }
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
                    { 2, 2, new DateTime(2021, 10, 24, 23, 6, 15, 893, DateTimeKind.Local).AddTicks(2263), "Agenda spravující menší a střední zakázky", "Malé a střední zakázky" },
                    { 1, 1, new DateTime(2021, 9, 29, 23, 6, 15, 891, DateTimeKind.Local).AddTicks(9936), "Agenda správující jednoduchuché nákupy bez vúběrových řízení", "Nákupy" },
                    { 3, 1, new DateTime(2021, 8, 30, 23, 6, 15, 893, DateTimeKind.Local).AddTicks(2293), "Agenda spravující důležité velké zakázky", "Velké zakázky" }
                });

            migrationBuilder.InsertData(
                table: "ModelWorkflowTasks",
                columns: new[] { "ModelTaskId", "ModelWorkflowId", "Order" },
                values: new object[,]
                {
                    { 603, 5, 7 },
                    { 503, 5, 6 },
                    { 403, 5, 5 },
                    { 303, 5, 4 },
                    { 203, 5, 3 },
                    { 103, 5, 2 },
                    { 3, 5, 1 },
                    { 601, 4, 6 },
                    { 502, 4, 5 },
                    { 402, 4, 4 },
                    { 303, 4, 3 },
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
                    { 102, 4, 2 },
                    { 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Workflows",
                columns: new[] { "Id", "AgendaId", "Creation", "ExpectedEnd", "ModelWorkflowId", "Name", "State" },
                values: new object[] { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Testovací úkol", 0 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Active", "DelayReason", "Description", "End", "NextId", "Note", "PreviousId", "Priority", "Start", "UserId", "WorkflowId" },
                values: new object[] { 7, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Publishes",
                columns: new[] { "Id", "PublishEnd", "PublishStart" },
                values: new object[] { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Active", "DelayReason", "Description", "End", "NextId", "Note", "PreviousId", "Priority", "Start", "UserId", "WorkflowId" },
                values: new object[] { 6, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 5, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Publishes",
                columns: new[] { "Id", "PublishEnd", "PublishStart" },
                values: new object[] { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Active", "DelayReason", "Description", "End", "NextId", "Note", "PreviousId", "Priority", "Start", "UserId", "WorkflowId" },
                values: new object[] { 5, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, 4, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ContractType", "FinalPrice", "PriceChangeReason" },
                values: new object[] { 5, 0, 0.0, null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Active", "DelayReason", "Description", "End", "NextId", "Note", "PreviousId", "Priority", "Start", "UserId", "WorkflowId" },
                values: new object[] { 4, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Estimates",
                columns: new[] { "Id", "EstimatePrice", "MaxPrice" },
                values: new object[] { 4, 0.0, 0.0 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Active", "DelayReason", "Description", "End", "NextId", "Note", "PreviousId", "Priority", "Start", "UserId", "WorkflowId" },
                values: new object[] { 3, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Assessments",
                columns: new[] { "Id", "Conclusion" },
                values: new object[] { 3, null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Active", "DelayReason", "Description", "End", "NextId", "Note", "PreviousId", "Priority", "Start", "UserId", "WorkflowId" },
                values: new object[] { 2, false, "dovolená", null, new DateTime(2021, 11, 23, 23, 6, 15, 894, DateTimeKind.Local).AddTicks(7034), 3, "Přijato bez výhrad", 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Acceptations",
                columns: new[] { "Id", "Accepted", "Reason" },
                values: new object[] { 2, true, "Pěkně vypracováno" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Active", "DelayReason", "Description", "End", "NextId", "Note", "PreviousId", "Priority", "Start", "UserId", "WorkflowId" },
                values: new object[] { 1, true, "Testovací důvod vrácení", "Vytvořit zadání zakázky.", new DateTime(2021, 11, 1, 23, 6, 15, 894, DateTimeKind.Local).AddTicks(3969), 2, "Testovaci předvyplněný úkol obsahující i poznámku.", null, 0, new DateTime(2021, 10, 26, 23, 6, 15, 894, DateTimeKind.Local).AddTicks(6208), 1, 1 });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Currency", "PriceGues", "Reason" },
                values: new object[] { 1, 1, 4368.1999999999998, "Testovací důvod vypsání tohoto úkolu." });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "FileDataId", "Name", "Number", "TaskId", "Type" },
                values: new object[,]
                {
                    { 1, 1, "test soubor", null, 1, 0 },
                    { 2, 2, "soubor1", null, 1, 0 },
                    { 3, 3, "soubor ABC", null, 1, 0 }
                });

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
                name: "IX_Files_TaskId",
                table: "Files",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelWorkflowTasks_ModelWorkflowId",
                table: "ModelWorkflowTasks",
                column: "ModelWorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_WorkflowId",
                table: "Notes",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_NextId",
                table: "Tasks",
                column: "NextId",
                unique: true,
                filter: "[NextId] IS NOT NULL");

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
