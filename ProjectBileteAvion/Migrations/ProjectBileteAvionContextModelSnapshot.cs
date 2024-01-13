﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectBileteAvion.Data;

#nullable disable

namespace ProjectBileteAvion.Migrations
{
    [DbContext(typeof(ProjectBileteAvionContext))]
    partial class ProjectBileteAvionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectASPNet.Model.Bilet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Clasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasagerID")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ZborID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PasagerID");

                    b.HasIndex("ZborID");

                    b.ToTable("Bilet");
                });

            modelBuilder.Entity("ProjectASPNet.Model.Destinatie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Aeroport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tara")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Destinatie");
                });

            modelBuilder.Entity("ProjectASPNet.Model.Pasager", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumarDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pasager");
                });

            modelBuilder.Entity("ProjectASPNet.Model.Zbor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DataOraPlecare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataOraSosire")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinatieID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DestinatieID");

                    b.ToTable("Zbor");
                });

            modelBuilder.Entity("ProjectASPNet.Model.Bilet", b =>
                {
                    b.HasOne("ProjectASPNet.Model.Pasager", "Pasager")
                        .WithMany("Bilete")
                        .HasForeignKey("PasagerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectASPNet.Model.Zbor", "Zbor")
                        .WithMany("Bilete")
                        .HasForeignKey("ZborID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pasager");

                    b.Navigation("Zbor");
                });

            modelBuilder.Entity("ProjectASPNet.Model.Zbor", b =>
                {
                    b.HasOne("ProjectASPNet.Model.Destinatie", "Destinatie")
                        .WithMany("Zboruri")
                        .HasForeignKey("DestinatieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destinatie");
                });

            modelBuilder.Entity("ProjectASPNet.Model.Destinatie", b =>
                {
                    b.Navigation("Zboruri");
                });

            modelBuilder.Entity("ProjectASPNet.Model.Pasager", b =>
                {
                    b.Navigation("Bilete");
                });

            modelBuilder.Entity("ProjectASPNet.Model.Zbor", b =>
                {
                    b.Navigation("Bilete");
                });
#pragma warning restore 612, 618
        }
    }
}
