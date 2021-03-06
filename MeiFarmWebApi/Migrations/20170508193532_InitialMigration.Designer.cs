﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MeiFarmWebApi.Contexts;

namespace MeiFarmWebApi.Migrations
{
    [DbContext(typeof(FarmAppContext))]
    [Migration("20170508193532_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeiFarmWebApi.Models.MedicamentModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionInfo");

                    b.Property<Guid>("FarmTypeId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FarmTypeId");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.MedicamentsTypesModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("MedicamentsTypes");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.OrganizationModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.RecipeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionInfo");

                    b.Property<Guid>("AdditionalMedicamentId");

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("CreatedById");

                    b.Property<DateTime>("Expired");

                    b.Property<Guid>("MedicamentId");

                    b.Property<Guid>("RecipeTypeId");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalMedicamentId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("MedicamentId");

                    b.HasIndex("RecipeTypeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.RecipesTypeModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("RecipesTypes");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.RoleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionInfo");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("OrganizationId");

                    b.Property<Guid>("RoleId");

                    b.Property<string>("Sex");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.MedicamentModel", b =>
                {
                    b.HasOne("MeiFarmWebApi.Models.MedicamentsTypesModel", "FarmType")
                        .WithMany()
                        .HasForeignKey("FarmTypeId");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.RecipeModel", b =>
                {
                    b.HasOne("MeiFarmWebApi.Models.MedicamentModel", "AdditionalMedicament")
                        .WithMany()
                        .HasForeignKey("AdditionalMedicamentId");

                    b.HasOne("MeiFarmWebApi.Models.UserModel", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("MeiFarmWebApi.Models.MedicamentModel", "Medicament")
                        .WithMany()
                        .HasForeignKey("MedicamentId");

                    b.HasOne("MeiFarmWebApi.Models.RecipesTypeModel", "RecipeType")
                        .WithMany()
                        .HasForeignKey("RecipeTypeId");
                });

            modelBuilder.Entity("MeiFarmWebApi.Models.UserModel", b =>
                {
                    b.HasOne("MeiFarmWebApi.Models.OrganizationModel", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId");

                    b.HasOne("MeiFarmWebApi.Models.RoleModel", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });
        }
    }
}
