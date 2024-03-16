﻿// <auto-generated />
using System;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("SaleBatchId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SaleBatchId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Core.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<decimal>("LístedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.HasKey("ContractId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Core.Division", b =>
                {
                    b.Property<int>("DivisionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DivisionId"), 1L, 1);

                    b.Property<int?>("AgencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DivisionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DivisionStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("DivisionId");

                    b.HasIndex("AgencyId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("Core.PaymentRecord", b =>
                {
                    b.Property<int>("PaymentRecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentRecordId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentRecordId");

                    b.HasIndex("ContractId");

                    b.ToTable("PaymentRecords");
                });

            modelBuilder.Entity("Core.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingContractor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntroPageLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvestorId")
                        .HasColumnType("int");

                    b.Property<string>("JuridicalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Scale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId");

                    b.HasIndex("InvestorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Core.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"), 1L, 1);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Brief")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DivisionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSold")
                        .HasColumnType("bit");

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PropertyId");

                    b.HasIndex("DivisionId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Core.SaleBatch", b =>
                {
                    b.Property<int>("SaleBatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleBatchId"), 1L, 1);

                    b.Property<string>("BankAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BookingFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PremiumStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiverName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaleBatchName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SaleBatchId");

                    b.ToTable("SaleBatches");
                });

            modelBuilder.Entity("Core.SaleBatchDetail", b =>
                {
                    b.Property<int>("SaleBatchDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleBatchDetailId"), 1L, 1);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int>("SaleBatchId")
                        .HasColumnType("int");

                    b.HasKey("SaleBatchDetailId");

                    b.HasIndex("PropertyId");

                    b.HasIndex("SaleBatchId");

                    b.ToTable("SaleBatchDetails");
                });

            modelBuilder.Entity("Core.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Role").HasValue("User");
                });

            modelBuilder.Entity("Core.Agency", b =>
                {
                    b.HasBaseType("Core.User");

                    b.HasDiscriminator().HasValue("Agency");
                });

            modelBuilder.Entity("Core.Customer", b =>
                {
                    b.HasBaseType("Core.User");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("Core.Investor", b =>
                {
                    b.HasBaseType("Core.User");

                    b.HasDiscriminator().HasValue("Investor");
                });

            modelBuilder.Entity("Core.Booking", b =>
                {
                    b.HasOne("Core.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.SaleBatch", "SaleBatch")
                        .WithMany("Bookings")
                        .HasForeignKey("SaleBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("SaleBatch");
                });

            modelBuilder.Entity("Core.Contract", b =>
                {
                    b.HasOne("Core.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Property", "Property")
                        .WithMany()
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Core.Division", b =>
                {
                    b.HasOne("Core.Agency", null)
                        .WithMany("Divisions")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("Core.Project", null)
                        .WithMany("Divisions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.PaymentRecord", b =>
                {
                    b.HasOne("Core.Contract", "Contract")
                        .WithMany("PaymentRecords")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Core.Project", b =>
                {
                    b.HasOne("Core.Investor", "Investor")
                        .WithMany("Projects")
                        .HasForeignKey("InvestorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Investor");
                });

            modelBuilder.Entity("Core.Property", b =>
                {
                    b.HasOne("Core.Division", null)
                        .WithMany("Properties")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.SaleBatchDetail", b =>
                {
                    b.HasOne("Core.Property", "Property")
                        .WithMany("SaleBatchDetails")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.SaleBatch", "SaleBatch")
                        .WithMany("SaleBatchDetails")
                        .HasForeignKey("SaleBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("SaleBatch");
                });

            modelBuilder.Entity("Core.Contract", b =>
                {
                    b.Navigation("PaymentRecords");
                });

            modelBuilder.Entity("Core.Division", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("Core.Project", b =>
                {
                    b.Navigation("Divisions");
                });

            modelBuilder.Entity("Core.Property", b =>
                {
                    b.Navigation("SaleBatchDetails");
                });

            modelBuilder.Entity("Core.SaleBatch", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("SaleBatchDetails");
                });

            modelBuilder.Entity("Core.Agency", b =>
                {
                    b.Navigation("Divisions");
                });

            modelBuilder.Entity("Core.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Core.Investor", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
