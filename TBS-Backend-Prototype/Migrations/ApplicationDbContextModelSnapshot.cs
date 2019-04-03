﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TBS_Backend_Prototype.Models;

namespace TBS_Backend_Prototype.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TBS_Backend_Prototype.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Province");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetNumber");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("TBS_Backend_Prototype.Models.Dealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("CompanyName");

                    b.Property<string>("ContactFirstName");

                    b.Property<string>("ContactLasttName");

                    b.Property<string>("Email");

                    b.Property<string>("PaymentEmail");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("TBS_Backend_Prototype.Models.Move", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BiddingComplete");

                    b.Property<bool>("DealerAcceptedComplete");

                    b.Property<int>("DealerId");

                    b.Property<DateTime>("DropOffDate");

                    b.Property<DateTime>("PickUpDate");

                    b.Property<bool>("TransportComplete");

                    b.Property<string>("UserCompanyName")
                        .IsRequired();

                    b.Property<int>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("DealerId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("TBS_Backend_Prototype.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<string>("Year");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("TBS_Backend_Prototype.Models.Dealer", b =>
                {
                    b.HasOne("TBS_Backend_Prototype.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("TBS_Backend_Prototype.Models.Move", b =>
                {
                    b.HasOne("TBS_Backend_Prototype.Models.Dealer", "Dealer")
                        .WithMany()
                        .HasForeignKey("DealerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TBS_Backend_Prototype.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
