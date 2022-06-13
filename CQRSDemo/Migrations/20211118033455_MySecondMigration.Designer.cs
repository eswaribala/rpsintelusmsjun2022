﻿// <auto-generated />
using CQRSDemo.Models.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CQRSDemo.Migrations
{
    [DbContext(typeof(CustomerSQLiteDatabaseContext))]
    [Migration("20211118033455_MySecondMigration")]
    partial class MySecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CQRSDemo.Models.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<long>("MobileNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CQRSDemo.Models.Invoice", b =>
                {
                    b.Property<long>("InvoiceNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DOI")
                        .HasColumnType("TEXT");

                    b.HasKey("InvoiceNo");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("CQRSDemo.Models.Invoice", b =>
                {
                    b.HasOne("CQRSDemo.Models.Customer", "Customer")
                        .WithMany("InvoiceList")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("CQRSDemo.Models.Customer", b =>
                {
                    b.Navigation("InvoiceList");
                });
#pragma warning restore 612, 618
        }
    }
}
