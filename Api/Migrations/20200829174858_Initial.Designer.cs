﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservatio.Data;

namespace Reservatio.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200829174858_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Reservatio.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(8) CHARACTER SET utf8mb4")
                        .HasMaxLength(8);

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(400) CHARACTER SET utf8mb4")
                        .HasMaxLength(400);

                    b.Property<string>("District")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<ushort?>("Number")
                        .HasColumnType("smallint unsigned");

                    b.Property<long?>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<long>("StateId")
                        .HasColumnType("bigint");

                    b.Property<string>("Street")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PersonId");

                    b.HasIndex("StateId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Reservatio.Models.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("Code")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ExclusionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StateAbbreviation")
                        .IsRequired()
                        .HasColumnType("char(2) CHARACTER SET utf8mb4")
                        .IsFixedLength(true)
                        .HasMaxLength(2);

                    b.Property<long>("StateId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("StateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Reservatio.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ExclusionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("PaymentMethodId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PlaceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("PaymentMethodId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Reservatio.Models.NaturalPerson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CancellationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11) CHARACTER SET utf8mb4")
                        .HasMaxLength(11);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Rg")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SecondaryPhone")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("NaturalPerson");
                });

            modelBuilder.Entity("Reservatio.Models.NaturalPersonEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CancellationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("EventId")
                        .HasColumnType("bigint");

                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("PersonId");

                    b.ToTable("NaturalPersonEvent");
                });

            modelBuilder.Entity("Reservatio.Models.PaymentMethod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<float>("Change")
                        .HasColumnType("float");

                    b.Property<double?>("Discount")
                        .HasColumnType("double");

                    b.Property<DateTime?>("ExclusionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<ushort>("NumberInstallments")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint unsigned")
                        .HasDefaultValue((ushort)1);

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("TotalValue")
                        .HasColumnType("float");

                    b.Property<float>("ValueReceived")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethod");
                });

            modelBuilder.Entity("Reservatio.Models.State", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("ExclusionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StateAbbreviation")
                        .IsRequired()
                        .HasColumnType("char(2) CHARACTER SET utf8mb4")
                        .IsFixedLength(true)
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("StateAbbreviation")
                        .IsUnique();

                    b.ToTable("State");
                });

            modelBuilder.Entity("Reservatio.Models.Address", b =>
                {
                    b.HasOne("Reservatio.Models.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservatio.Models.NaturalPerson", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId");

                    b.HasOne("Reservatio.Models.State", "State")
                        .WithMany("Addresses")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservatio.Models.City", b =>
                {
                    b.HasOne("Reservatio.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservatio.Models.Event", b =>
                {
                    b.HasOne("Reservatio.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Events")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservatio.Models.Address", "Place")
                        .WithMany("Events")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("Reservatio.Models.NaturalPersonEvent", b =>
                {
                    b.HasOne("Reservatio.Models.Event", "Event")
                        .WithMany("NaturalPersonEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservatio.Models.NaturalPerson", "Person")
                        .WithMany("NaturalPersonEvents")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
