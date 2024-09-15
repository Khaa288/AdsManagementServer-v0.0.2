﻿// <auto-generated />
using System;
using AdsManagement.Modules.Auth.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AuthContext))]
    partial class AuthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdsManagement.Modules.Auth.Domain.Entities.Officer", b =>
                {
                    b.Property<Guid>("OfficerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OfficerId");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2")
                        .HasColumnName("DoB");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FullName");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleId");

                    b.Property<int>("WardId")
                        .HasColumnType("int")
                        .HasColumnName("WardId");

                    b.HasKey("OfficerId");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.ToTable("Officer", (string)null);
                });

            modelBuilder.Entity("AdsManagement.Modules.Auth.Domain.Entities.Privilege", b =>
                {
                    b.Property<Guid>("PrivilegeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PrivilegeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrivilegeId");

                    b.ToTable("Privilege");
                });

            modelBuilder.Entity("AdsManagement.Modules.Auth.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("OfficerPrivilege", b =>
                {
                    b.Property<Guid>("OfficersOfficerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PrivilegesPrivilegeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OfficersOfficerId", "PrivilegesPrivilegeId");

                    b.HasIndex("PrivilegesPrivilegeId");

                    b.ToTable("OfficerPrivilege");
                });

            modelBuilder.Entity("PrivilegeRole", b =>
                {
                    b.Property<Guid>("PrivilegesPrivilegeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolesRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PrivilegesPrivilegeId", "RolesRoleId");

                    b.HasIndex("RolesRoleId");

                    b.ToTable("PrivilegeRole");
                });

            modelBuilder.Entity("AdsManagement.Modules.Auth.Domain.Entities.Officer", b =>
                {
                    b.HasOne("AdsManagement.Modules.Auth.Domain.Entities.Role", "Role")
                        .WithOne("Officer")
                        .HasForeignKey("AdsManagement.Modules.Auth.Domain.Entities.Officer", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OfficerPrivilege", b =>
                {
                    b.HasOne("AdsManagement.Modules.Auth.Domain.Entities.Officer", null)
                        .WithMany()
                        .HasForeignKey("OfficersOfficerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdsManagement.Modules.Auth.Domain.Entities.Privilege", null)
                        .WithMany()
                        .HasForeignKey("PrivilegesPrivilegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrivilegeRole", b =>
                {
                    b.HasOne("AdsManagement.Modules.Auth.Domain.Entities.Privilege", null)
                        .WithMany()
                        .HasForeignKey("PrivilegesPrivilegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdsManagement.Modules.Auth.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdsManagement.Modules.Auth.Domain.Entities.Role", b =>
                {
                    b.Navigation("Officer")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
