﻿// <auto-generated />
using Elsa.Connections.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Elsa.Connections.Persistence.EFCore.Sqlite.Migrations
{
    [DbContext(typeof(ConnectionDbContext))]
    partial class ConnectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Elsa")
                .HasAnnotation("ProductVersion", "8.0.12");

            modelBuilder.Entity("Elsa.Connections.Persistence.Entities.ConnectionDefinition", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConnectionConfiguration")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConnectionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_ConnectionDefinition_Name");

                    b.HasIndex("TenantId")
                        .HasDatabaseName("IX_ConnectionDefinition_TenantId");

                    b.ToTable("ConnectionDefinitions", "Elsa");
                });
#pragma warning restore 612, 618
        }
    }
}
