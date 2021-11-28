﻿//=================================================================================================================
// vygenerovany soubor
//=================================================================================================================

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using itu.DAL;

namespace itu.DAL.Migrations
{
    [DbContext(typeof(ItuDbContext))]
    [Migration("20211128122423_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("itu.DAL.Entities.AgendaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdministratorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Agendas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdministratorId = 1,
                            Creation = new DateTime(2021, 10, 29, 13, 24, 23, 132, DateTimeKind.Local).AddTicks(7092),
                            Description = "Agenda správující jednoduchuché nákupy bez vúběrových řízení",
                            Name = "Nákupy"
                        },
                        new
                        {
                            Id = 2,
                            AdministratorId = 2,
                            Creation = new DateTime(2021, 11, 23, 13, 24, 23, 133, DateTimeKind.Local).AddTicks(8769),
                            Description = "Agenda spravující menší a střední zakázky",
                            Name = "Malé a střední zakázky"
                        },
                        new
                        {
                            Id = 3,
                            AdministratorId = 1,
                            Creation = new DateTime(2021, 9, 29, 13, 24, 23, 133, DateTimeKind.Local).AddTicks(8790),
                            Description = "Agenda spravující důležité velké zakázky",
                            Name = "Velké zakázky"
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.AgendaModelEntity", b =>
                {
                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<int>("AgendaId")
                        .HasColumnType("int");

                    b.HasKey("ModelId", "AgendaId");

                    b.HasIndex("AgendaId");

                    b.ToTable("AgendaModelEntity");

                    b.HasData(
                        new
                        {
                            ModelId = 1,
                            AgendaId = 1
                        },
                        new
                        {
                            ModelId = 2,
                            AgendaId = 2
                        },
                        new
                        {
                            ModelId = 3,
                            AgendaId = 2
                        },
                        new
                        {
                            ModelId = 4,
                            AgendaId = 2
                        },
                        new
                        {
                            ModelId = 5,
                            AgendaId = 3
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.AgendaRoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgendaId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.HasIndex("UserId");

                    b.ToTable("AgendaRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgendaId = 3,
                            Type = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            AgendaId = 3,
                            Type = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            AgendaId = 3,
                            Type = 2,
                            UserId = 1
                        },
                        new
                        {
                            Id = 4,
                            AgendaId = 3,
                            Type = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 6,
                            AgendaId = 3,
                            Type = 4,
                            UserId = 1
                        },
                        new
                        {
                            Id = 7,
                            AgendaId = 3,
                            Type = 5,
                            UserId = 1
                        },
                        new
                        {
                            Id = 8,
                            AgendaId = 3,
                            Type = 6,
                            UserId = 1
                        },
                        new
                        {
                            Id = 9,
                            AgendaId = 1,
                            Type = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 10,
                            AgendaId = 1,
                            Type = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 19,
                            AgendaId = 1,
                            Type = 4
                        },
                        new
                        {
                            Id = 20,
                            AgendaId = 1,
                            Type = 3
                        },
                        new
                        {
                            Id = 11,
                            AgendaId = 2,
                            Type = 0,
                            UserId = 1
                        },
                        new
                        {
                            Id = 12,
                            AgendaId = 2,
                            Type = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 13,
                            AgendaId = 2,
                            Type = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 14,
                            AgendaId = 2,
                            Type = 3,
                            UserId = 2
                        },
                        new
                        {
                            Id = 15,
                            AgendaId = 2,
                            Type = 4,
                            UserId = 2
                        },
                        new
                        {
                            Id = 16,
                            AgendaId = 2,
                            Type = 4,
                            UserId = 2
                        },
                        new
                        {
                            Id = 17,
                            AgendaId = 2,
                            Type = 5,
                            UserId = 2
                        },
                        new
                        {
                            Id = 18,
                            AgendaId = 2,
                            Type = 6,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.FileDataEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("FileData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Data = new byte[] { 5, 7, 8, 9, 10 }
                        },
                        new
                        {
                            Id = 2,
                            Data = new byte[] { 5, 7, 8, 9, 10 }
                        },
                        new
                        {
                            Id = 3,
                            Data = new byte[] { 6, 6, 8, 9, 10 }
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.FileEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FileDataId")
                        .HasColumnType("int");

                    b.Property<string>("MIME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.Property<int>("WorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FileDataId")
                        .IsUnique();

                    b.HasIndex("WorkflowId");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FileDataId = 1,
                            MIME = "text/plain",
                            Name = "test soubor.c",
                            Number = "ID_852",
                            Type = 0,
                            Version = 1,
                            WorkflowId = 1
                        },
                        new
                        {
                            Id = 2,
                            FileDataId = 2,
                            MIME = "text/plain",
                            Name = "soubor1.txt",
                            Number = "ID_7823",
                            Type = 0,
                            Version = 1,
                            WorkflowId = 1
                        },
                        new
                        {
                            Id = 3,
                            FileDataId = 3,
                            MIME = "text/plain",
                            Name = "soubor2.txt",
                            Number = "ID_11",
                            Type = 2,
                            Version = 1,
                            WorkflowId = 2
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.ModelTaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ModelTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Difficulty = 5,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Difficulty = 10,
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            Difficulty = 15,
                            Type = 0
                        },
                        new
                        {
                            Id = 101,
                            Difficulty = 5,
                            Type = 1
                        },
                        new
                        {
                            Id = 102,
                            Difficulty = 10,
                            Type = 1
                        },
                        new
                        {
                            Id = 103,
                            Difficulty = 15,
                            Type = 1
                        },
                        new
                        {
                            Id = 201,
                            Difficulty = 5,
                            Type = 3
                        },
                        new
                        {
                            Id = 202,
                            Difficulty = 10,
                            Type = 3
                        },
                        new
                        {
                            Id = 203,
                            Difficulty = 15,
                            Type = 3
                        },
                        new
                        {
                            Id = 301,
                            Difficulty = 5,
                            Type = 2
                        },
                        new
                        {
                            Id = 302,
                            Difficulty = 10,
                            Type = 2
                        },
                        new
                        {
                            Id = 303,
                            Difficulty = 15,
                            Type = 2
                        },
                        new
                        {
                            Id = 401,
                            Difficulty = 5,
                            Type = 4
                        },
                        new
                        {
                            Id = 402,
                            Difficulty = 10,
                            Type = 4
                        },
                        new
                        {
                            Id = 403,
                            Difficulty = 15,
                            Type = 4
                        },
                        new
                        {
                            Id = 501,
                            Difficulty = 5,
                            Type = 5
                        },
                        new
                        {
                            Id = 502,
                            Difficulty = 10,
                            Type = 5
                        },
                        new
                        {
                            Id = 503,
                            Difficulty = 15,
                            Type = 5
                        },
                        new
                        {
                            Id = 601,
                            Difficulty = 5,
                            Type = 6
                        },
                        new
                        {
                            Id = 602,
                            Difficulty = 10,
                            Type = 6
                        },
                        new
                        {
                            Id = 603,
                            Difficulty = 15,
                            Type = 6
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.ModelWorkflowEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ModelWorkflows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Slouží pro nákup maximálně několika běžně dostupných položek.",
                            Name = "Rychlý model malého nákupu"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Slouží pro nákup více položek, s dodavatelem je sepsána exkluzivní smlouva.",
                            Name = "Model pro nákup se smlouvou"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Slouží pro malé zakázky do 100 000 Kč.",
                            Name = "Výběrové řízení malé zakázky"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Slouží pro střední zakázky do 1 000 000 Kč.",
                            Name = "Výběrové řízení střední zakázky"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Slouží pro velké zakázky nad 1 000 000 Kč. Jedná se o nejdůležitější zakázky.",
                            Name = "Výběrové řízení velké zakázky"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Slouží pro velký nákup více položek, u kterých je vyžadováno posouzení a odhad ceny. S dodavatelem je sepsána exkluzivní smlouva.",
                            Name = "Model pro velké nákupy"
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.ModelWorkflowTaskEntity", b =>
                {
                    b.Property<int>("ModelTaskId")
                        .HasColumnType("int");

                    b.Property<int>("ModelWorkflowId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("ModelTaskId", "ModelWorkflowId");

                    b.HasIndex("ModelWorkflowId");

                    b.ToTable("ModelWorkflowTasks");

                    b.HasData(
                        new
                        {
                            ModelTaskId = 1,
                            ModelWorkflowId = 1,
                            Order = 1
                        },
                        new
                        {
                            ModelTaskId = 101,
                            ModelWorkflowId = 1,
                            Order = 2
                        },
                        new
                        {
                            ModelTaskId = 1,
                            ModelWorkflowId = 2,
                            Order = 1
                        },
                        new
                        {
                            ModelTaskId = 102,
                            ModelWorkflowId = 2,
                            Order = 2
                        },
                        new
                        {
                            ModelTaskId = 402,
                            ModelWorkflowId = 2,
                            Order = 3
                        },
                        new
                        {
                            ModelTaskId = 603,
                            ModelWorkflowId = 2,
                            Order = 4
                        },
                        new
                        {
                            ModelTaskId = 2,
                            ModelWorkflowId = 3,
                            Order = 1
                        },
                        new
                        {
                            ModelTaskId = 102,
                            ModelWorkflowId = 3,
                            Order = 2
                        },
                        new
                        {
                            ModelTaskId = 402,
                            ModelWorkflowId = 3,
                            Order = 3
                        },
                        new
                        {
                            ModelTaskId = 501,
                            ModelWorkflowId = 3,
                            Order = 4
                        },
                        new
                        {
                            ModelTaskId = 602,
                            ModelWorkflowId = 3,
                            Order = 5
                        },
                        new
                        {
                            ModelTaskId = 2,
                            ModelWorkflowId = 4,
                            Order = 1
                        },
                        new
                        {
                            ModelTaskId = 102,
                            ModelWorkflowId = 4,
                            Order = 2
                        },
                        new
                        {
                            ModelTaskId = 303,
                            ModelWorkflowId = 4,
                            Order = 3
                        },
                        new
                        {
                            ModelTaskId = 402,
                            ModelWorkflowId = 4,
                            Order = 4
                        },
                        new
                        {
                            ModelTaskId = 502,
                            ModelWorkflowId = 4,
                            Order = 5
                        },
                        new
                        {
                            ModelTaskId = 601,
                            ModelWorkflowId = 4,
                            Order = 6
                        },
                        new
                        {
                            ModelTaskId = 3,
                            ModelWorkflowId = 5,
                            Order = 1
                        },
                        new
                        {
                            ModelTaskId = 103,
                            ModelWorkflowId = 5,
                            Order = 2
                        },
                        new
                        {
                            ModelTaskId = 203,
                            ModelWorkflowId = 5,
                            Order = 3
                        },
                        new
                        {
                            ModelTaskId = 303,
                            ModelWorkflowId = 5,
                            Order = 4
                        },
                        new
                        {
                            ModelTaskId = 403,
                            ModelWorkflowId = 5,
                            Order = 5
                        },
                        new
                        {
                            ModelTaskId = 503,
                            ModelWorkflowId = 5,
                            Order = 6
                        },
                        new
                        {
                            ModelTaskId = 603,
                            ModelWorkflowId = 5,
                            Order = 7
                        },
                        new
                        {
                            ModelTaskId = 2,
                            ModelWorkflowId = 6,
                            Order = 1
                        },
                        new
                        {
                            ModelTaskId = 102,
                            ModelWorkflowId = 6,
                            Order = 2
                        },
                        new
                        {
                            ModelTaskId = 201,
                            ModelWorkflowId = 6,
                            Order = 3
                        },
                        new
                        {
                            ModelTaskId = 302,
                            ModelWorkflowId = 6,
                            Order = 4
                        },
                        new
                        {
                            ModelTaskId = 403,
                            ModelWorkflowId = 6,
                            Order = 5
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.NoteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("After")
                        .HasColumnType("int");

                    b.Property<int>("Before")
                        .HasColumnType("int");

                    b.Property<int>("WorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkflowId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("itu.DAL.Entities.TaskEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("DelayReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WorkflowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkflowId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("itu.DAL.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Super",
                            LastName = "User",
                            Password = "test",
                            UserName = "su"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "System",
                            LastName = "Admin",
                            Password = "admin",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "User",
                            LastName = "1",
                            Password = "test",
                            UserName = "u1"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "User",
                            LastName = "2",
                            Password = "test",
                            UserName = "u2"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "User",
                            LastName = "3",
                            Password = "test",
                            UserName = "u3"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "User",
                            LastName = "4",
                            Password = "test",
                            UserName = "u4"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "User",
                            LastName = "5",
                            Password = "test",
                            UserName = "u5"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "User",
                            LastName = "6",
                            Password = "test",
                            UserName = "u6"
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "User",
                            LastName = "7",
                            Password = "test",
                            UserName = "u7"
                        },
                        new
                        {
                            Id = 10,
                            FirstName = "User",
                            LastName = "8",
                            Password = "test",
                            UserName = "u8"
                        },
                        new
                        {
                            Id = 11,
                            FirstName = "User",
                            LastName = "9",
                            Password = "test",
                            UserName = "u9"
                        },
                        new
                        {
                            Id = 12,
                            FirstName = "User",
                            LastName = "10",
                            Password = "test",
                            UserName = "u10"
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.WorkflowEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgendaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpectedEnd")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModelWorkflowId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgendaId");

                    b.HasIndex("ModelWorkflowId");

                    b.ToTable("Workflows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgendaId = 3,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam rhoncus aliquam metus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 5,
                            Name = "1. testovací úkol",
                            State = 0
                        },
                        new
                        {
                            Id = 2,
                            AgendaId = 2,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam rhoncus aliquam metus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 2,
                            Name = "2. testovací úkol",
                            State = 0
                        },
                        new
                        {
                            Id = 3,
                            AgendaId = 1,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 1,
                            Name = "3. testovací úkol",
                            State = 0
                        },
                        new
                        {
                            Id = 4,
                            AgendaId = 2,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 2,
                            Name = "4. testovací úkol",
                            State = 0
                        },
                        new
                        {
                            Id = 5,
                            AgendaId = 2,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 3,
                            Name = "5. testovací úkol",
                            State = 0
                        },
                        new
                        {
                            Id = 6,
                            AgendaId = 3,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 5,
                            Name = "6. testovací úkol",
                            State = 0
                        },
                        new
                        {
                            Id = 7,
                            AgendaId = 2,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Donec odio tempus molestie, porttitor ut, iaculis quis. Per inceptos hymenaeos. Sed vel lectus. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 4,
                            Name = "7. testovací úkol",
                            State = 0
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.AcceptationEntity", b =>
                {
                    b.HasBaseType("itu.DAL.Entities.TaskEntity");

                    b.Property<bool>("Accepted")
                        .HasColumnType("bit");

                    b.Property<string>("Benefit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<double>("PriceGues")
                        .HasColumnType("float");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Acceptations");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Active = true,
                            DelayReason = "dovolená",
                            End = new DateTime(2021, 11, 21, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(3929),
                            Note = "Přijato bez výhrad",
                            Order = 0,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 21, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(4457),
                            UserId = 1,
                            WorkflowId = 2,
                            Accepted = true,
                            Currency = 0,
                            PriceGues = 0.0,
                            Reason = "Pěkně vypracováno"
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.ArchivationEntity", b =>
                {
                    b.HasBaseType("itu.DAL.Entities.TaskEntity");

                    b.Property<DateTime>("Cancallation")
                        .HasColumnType("datetime2");

                    b.Property<int>("Location")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.ToTable("Archivations");

                    b.HasData(
                        new
                        {
                            Id = 7,
                            Active = true,
                            End = new DateTime(2021, 12, 2, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(5700),
                            Order = 0,
                            Priority = 1,
                            Start = new DateTime(2021, 11, 22, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(5706),
                            UserId = 1,
                            WorkflowId = 7,
                            Cancallation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = 0,
                            Number = 0
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.AssessmentEntity", b =>
                {
                    b.HasBaseType("itu.DAL.Entities.TaskEntity");

                    b.Property<string>("Conclusion")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Assessments");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Active = true,
                            End = new DateTime(2021, 12, 10, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(4721),
                            Order = 0,
                            Priority = 1,
                            Start = new DateTime(2021, 11, 26, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(4729),
                            UserId = 1,
                            WorkflowId = 3
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.AssignmentEntity", b =>
                {
                    b.HasBaseType("itu.DAL.Entities.TaskEntity");

                    b.Property<string>("Benefit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<double>("PriceGues")
                        .HasColumnType("float");

                    b.ToTable("Assignments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            DelayReason = "Testovací důvod vrácení",
                            End = new DateTime(2021, 12, 1, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(1237),
                            Note = "Testovaci předvyplněný úkol obsahující i poznámku.",
                            Order = 1,
                            Priority = 3,
                            Start = new DateTime(2021, 11, 25, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(3005),
                            UserId = 1,
                            WorkflowId = 1,
                            Benefit = "Testovací předvyplněný úkol obsahující i přínos organizaci.",
                            Currency = 1,
                            PriceGues = 4368.1999999999998
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.ContractEntity", b =>
                {
                    b.HasBaseType("itu.DAL.Entities.TaskEntity");

                    b.Property<int>("ContractType")
                        .HasColumnType("int");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<double>("FinalPrice")
                        .HasColumnType("float");

                    b.Property<string>("PriceChangeReason")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Contracts");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Active = true,
                            End = new DateTime(2021, 12, 2, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(5213),
                            Order = 0,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 24, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(5219),
                            UserId = 1,
                            WorkflowId = 5,
                            ContractType = 0,
                            Currency = 0,
                            FinalPrice = 0.0
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.EstimateEntity", b =>
                {
                    b.HasBaseType("itu.DAL.Entities.TaskEntity");

                    b.Property<int>("Currency")
                        .HasColumnType("int");

                    b.Property<double>("EstimatePrice")
                        .HasColumnType("float");

                    b.Property<double>("MaxPrice")
                        .HasColumnType("float");

                    b.ToTable("Estimates");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Active = true,
                            End = new DateTime(2021, 12, 2, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(4971),
                            Order = 0,
                            Priority = 0,
                            Start = new DateTime(2021, 11, 19, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(4978),
                            UserId = 1,
                            WorkflowId = 4,
                            Currency = 0,
                            EstimatePrice = 0.0,
                            MaxPrice = 0.0
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.PublishEntity", b =>
                {
                    b.HasBaseType("itu.DAL.Entities.TaskEntity");

                    b.Property<DateTime>("PublishEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublishStart")
                        .HasColumnType("datetime2");

                    b.ToTable("Publishes");

                    b.HasData(
                        new
                        {
                            Id = 6,
                            Active = true,
                            End = new DateTime(2021, 11, 26, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(5464),
                            Order = 0,
                            Priority = 3,
                            Start = new DateTime(2021, 11, 27, 13, 24, 23, 135, DateTimeKind.Local).AddTicks(5471),
                            UserId = 1,
                            WorkflowId = 6,
                            PublishEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishStart = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("itu.DAL.Entities.AgendaEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.UserEntity", "Administrator")
                        .WithMany("Agendas")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("itu.DAL.Entities.AgendaModelEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.AgendaEntity", "Agenda")
                        .WithMany("AgendaModels")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itu.DAL.Entities.ModelWorkflowEntity", "Model")
                        .WithMany("AgendaModels")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agenda");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("itu.DAL.Entities.AgendaRoleEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.AgendaEntity", "Agenda")
                        .WithMany("AgendaRoles")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itu.DAL.Entities.UserEntity", "User")
                        .WithMany("AgendaRoles")
                        .HasForeignKey("UserId");

                    b.Navigation("Agenda");

                    b.Navigation("User");
                });

            modelBuilder.Entity("itu.DAL.Entities.FileEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.FileDataEntity", "FileData")
                        .WithOne("File")
                        .HasForeignKey("itu.DAL.Entities.FileEntity", "FileDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itu.DAL.Entities.WorkflowEntity", "Workflow")
                        .WithMany("Files")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileData");

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("itu.DAL.Entities.ModelWorkflowTaskEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.ModelTaskEntity", "ModelTask")
                        .WithMany("WorkflowTasks")
                        .HasForeignKey("ModelTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itu.DAL.Entities.ModelWorkflowEntity", "ModelWorkflow")
                        .WithMany("WorkflowTasks")
                        .HasForeignKey("ModelWorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModelTask");

                    b.Navigation("ModelWorkflow");
                });

            modelBuilder.Entity("itu.DAL.Entities.NoteEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.WorkflowEntity", "Workflow")
                        .WithMany("Notes")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("itu.DAL.Entities.TaskEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.UserEntity", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itu.DAL.Entities.WorkflowEntity", "Workflow")
                        .WithMany("Tasks")
                        .HasForeignKey("WorkflowId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Workflow");
                });

            modelBuilder.Entity("itu.DAL.Entities.WorkflowEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.AgendaEntity", "Agenda")
                        .WithMany("Workflows")
                        .HasForeignKey("AgendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("itu.DAL.Entities.ModelWorkflowEntity", "ModelWorkflow")
                        .WithMany("Worflows")
                        .HasForeignKey("ModelWorkflowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agenda");

                    b.Navigation("ModelWorkflow");
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.AcceptationEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.TaskEntity", null)
                        .WithOne()
                        .HasForeignKey("itu.DAL.Entities.Tasks.AcceptationEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.ArchivationEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.TaskEntity", null)
                        .WithOne()
                        .HasForeignKey("itu.DAL.Entities.Tasks.ArchivationEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.AssessmentEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.TaskEntity", null)
                        .WithOne()
                        .HasForeignKey("itu.DAL.Entities.Tasks.AssessmentEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.AssignmentEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.TaskEntity", null)
                        .WithOne()
                        .HasForeignKey("itu.DAL.Entities.Tasks.AssignmentEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.ContractEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.TaskEntity", null)
                        .WithOne()
                        .HasForeignKey("itu.DAL.Entities.Tasks.ContractEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.EstimateEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.TaskEntity", null)
                        .WithOne()
                        .HasForeignKey("itu.DAL.Entities.Tasks.EstimateEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("itu.DAL.Entities.Tasks.PublishEntity", b =>
                {
                    b.HasOne("itu.DAL.Entities.TaskEntity", null)
                        .WithOne()
                        .HasForeignKey("itu.DAL.Entities.Tasks.PublishEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("itu.DAL.Entities.AgendaEntity", b =>
                {
                    b.Navigation("AgendaModels");

                    b.Navigation("AgendaRoles");

                    b.Navigation("Workflows");
                });

            modelBuilder.Entity("itu.DAL.Entities.FileDataEntity", b =>
                {
                    b.Navigation("File");
                });

            modelBuilder.Entity("itu.DAL.Entities.ModelTaskEntity", b =>
                {
                    b.Navigation("WorkflowTasks");
                });

            modelBuilder.Entity("itu.DAL.Entities.ModelWorkflowEntity", b =>
                {
                    b.Navigation("AgendaModels");

                    b.Navigation("Worflows");

                    b.Navigation("WorkflowTasks");
                });

            modelBuilder.Entity("itu.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("AgendaRoles");

                    b.Navigation("Agendas");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("itu.DAL.Entities.WorkflowEntity", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Notes");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
