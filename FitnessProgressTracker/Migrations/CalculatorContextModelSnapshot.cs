﻿// <auto-generated/>
using FitnessProgressTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitnessProgressTracker.Migrations
{
    [DbContext(typeof(CalculatorContext))]
    partial class CalculatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitnessProgressTracker.Models.CalculatorModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BodyFatMass");

                    b.Property<double>("BodyFatPer");

                    b.Property<double>("Height");

                    b.Property<double>("Hip");

                    b.Property<double>("LeanMass");

                    b.Property<double>("Neck");

                    b.Property<double>("Waist");

                    b.Property<double>("Weight");

                    b.HasKey("ID");

                    b.ToTable("CalculatorModel");
                });
#pragma warning restore 612, 618
        }
    }
}
