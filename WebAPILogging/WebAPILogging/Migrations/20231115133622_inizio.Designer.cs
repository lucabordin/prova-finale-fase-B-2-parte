﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebAPIProvaProgettoFinale.DataSource;

#nullable disable

namespace WebAPILogging.Migrations
{
    [DbContext(typeof(LoggingDBContext))]
    [Migration("20231115133622_inizio")]
    partial class inizio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAPILogging.Entities.Logs", b =>
                {
                    b.Property<int>("idLog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idLog"));

                    b.Property<string>("EndpointUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Messaggio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("idLog");

                    b.ToTable("Logs");
                });
#pragma warning restore 612, 618
        }
    }
}
