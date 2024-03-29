﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using The_Archivist.Models;

#nullable disable

namespace The_Archivist.Migrations
{
    [DbContext(typeof(ArchivistDBContext))]
    [Migration("20220307055804_fixOrgs")]
    partial class fixOrgs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArchiveEmployee", b =>
                {
                    b.Property<int>("archivesId")
                        .HasColumnType("int");

                    b.Property<int>("employeesId")
                        .HasColumnType("int");

                    b.HasKey("archivesId", "employeesId");

                    b.HasIndex("employeesId");

                    b.ToTable("ArchiveEmployee", "dbo");
                });

            modelBuilder.Entity("The_Archivist.Models.Archive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("addDateTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("archiveTypeId")
                        .HasColumnType("int");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("fileSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("publishDateTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("archiveTypeId");

                    b.HasIndex("clientId");

                    b.HasIndex("departmentId");

                    b.ToTable("Archives", "dbo");
                });

            modelBuilder.Entity("The_Archivist.Models.ArchiveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("typeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArchiveTypes", "dbo");
                });

            modelBuilder.Entity("The_Archivist.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("clientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients", "dbo");
                });

            modelBuilder.Entity("The_Archivist.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("depName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("orgnizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("orgnizationId");

                    b.ToTable("Departments", "dbo");
                });

            modelBuilder.Entity("The_Archivist.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("departmentId")
                        .HasColumnType("int");

                    b.Property<string>("empFName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("empLName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("orgnizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("departmentId");

                    b.HasIndex("orgnizationId");

                    b.ToTable("Employees", "dbo");
                });

            modelBuilder.Entity("The_Archivist.Models.Orgnization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("imageSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("orgName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("orgTypesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("orgTypesId");

                    b.ToTable("Orgnizations", "dbo");
                });

            modelBuilder.Entity("The_Archivist.Models.OrgType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("typeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrgTypes", "dbo");
                });

            modelBuilder.Entity("ArchiveEmployee", b =>
                {
                    b.HasOne("The_Archivist.Models.Archive", null)
                        .WithMany()
                        .HasForeignKey("archivesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("The_Archivist.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("employeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("The_Archivist.Models.Archive", b =>
                {
                    b.HasOne("The_Archivist.Models.ArchiveType", "archiveType")
                        .WithMany("archives")
                        .HasForeignKey("archiveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("The_Archivist.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("The_Archivist.Models.Department", "department")
                        .WithMany("archives")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("archiveType");

                    b.Navigation("client");

                    b.Navigation("department");
                });

            modelBuilder.Entity("The_Archivist.Models.Department", b =>
                {
                    b.HasOne("The_Archivist.Models.Orgnization", "orgnization")
                        .WithMany("departments")
                        .HasForeignKey("orgnizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("orgnization");
                });

            modelBuilder.Entity("The_Archivist.Models.Employee", b =>
                {
                    b.HasOne("The_Archivist.Models.Department", "department")
                        .WithMany("employees")
                        .HasForeignKey("departmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("The_Archivist.Models.Orgnization", "orgnization")
                        .WithMany("employees")
                        .HasForeignKey("orgnizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");

                    b.Navigation("orgnization");
                });

            modelBuilder.Entity("The_Archivist.Models.Orgnization", b =>
                {
                    b.HasOne("The_Archivist.Models.OrgType", "orgTypes")
                        .WithMany("orgnizations")
                        .HasForeignKey("orgTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("orgTypes");
                });

            modelBuilder.Entity("The_Archivist.Models.ArchiveType", b =>
                {
                    b.Navigation("archives");
                });

            modelBuilder.Entity("The_Archivist.Models.Department", b =>
                {
                    b.Navigation("archives");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("The_Archivist.Models.Orgnization", b =>
                {
                    b.Navigation("departments");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("The_Archivist.Models.OrgType", b =>
                {
                    b.Navigation("orgnizations");
                });
#pragma warning restore 612, 618
        }
    }
}
