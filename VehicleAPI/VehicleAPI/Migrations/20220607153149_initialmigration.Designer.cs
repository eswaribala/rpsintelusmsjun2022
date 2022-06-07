﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleAPI.Contexts;

#nullable disable

namespace VehicleAPI.Migrations
{
    [DbContext(typeof(InsuranceContext))]
    [Migration("20220607153149_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VehicleAPI.Models.Vehicle", b =>
                {
                    b.Property<long>("EngineNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Engine_No");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EngineNo"), 1L, 1);

                    b.Property<string>("ChassisNo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Chassis_No");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Color");

                    b.Property<DateTime>("DOR")
                        .HasColumnType("datetime2")
                        .HasColumnName("DOR");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)")
                        .HasColumnName("Fuel_Type");

                    b.Property<string>("RegistrationNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Registration_No");

                    b.HasKey("EngineNo");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("VehicleAPI.Models.Vehicle", b =>
                {
                    b.OwnsOne("VehicleAPI.Models.Maker", "Maker", b1 =>
                        {
                            b1.Property<long>("VehicleEngineNo")
                                .HasColumnType("bigint");

                            b1.Property<string>("BrandName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Brand_Name");

                            b1.Property<string>("ModelNo")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Model_No");

                            b1.HasKey("VehicleEngineNo");

                            b1.ToTable("Vehicle");

                            b1.WithOwner()
                                .HasForeignKey("VehicleEngineNo");
                        });

                    b.Navigation("Maker");
                });
#pragma warning restore 612, 618
        }
    }
}
