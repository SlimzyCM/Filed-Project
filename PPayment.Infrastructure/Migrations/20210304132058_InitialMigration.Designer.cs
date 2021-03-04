﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PPayment.Infrastructure.Data;

namespace PPayment.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210304132058_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("PPayment.Domain.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardHolder")
                        .HasColumnType("TEXT");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentStateId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("TEXT")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.HasIndex("PaymentStateId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("PPayment.Domain.Entities.PaymentState", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PaymentState");
                });

            modelBuilder.Entity("PPayment.Domain.Entities.Payment", b =>
                {
                    b.HasOne("PPayment.Domain.Entities.PaymentState", "PaymentState")
                        .WithMany()
                        .HasForeignKey("PaymentStateId");

                    b.Navigation("PaymentState");
                });
#pragma warning restore 612, 618
        }
    }
}
