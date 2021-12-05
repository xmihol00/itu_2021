// vygenerovano

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
    [Migration("20211205110811_init")]
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
                            Creation = new DateTime(2021, 11, 5, 12, 8, 11, 173, DateTimeKind.Local).AddTicks(1072),
                            Description = "Agenda správující jednoduchuché nákupy bez vúběrových řízení",
                            Name = "Nákupy"
                        },
                        new
                        {
                            Id = 2,
                            AdministratorId = 2,
                            Creation = new DateTime(2021, 11, 30, 12, 8, 11, 174, DateTimeKind.Local).AddTicks(2576),
                            Description = "Agenda spravující menší a střední zakázky",
                            Name = "Malé a střední zakázky"
                        },
                        new
                        {
                            Id = 3,
                            AdministratorId = 1,
                            Creation = new DateTime(2021, 10, 6, 12, 8, 11, 174, DateTimeKind.Local).AddTicks(2598),
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
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            AgendaId = 3,
                            Type = 2,
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            AgendaId = 3,
                            Type = 3,
                            UserId = 3
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
                            UserId = 3
                        },
                        new
                        {
                            Id = 21,
                            AgendaId = 1,
                            Type = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 19,
                            AgendaId = 1,
                            Type = 0,
                            UserId = 5
                        },
                        new
                        {
                            Id = 24,
                            AgendaId = 1,
                            Type = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 20,
                            AgendaId = 1,
                            Type = 3,
                            UserId = 1
                        },
                        new
                        {
                            Id = 22,
                            AgendaId = 1,
                            Type = 4,
                            UserId = 1
                        },
                        new
                        {
                            Id = 23,
                            AgendaId = 1,
                            Type = 6
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
                            UserId = 1
                        },
                        new
                        {
                            Id = 15,
                            AgendaId = 2,
                            Type = 4,
                            UserId = 3
                        },
                        new
                        {
                            Id = 16,
                            AgendaId = 2,
                            Type = 4,
                            UserId = 1
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
                            UserId = 1
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
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 2,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 3,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 4,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 5,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 6,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 7,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 8,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 9,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 10,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 11,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 12,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 13,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 14,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 15,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 16,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 17,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 18,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 19,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 20,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 21,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 22,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 23,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 24,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 25,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 26,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 27,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 28,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 29,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 30,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
                        },
                        new
                        {
                            Id = 31,
                            Data = new byte[] { 100, 117, 109, 109, 121, 10 }
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
                            Version = 2,
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
                            WorkflowId = 1
                        },
                        new
                        {
                            Id = 4,
                            FileDataId = 4,
                            MIME = "text/plain",
                            Name = "soubor2.txt",
                            Number = "ID_11",
                            Type = 2,
                            Version = 3,
                            WorkflowId = 1
                        },
                        new
                        {
                            Id = 5,
                            FileDataId = 5,
                            MIME = "text/plain",
                            Name = "soubor2.txt",
                            Number = "ID_11",
                            Type = 2,
                            Version = 3,
                            WorkflowId = 1
                        },
                        new
                        {
                            Id = 6,
                            FileDataId = 6,
                            MIME = "text/plain",
                            Name = "vyhodnoceni.txt",
                            Number = "ID_889",
                            Type = 0,
                            Version = 1,
                            WorkflowId = 2
                        },
                        new
                        {
                            Id = 7,
                            FileDataId = 7,
                            MIME = "text/plain",
                            Name = "vypracovani prijeti.txt",
                            Number = "ID_890",
                            Type = 2,
                            Version = 1,
                            WorkflowId = 2
                        },
                        new
                        {
                            Id = 8,
                            FileDataId = 8,
                            MIME = "text/plain",
                            Name = "odhad ceny.txt",
                            Number = "ID_866",
                            Type = 3,
                            Version = 1,
                            WorkflowId = 2
                        },
                        new
                        {
                            Id = 9,
                            FileDataId = 9,
                            MIME = "text/plain",
                            Name = "odhad ceny.txt",
                            Number = "ID_866",
                            Type = 3,
                            Version = 2,
                            WorkflowId = 2
                        },
                        new
                        {
                            Id = 10,
                            FileDataId = 10,
                            MIME = "text/plain",
                            Name = "potreba.txt",
                            Number = "ID_12",
                            Type = 0,
                            Version = 1,
                            WorkflowId = 4
                        },
                        new
                        {
                            Id = 11,
                            FileDataId = 11,
                            MIME = "text/plain",
                            Name = "schvaleni.txt",
                            Number = "ID_13",
                            Type = 2,
                            Version = 1,
                            WorkflowId = 4
                        },
                        new
                        {
                            Id = 12,
                            FileDataId = 12,
                            MIME = "text/plain",
                            Name = "zadani.txt",
                            Number = "ID_18",
                            Type = 0,
                            Version = 1,
                            WorkflowId = 5
                        },
                        new
                        {
                            Id = 13,
                            FileDataId = 13,
                            MIME = "text/plain",
                            Name = "zadani.txt",
                            Number = "ID_18",
                            Type = 0,
                            Version = 2,
                            WorkflowId = 5
                        },
                        new
                        {
                            Id = 14,
                            FileDataId = 14,
                            MIME = "text/plain",
                            Name = "zadani.txt",
                            Number = "ID_18",
                            Type = 0,
                            Version = 3,
                            WorkflowId = 5
                        },
                        new
                        {
                            Id = 15,
                            FileDataId = 15,
                            MIME = "text/plain",
                            Name = "schvaleni.txt",
                            Number = "ID_19",
                            Type = 2,
                            Version = 1,
                            WorkflowId = 5
                        },
                        new
                        {
                            Id = 16,
                            FileDataId = 16,
                            MIME = "text/plain",
                            Name = "schvaleni.txt",
                            Number = "ID_19",
                            Type = 2,
                            Version = 2,
                            WorkflowId = 5
                        },
                        new
                        {
                            Id = 27,
                            FileDataId = 27,
                            MIME = "text/plain",
                            Name = "smlouva.txt",
                            Number = "ID_20",
                            Type = 5,
                            Version = 1,
                            WorkflowId = 5
                        },
                        new
                        {
                            Id = 17,
                            FileDataId = 17,
                            MIME = "text/plain",
                            Name = "abcd.txt",
                            Number = "ID_189",
                            Type = 0,
                            Version = 1,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 18,
                            FileDataId = 18,
                            MIME = "text/plain",
                            Name = "efgh.txt",
                            Number = "ID_191",
                            Type = 2,
                            Version = 1,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 19,
                            FileDataId = 19,
                            MIME = "text/plain",
                            Name = "ijkl.txt",
                            Number = "ID_193",
                            Type = 5,
                            Version = 1,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 26,
                            FileDataId = 26,
                            MIME = "text/plain",
                            Name = "nopl.txt",
                            Number = "ID_194",
                            Type = 3,
                            Version = 1,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 20,
                            FileDataId = 20,
                            MIME = "text/plain",
                            Name = ":D.txt",
                            Number = "EDDDQ",
                            Type = 0,
                            Version = 2,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 21,
                            FileDataId = 21,
                            MIME = "text/plain",
                            Name = ":).txt",
                            Number = "EAAAQ",
                            Type = 2,
                            Version = 2,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 22,
                            FileDataId = 22,
                            MIME = "text/plain",
                            Name = ":-).txt",
                            Number = "EEEEQ",
                            Type = 5,
                            Version = 2,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 23,
                            FileDataId = 23,
                            MIME = "text/plain",
                            Name = ";).txt",
                            Number = "EEEEQ",
                            Type = 5,
                            Version = 3,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 24,
                            FileDataId = 24,
                            MIME = "text/plain",
                            Name = ":0.txt",
                            Number = "AEQQQ",
                            Type = 3,
                            Version = 2,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 25,
                            FileDataId = 25,
                            MIME = "text/plain",
                            Name = ":].txt",
                            Number = "VVQQQ",
                            Type = 4,
                            Version = 1,
                            WorkflowId = 6
                        },
                        new
                        {
                            Id = 28,
                            FileDataId = 28,
                            MIME = "text/plain",
                            Name = "fakt to potrebujeme.txt",
                            Number = "2434",
                            Type = 0,
                            Version = 1,
                            WorkflowId = 7
                        },
                        new
                        {
                            Id = 29,
                            FileDataId = 29,
                            MIME = "text/plain",
                            Name = "ale opravdu to potrebujeme.txt",
                            Number = "2434",
                            Type = 0,
                            Version = 2,
                            WorkflowId = 7
                        },
                        new
                        {
                            Id = 30,
                            FileDataId = 30,
                            MIME = "text/plain",
                            Name = "tak si to kupte.txt",
                            Number = "2435",
                            Type = 2,
                            Version = 1,
                            WorkflowId = 7
                        },
                        new
                        {
                            Id = 31,
                            FileDataId = 31,
                            MIME = "text/plain",
                            Name = "hulky!!.txt",
                            Number = "2435",
                            Type = 0,
                            Version = 1,
                            WorkflowId = 8
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

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

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
                            Name = "Stavba depa",
                            State = 0
                        },
                        new
                        {
                            Id = 2,
                            AgendaId = 1,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam rhoncus aliquam metus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 2,
                            Name = "Nákup dárků na Vánoce",
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
                            Name = "Nová kopírka",
                            State = 0
                        },
                        new
                        {
                            Id = 4,
                            AgendaId = 1,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut, suscipit at, pharetra vitae, orci.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 6,
                            Name = "Nákup zahradních strojů",
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
                            Name = "Úklid prostor budovy",
                            State = 0
                        },
                        new
                        {
                            Id = 6,
                            AgendaId = 2,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Per inceptos hymenaeos. Sed vel lectus. Donec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 4,
                            Name = "Návrh vzhledu nové stanice",
                            State = 0
                        },
                        new
                        {
                            Id = 7,
                            AgendaId = 1,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Dnec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 1,
                            Name = "Nákup dronů",
                            State = 2
                        },
                        new
                        {
                            Id = 8,
                            AgendaId = 1,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Dnec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 2,
                            Name = "Nákup kouzelnických hůlek",
                            State = 3
                        },
                        new
                        {
                            Id = 9,
                            AgendaId = 3,
                            Creation = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Dnec odio tempus molestie, porttitor ut, iaculis quis, sem. Donec quis nibh at felis congue commodo. Nam quis nulla. Phasellus enim erat, vestibulum vel, aliquam a, posuere eu, velit. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer pellentesque quam vel velit. In sem justo, commodo ut.",
                            ExpectedEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModelWorkflowId = 5,
                            Name = "Výstavba silnice",
                            State = 1
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
                            Active = false,
                            DelayReason = "dovolená",
                            End = new DateTime(2021, 11, 22, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(1305),
                            Note = "Přijato bez výhrad",
                            Order = 2,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 19, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(2763),
                            UserId = 2,
                            WorkflowId = 1,
                            Accepted = true,
                            Benefit = "Testovací předvyplněný úkol obsahující i přínos organizaci.",
                            Currency = 1,
                            PriceGues = 7369821.0,
                            Reason = "Pěkně vypracováno"
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            End = new DateTime(2021, 12, 10, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4473),
                            Order = 2,
                            Priority = 0,
                            Start = new DateTime(2021, 11, 30, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4475),
                            UserId = 2,
                            WorkflowId = 2,
                            Accepted = false,
                            Currency = 0,
                            PriceGues = 0.0
                        },
                        new
                        {
                            Id = 10,
                            Active = false,
                            End = new DateTime(2021, 12, 3, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4573),
                            Order = 2,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 30, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4574),
                            UserId = 3,
                            WorkflowId = 4,
                            Accepted = true,
                            Benefit = "Místo 8 zahradnílů nám budou stačit 4.",
                            Currency = 2,
                            PriceGues = 3335.4099999999999,
                            Reason = "Ano, to by se mělo vyplatit.."
                        },
                        new
                        {
                            Id = 13,
                            Active = false,
                            End = new DateTime(2021, 11, 22, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4586),
                            Note = "Cena je měsíčně.",
                            Order = 2,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 17, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4587),
                            UserId = 1,
                            WorkflowId = 5,
                            Accepted = true,
                            Benefit = "Nebudeme muset zaměstnancum platit přesčasy za úklid.",
                            Currency = 0,
                            PriceGues = 23515.41,
                            Reason = "Snad se to vyplatí."
                        },
                        new
                        {
                            Id = 17,
                            Active = false,
                            End = new DateTime(2021, 11, 13, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5844),
                            Order = 2,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 6, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5846),
                            UserId = 1,
                            WorkflowId = 6,
                            Accepted = true,
                            Benefit = "Uvidíme i pohled z jiného úhlu.",
                            Currency = 0,
                            PriceGues = 245321.0,
                            Reason = "Ano, tuto investici je možné ospravedlnit."
                        },
                        new
                        {
                            Id = 23,
                            Active = false,
                            End = new DateTime(2021, 11, 15, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6688),
                            Order = 2,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 9, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6689),
                            UserId = 3,
                            WorkflowId = 7,
                            Accepted = true,
                            Benefit = "Potřebujeme drony pro střežení pozemku!",
                            Currency = 2,
                            PriceGues = 1450.0,
                            Reason = "To bude super!"
                        },
                        new
                        {
                            Id = 25,
                            Active = false,
                            End = new DateTime(2021, 11, 15, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6697),
                            Order = 2,
                            Priority = 0,
                            Start = new DateTime(2021, 11, 9, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6698),
                            UserId = 2,
                            WorkflowId = 8,
                            Accepted = false,
                            Benefit = "Musíme se naučit kouzlit.",
                            Currency = 1,
                            PriceGues = 8521.0,
                            Reason = "Kouzlit si můžete po pracovní době!"
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
                            Id = 21,
                            Active = true,
                            End = new DateTime(2021, 12, 21, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6674),
                            Order = 6,
                            Priority = 3,
                            Start = new DateTime(2021, 12, 3, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6679),
                            UserId = 1,
                            WorkflowId = 6,
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
                            Id = 4,
                            Active = false,
                            End = new DateTime(2021, 12, 2, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(3965),
                            Order = 4,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 28, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(3971),
                            UserId = 2,
                            WorkflowId = 1,
                            Conclusion = "Vše se zdá být v pořádku, cena odpovídá."
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
                            Active = false,
                            End = new DateTime(2021, 11, 19, 12, 8, 11, 176, DateTimeKind.Local).AddTicks(8957),
                            Note = "Testovaci předvyplněný úkol obsahující i poznámku.",
                            Order = 1,
                            Priority = 3,
                            Start = new DateTime(2021, 11, 15, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(313),
                            UserId = 1,
                            WorkflowId = 1,
                            Benefit = "Testovací předvyplněný úkol obsahující i přínos organizaci.",
                            Currency = 1,
                            PriceGues = 7369821.0
                        },
                        new
                        {
                            Id = 6,
                            Active = false,
                            End = new DateTime(2021, 11, 30, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4468),
                            Order = 1,
                            Priority = 3,
                            Start = new DateTime(2021, 11, 27, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4469),
                            UserId = 5,
                            WorkflowId = 2,
                            Benefit = "Všichni nás pak budou mít rádi :).",
                            Currency = 0,
                            PriceGues = 26320.0
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            End = new DateTime(2022, 1, 14, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4477),
                            Order = 1,
                            Priority = 2,
                            Start = new DateTime(2021, 12, 4, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4479),
                            UserId = 1,
                            WorkflowId = 3,
                            Currency = 0,
                            PriceGues = 0.0
                        },
                        new
                        {
                            Id = 9,
                            Active = false,
                            End = new DateTime(2021, 11, 30, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4565),
                            Order = 1,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 20, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4568),
                            UserId = 5,
                            WorkflowId = 4,
                            Benefit = "Místo 8 zahradnílů nám budou stačit 4.",
                            Currency = 2,
                            PriceGues = 3335.4099999999999
                        },
                        new
                        {
                            Id = 12,
                            Active = false,
                            End = new DateTime(2021, 11, 17, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4582),
                            Note = "Cena je měsíčně.",
                            Order = 1,
                            Priority = 1,
                            Start = new DateTime(2021, 11, 10, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4583),
                            UserId = 1,
                            WorkflowId = 5,
                            Benefit = "Nebudeme muset zaměstnancum platit přesčasy za úklid.",
                            Currency = 0,
                            PriceGues = 23515.41
                        },
                        new
                        {
                            Id = 16,
                            Active = false,
                            End = new DateTime(2021, 11, 6, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5840),
                            Order = 1,
                            Priority = 1,
                            Start = new DateTime(2021, 10, 26, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5841),
                            UserId = 1,
                            WorkflowId = 6,
                            Benefit = "Uvidíme i pohled z jiného úhlu.",
                            Currency = 0,
                            PriceGues = 245321.0
                        },
                        new
                        {
                            Id = 22,
                            Active = false,
                            End = new DateTime(2021, 11, 9, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6683),
                            Order = 1,
                            Priority = 0,
                            Start = new DateTime(2021, 11, 1, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6684),
                            UserId = 1,
                            WorkflowId = 7,
                            Benefit = "Potřebujeme drony pro střežení pozemku!",
                            Currency = 2,
                            PriceGues = 1450.0
                        },
                        new
                        {
                            Id = 24,
                            Active = false,
                            End = new DateTime(2021, 11, 9, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6693),
                            Order = 1,
                            Priority = 1,
                            Start = new DateTime(2021, 11, 3, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6694),
                            UserId = 1,
                            WorkflowId = 8,
                            Benefit = "Musíme se naučit kouzlit.",
                            Currency = 1,
                            PriceGues = 8521.0
                        },
                        new
                        {
                            Id = 26,
                            Active = true,
                            End = new DateTime(2021, 12, 15, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6701),
                            Order = 1,
                            Priority = 3,
                            Start = new DateTime(2021, 12, 4, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6702),
                            UserId = 1,
                            WorkflowId = 9,
                            Currency = 0,
                            PriceGues = 0.0
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
                            End = new DateTime(2021, 12, 20, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4447),
                            Order = 5,
                            Priority = 1,
                            Start = new DateTime(2021, 12, 2, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4452),
                            UserId = 1,
                            WorkflowId = 1,
                            ContractType = 0,
                            Currency = 0,
                            FinalPrice = 0.0
                        },
                        new
                        {
                            Id = 14,
                            Active = false,
                            End = new DateTime(2021, 12, 1, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4590),
                            Note = "Je to DPP.",
                            Order = 3,
                            Priority = 3,
                            Start = new DateTime(2021, 11, 22, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4592),
                            UserId = 3,
                            WorkflowId = 5,
                            ContractType = 4,
                            Currency = 0,
                            FinalPrice = 25600.0,
                            PriceChangeReason = "Je teď těžké sehnat uklízeče, nutno zvýčit odměnu."
                        },
                        new
                        {
                            Id = 19,
                            Active = false,
                            End = new DateTime(2021, 12, 1, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5860),
                            Order = 4,
                            Priority = 3,
                            Start = new DateTime(2021, 11, 22, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5861),
                            UserId = 3,
                            WorkflowId = 6,
                            ContractType = 2,
                            Currency = 0,
                            FinalPrice = 225000.0
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
                            Id = 3,
                            Active = false,
                            End = new DateTime(2021, 11, 28, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(3015),
                            Order = 3,
                            Priority = 0,
                            Start = new DateTime(2021, 11, 22, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(3021),
                            UserId = 3,
                            WorkflowId = 1,
                            Currency = 1,
                            EstimatePrice = 8632148.0,
                            MaxPrice = 10000000.0
                        },
                        new
                        {
                            Id = 11,
                            Active = true,
                            End = new DateTime(2021, 12, 31, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4578),
                            Order = 3,
                            Priority = 0,
                            Start = new DateTime(2021, 12, 3, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(4579),
                            UserId = 1,
                            WorkflowId = 4,
                            Currency = 0,
                            EstimatePrice = 0.0,
                            MaxPrice = 0.0
                        },
                        new
                        {
                            Id = 18,
                            Active = false,
                            End = new DateTime(2021, 11, 22, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5855),
                            Order = 3,
                            Priority = 2,
                            Start = new DateTime(2021, 11, 13, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5856),
                            UserId = 2,
                            WorkflowId = 6,
                            Currency = 0,
                            EstimatePrice = 225000.0,
                            MaxPrice = 275000.0
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
                            Id = 15,
                            Active = true,
                            End = new DateTime(2021, 12, 14, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5828),
                            Order = 4,
                            Priority = 1,
                            Start = new DateTime(2021, 12, 1, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5835),
                            UserId = 2,
                            WorkflowId = 5,
                            PublishEnd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublishStart = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 20,
                            Active = false,
                            End = new DateTime(2021, 12, 3, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5865),
                            Order = 5,
                            Priority = 1,
                            Start = new DateTime(2021, 12, 1, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5866),
                            UserId = 2,
                            WorkflowId = 6,
                            PublishEnd = new DateTime(2022, 1, 29, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(6168),
                            PublishStart = new DateTime(2021, 12, 30, 12, 8, 11, 177, DateTimeKind.Local).AddTicks(5868)
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
