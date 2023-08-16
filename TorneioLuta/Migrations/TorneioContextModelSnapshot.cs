﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TorneioLuta;

#nullable disable

namespace TorneioLuta.Migrations
{
    [DbContext(typeof(TorneioContext))]
    partial class TorneioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TorneioLuta.Models.Lutador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Derrotas")
                        .HasColumnType("int");

                    b.Property<string>("EstilosDeLutaList")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ParticipaDoTorneio")
                        .HasColumnType("bit");

                    b.Property<int?>("QtdEstilosDominados")
                        .HasColumnType("int");

                    b.Property<int?>("QtdLutas")
                        .HasColumnType("int");

                    b.Property<int?>("QtdTorneiosGanhos")
                        .HasColumnType("int");

                    b.Property<int?>("Vitorias")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lutadores");
                });
#pragma warning restore 612, 618
        }
    }
}