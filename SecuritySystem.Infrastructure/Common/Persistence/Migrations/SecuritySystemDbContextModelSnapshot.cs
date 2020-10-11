﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SecuritySystem.Infrastructure.Common.Persistence;

namespace SecuritySystem.Infrastructure.Common.Persistence.Migrations
{
    [DbContext(typeof(SecuritySystemDbContext))]
    partial class SecuritySystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SecuritySystem.Domain.ControlCenter.Models.AlarmEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssignedGuardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("SystemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AlarmEvents");
                });

            modelBuilder.Entity("SecuritySystem.Domain.Guards.Models.GuardPatrol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("GuardPatrols");
                });

            modelBuilder.Entity("SecuritySystem.Domain.Guards.Models.GuardTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GuardPatrolId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GuardTaskDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GuardPatrolId");

                    b.ToTable("GuardTasks");
                });

            modelBuilder.Entity("SecuritySystem.Domain.Guards.Models.GuardUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GuardPatrolId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GuardPatrolId");

                    b.ToTable("GuardUnits");
                });

            modelBuilder.Entity("SecuritySystem.Domain.Systems.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("SecuritySystem.Domain.Systems.Models.AlarmSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<bool>("AlarmTriggered")
                        .HasColumnType("bit");

                    b.Property<string>("ControlUnitSerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInConfiguration")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInstalled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("AlarmSystems");
                });

            modelBuilder.Entity("SecuritySystem.Infrastructure.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SecuritySystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SecuritySystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SecuritySystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SecuritySystem.Infrastructure.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SecuritySystem.Domain.ControlCenter.Models.AlarmEvent", b =>
                {
                    b.OwnsOne("SecuritySystem.Domain.Common.Models.Contact", "Contact", b1 =>
                        {
                            b1.Property<int>("AlarmEventId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.HasKey("AlarmEventId");

                            b1.ToTable("AlarmEvents");

                            b1.WithOwner()
                                .HasForeignKey("AlarmEventId");

                            b1.OwnsOne("SecuritySystem.Domain.Common.Models.PhoneNumber", "PhoneNumber", b2 =>
                                {
                                    b2.Property<int>("ContactAlarmEventId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("Number")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(20)")
                                        .HasMaxLength(20);

                                    b2.HasKey("ContactAlarmEventId");

                                    b2.ToTable("AlarmEvents");

                                    b2.WithOwner()
                                        .HasForeignKey("ContactAlarmEventId");
                                });
                        });

                    b.OwnsOne("SecuritySystem.Domain.ControlCenter.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("AlarmEventId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("StreetInfo")
                                .IsRequired()
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("AlarmEventId");

                            b1.ToTable("AlarmEvents");

                            b1.WithOwner()
                                .HasForeignKey("AlarmEventId");

                            b1.OwnsOne("SecuritySystem.Domain.Common.Models.GeoCoordinates", "Coordinates", b2 =>
                                {
                                    b2.Property<int>("AddressAlarmEventId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<decimal>("Latitude")
                                        .HasColumnType("decimal(12,9)");

                                    b2.Property<decimal>("Longitude")
                                        .HasColumnType("decimal(12,9)");

                                    b2.HasKey("AddressAlarmEventId");

                                    b2.ToTable("AlarmEvents");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressAlarmEventId");
                                });
                        });

                    b.OwnsOne("SecuritySystem.Domain.ControlCenter.Models.AlarmEventState", "State", b1 =>
                        {
                            b1.Property<int>("AlarmEventId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("AlarmEventId");

                            b1.ToTable("AlarmEvents");

                            b1.WithOwner()
                                .HasForeignKey("AlarmEventId");
                        });
                });

            modelBuilder.Entity("SecuritySystem.Domain.Guards.Models.GuardPatrol", b =>
                {
                    b.OwnsOne("SecuritySystem.Domain.Common.Models.GeoCoordinates", "GeoLocation", b1 =>
                        {
                            b1.Property<int>("GuardPatrolId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Latitude")
                                .HasColumnType("decimal(12,9)");

                            b1.Property<decimal>("Longitude")
                                .HasColumnType("decimal(12,9)");

                            b1.HasKey("GuardPatrolId");

                            b1.ToTable("GuardPatrols");

                            b1.WithOwner()
                                .HasForeignKey("GuardPatrolId");
                        });
                });

            modelBuilder.Entity("SecuritySystem.Domain.Guards.Models.GuardTask", b =>
                {
                    b.HasOne("SecuritySystem.Domain.Guards.Models.GuardPatrol", "AssignedPatrol")
                        .WithMany()
                        .HasForeignKey("GuardPatrolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SecuritySystem.Domain.Guards.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("GuardTaskId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.Property<string>("StreetInfo")
                                .IsRequired()
                                .HasColumnType("nvarchar(200)")
                                .HasMaxLength(200);

                            b1.HasKey("GuardTaskId");

                            b1.ToTable("GuardTasks");

                            b1.WithOwner()
                                .HasForeignKey("GuardTaskId");

                            b1.OwnsOne("SecuritySystem.Domain.Common.Models.GeoCoordinates", "Coordinates", b2 =>
                                {
                                    b2.Property<int>("AddressGuardTaskId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<decimal>("Latitude")
                                        .HasColumnType("decimal(12,9)");

                                    b2.Property<decimal>("Longitude")
                                        .HasColumnType("decimal(12,9)");

                                    b2.HasKey("AddressGuardTaskId");

                                    b2.ToTable("GuardTasks");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressGuardTaskId");
                                });
                        });

                    b.OwnsOne("SecuritySystem.Domain.Guards.Models.GuardTaskState", "State", b1 =>
                        {
                            b1.Property<int>("GuardTaskId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("GuardTaskId");

                            b1.ToTable("GuardTasks");

                            b1.WithOwner()
                                .HasForeignKey("GuardTaskId");
                        });
                });

            modelBuilder.Entity("SecuritySystem.Domain.Guards.Models.GuardUnit", b =>
                {
                    b.HasOne("SecuritySystem.Domain.Guards.Models.GuardPatrol", null)
                        .WithMany("GuardUnits")
                        .HasForeignKey("GuardPatrolId");
                });

            modelBuilder.Entity("SecuritySystem.Domain.Systems.Models.Address", b =>
                {
                    b.OwnsOne("SecuritySystem.Domain.Common.Models.GeoCoordinates", "Coordinates", b1 =>
                        {
                            b1.Property<int>("AddressId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Latitude")
                                .HasColumnType("decimal(12,9)");

                            b1.Property<decimal>("Longitude")
                                .HasColumnType("decimal(12,9)");

                            b1.HasKey("AddressId");

                            b1.ToTable("Addresses");

                            b1.WithOwner()
                                .HasForeignKey("AddressId");
                        });
                });

            modelBuilder.Entity("SecuritySystem.Domain.Systems.Models.AlarmSystem", b =>
                {
                    b.HasOne("SecuritySystem.Domain.Systems.Models.Address", "Address")
                        .WithOne()
                        .HasForeignKey("SecuritySystem.Domain.Systems.Models.AlarmSystem", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SecuritySystem.Domain.Common.Models.Contact", "ContactsInfo", b1 =>
                        {
                            b1.Property<int>("AlarmSystemId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(100)")
                                .HasMaxLength(100);

                            b1.HasKey("AlarmSystemId");

                            b1.ToTable("AlarmSystems");

                            b1.WithOwner()
                                .HasForeignKey("AlarmSystemId");

                            b1.OwnsOne("SecuritySystem.Domain.Common.Models.PhoneNumber", "PhoneNumber", b2 =>
                                {
                                    b2.Property<int>("ContactAlarmSystemId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int")
                                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                                    b2.Property<string>("Number")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(20)")
                                        .HasMaxLength(20);

                                    b2.HasKey("ContactAlarmSystemId");

                                    b2.ToTable("AlarmSystems");

                                    b2.WithOwner()
                                        .HasForeignKey("ContactAlarmSystemId");
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
