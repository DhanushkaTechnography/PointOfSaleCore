﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaPos.DataAccess.AuthRepository;

namespace PizzaCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211026040700_m2")]
    partial class m2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85)
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(85)
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("RoleId")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("Name")
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PizzaCore.Entity.AuthenticationDto.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PizzaCore.Entity.AuthenticationDto.EmployeeRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("PizzaCore.Entity.Category.CategoryDto", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("text");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<int>("IsOther")
                        .HasColumnType("int");

                    b.Property<int>("IsPizza")
                        .HasColumnType("int");

                    b.Property<int>("IsTopping")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedDate")
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PizzaCore.Entity.Crust.CrustDto", b =>
                {
                    b.Property<int>("CrustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CrustCreatedDate")
                        .HasColumnType("text");

                    b.Property<string>("CrustName")
                        .HasColumnType("text");

                    b.Property<int>("CrustStatus")
                        .HasColumnType("int");

                    b.Property<string>("CrustUpdatedDate")
                        .HasColumnType("text");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.HasKey("CrustId");

                    b.ToTable("Crust");
                });

            modelBuilder.Entity("PizzaCore.Entity.CrustPrices.CrustPricesDto", b =>
                {
                    b.Property<int>("CrustPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CrustId")
                        .HasColumnType("int");

                    b.Property<double>("CrustPrice")
                        .HasColumnType("double");

                    b.Property<string>("CrustPriceCreatedDate")
                        .HasColumnType("text");

                    b.Property<int>("CrustPriceStatus")
                        .HasColumnType("int");

                    b.Property<string>("CrustPriceUpdatedDate")
                        .HasColumnType("text");

                    b.Property<int?>("CrustSizeSizesId")
                        .HasColumnType("int");

                    b.HasKey("CrustPriceId");

                    b.HasIndex("CrustId");

                    b.HasIndex("CrustSizeSizesId");

                    b.ToTable("CrustPrices");
                });

            modelBuilder.Entity("PizzaCore.Entity.Customer.CustomerDto", b =>
                {
                    b.Property<int>("CusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CusAddress")
                        .HasColumnType("text");

                    b.Property<string>("CusCity")
                        .HasColumnType("text");

                    b.Property<string>("CusContact")
                        .HasColumnType("text");

                    b.Property<string>("CusCountry")
                        .HasColumnType("text");

                    b.Property<string>("CusCreatedDate")
                        .HasColumnType("text");

                    b.Property<string>("CusName")
                        .HasColumnType("text");

                    b.Property<int>("CusStatus")
                        .HasColumnType("int");

                    b.Property<string>("CusUpdatedDate")
                        .HasColumnType("text");

                    b.HasKey("CusId");

                    b.ToTable("CustomerDto");
                });

            modelBuilder.Entity("PizzaCore.Entity.CustomerMembership.CustomerMembership", b =>
                {
                    b.Property<int>("RecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AssignedDate")
                        .HasColumnType("text");

                    b.Property<int?>("CustomerCusId")
                        .HasColumnType("int");

                    b.Property<int?>("MembershipId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UsedUntil")
                        .HasColumnType("text");

                    b.HasKey("RecId");

                    b.HasIndex("CustomerCusId");

                    b.HasIndex("MembershipId");

                    b.ToTable("CustomerMemberShip");
                });

            modelBuilder.Entity("PizzaCore.Entity.DeliveryOptions.DeliveryOptionDto", b =>
                {
                    b.Property<int>("MethodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Charge")
                        .HasColumnType("double");

                    b.Property<string>("MethodName")
                        .HasColumnType("text");

                    b.HasKey("MethodId");

                    b.ToTable("DeliveryOption");
                });

            modelBuilder.Entity("PizzaCore.Entity.Ingredients.IngredientsDto", b =>
                {
                    b.Property<int>("IngredientsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("PizzaId1")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("ToppingIdToppingsId")
                        .HasColumnType("int");

                    b.HasKey("IngredientsId");

                    b.HasIndex("PizzaId1");

                    b.HasIndex("ToppingIdToppingsId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("PizzaCore.Entity.Membership.MemberShipDto", b =>
                {
                    b.Property<int>("MembershipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("MinimumExpenses")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OrderCount")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("MembershipId");

                    b.ToTable("MemberShip");
                });

            modelBuilder.Entity("PizzaCore.Entity.Order.OrderDto", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CustomerCusId")
                        .HasColumnType("int");

                    b.Property<string>("DateWanted")
                        .HasColumnType("text");

                    b.Property<int?>("DeliveryOptionMethodId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("OrdCreatedDate")
                        .HasColumnType("text");

                    b.Property<float>("OrdDiscount")
                        .HasColumnType("float");

                    b.Property<float>("OrdSubTotal")
                        .HasColumnType("float");

                    b.Property<float>("OrdTax")
                        .HasColumnType("float");

                    b.Property<float>("OrdTotal")
                        .HasColumnType("float");

                    b.Property<string>("OrdUpdatedDate")
                        .HasColumnType("text");

                    b.Property<string>("TimeWanted")
                        .HasColumnType("text");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerCusId");

                    b.HasIndex("DeliveryOptionMethodId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaCore.Entity.Order.OrderStatusDto", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .HasColumnType("text");

                    b.HasKey("OrderStatusId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("PizzaCore.Entity.Pizza.PizzaDto", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("PizzaColor")
                        .HasColumnType("text");

                    b.Property<string>("PizzaCreateDate")
                        .HasColumnType("text");

                    b.Property<string>("PizzaName")
                        .HasColumnType("text");

                    b.Property<int>("PizzaStatus")
                        .HasColumnType("int");

                    b.Property<string>("PizzaUpdateDate")
                        .HasColumnType("text");

                    b.Property<int?>("SubCategoryId")
                        .HasColumnType("int");

                    b.HasKey("PizzaId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("PizzaDto");
                });

            modelBuilder.Entity("PizzaCore.Entity.PizzaOrderDetails.ExtraToppings", b =>
                {
                    b.Property<int>("ExtraToppingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Cost")
                        .HasColumnType("float");

                    b.Property<int?>("PizzaOrderDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("Portion")
                        .HasColumnType("int");

                    b.Property<string>("Side")
                        .HasColumnType("text");

                    b.Property<int?>("ToppingPriceId")
                        .HasColumnType("int");

                    b.HasKey("ExtraToppingId");

                    b.HasIndex("PizzaOrderDetailsId");

                    b.HasIndex("ToppingPriceId");

                    b.ToTable("ExtraTopping");
                });

            modelBuilder.Entity("PizzaCore.Entity.PizzaOrderDetails.PizzaOrderDetailsDto", b =>
                {
                    b.Property<int>("PizzaOrderDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CrustPriceId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int?>("PizzaSizeId")
                        .HasColumnType("int");

                    b.Property<float>("PizzaSubTotal")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PizzaOrderDetailsId");

                    b.HasIndex("CrustPriceId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaSizeId");

                    b.ToTable("OrderDetailsPizza");
                });

            modelBuilder.Entity("PizzaCore.Entity.PizzaSizes.PizzaSizesDto", b =>
                {
                    b.Property<int>("PizzaSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreateDate")
                        .HasColumnType("text");

                    b.Property<int?>("PizzaId1")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<int?>("SizeIdSizesId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdateDate")
                        .HasColumnType("text");

                    b.HasKey("PizzaSizeId");

                    b.HasIndex("PizzaId1");

                    b.HasIndex("SizeIdSizesId");

                    b.ToTable("PizzaPrice");
                });

            modelBuilder.Entity("PizzaCore.Entity.Sizes.SizesDto", b =>
                {
                    b.Property<int>("SizesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("SizeCreatedDate")
                        .HasColumnType("text");

                    b.Property<string>("SizeName")
                        .HasColumnType("text");

                    b.Property<int>("SizeStatus")
                        .HasColumnType("int");

                    b.Property<string>("SizeUpdatedDate")
                        .HasColumnType("text");

                    b.HasKey("SizesId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("PizzaCore.Entity.SubCategory.SubCategoryDto", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("SubCatCreatedDate")
                        .HasColumnType("text");

                    b.Property<string>("SubCatName")
                        .HasColumnType("text");

                    b.Property<int>("SubCatStatus")
                        .HasColumnType("int");

                    b.Property<string>("SubCatUpdatedDate")
                        .HasColumnType("text");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("TypeId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("PizzaCore.Entity.ToppingPrices.ToppingPricesDto", b =>
                {
                    b.Property<int>("ToppingPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("ToppingPrice")
                        .HasColumnType("double");

                    b.Property<string>("ToppingPriceCreatedDate")
                        .HasColumnType("text");

                    b.Property<int>("ToppingPriceStatus")
                        .HasColumnType("int");

                    b.Property<string>("ToppingPriceUpdatedDate")
                        .HasColumnType("text");

                    b.Property<int?>("ToppingSizeSizesId")
                        .HasColumnType("int");

                    b.Property<int?>("ToppingsId")
                        .HasColumnType("int");

                    b.HasKey("ToppingPriceId");

                    b.HasIndex("ToppingSizeSizesId");

                    b.HasIndex("ToppingsId");

                    b.ToTable("ToppingPrices");
                });

            modelBuilder.Entity("PizzaCore.Entity.Toppings.ToppingsDto", b =>
                {
                    b.Property<int>("ToppingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CategorySubCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<string>("ToppingCreatedDate")
                        .HasColumnType("text");

                    b.Property<string>("ToppingName")
                        .HasColumnType("text");

                    b.Property<int>("ToppingStatus")
                        .HasColumnType("int");

                    b.Property<string>("ToppingUpdatedDate")
                        .HasColumnType("text");

                    b.HasKey("ToppingsId");

                    b.HasIndex("CategorySubCategoryId");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaCore.Entity.Types.Types", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("text");

                    b.Property<int>("Deleted")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .HasColumnType("text");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("text");

                    b.HasKey("TypeId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("PizzaPos.DataAccess.AuthRepository.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

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
                    b.HasOne("PizzaPos.DataAccess.AuthRepository.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PizzaPos.DataAccess.AuthRepository.ApplicationUser", null)
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

                    b.HasOne("PizzaPos.DataAccess.AuthRepository.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PizzaPos.DataAccess.AuthRepository.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaCore.Entity.AuthenticationDto.Employee", b =>
                {
                    b.HasOne("PizzaCore.Entity.AuthenticationDto.EmployeeRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PizzaCore.Entity.CrustPrices.CrustPricesDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.Crust.CrustDto", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustId");

                    b.HasOne("PizzaCore.Entity.Sizes.SizesDto", "CrustSize")
                        .WithMany()
                        .HasForeignKey("CrustSizeSizesId");

                    b.Navigation("Crust");

                    b.Navigation("CrustSize");
                });

            modelBuilder.Entity("PizzaCore.Entity.CustomerMembership.CustomerMembership", b =>
                {
                    b.HasOne("PizzaCore.Entity.Customer.CustomerDto", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCusId");

                    b.HasOne("PizzaCore.Entity.Membership.MemberShipDto", "Membership")
                        .WithMany()
                        .HasForeignKey("MembershipId");

                    b.Navigation("Customer");

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("PizzaCore.Entity.Ingredients.IngredientsDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.Pizza.PizzaDto", "PizzaId")
                        .WithMany()
                        .HasForeignKey("PizzaId1");

                    b.HasOne("PizzaCore.Entity.Toppings.ToppingsDto", "ToppingId")
                        .WithMany()
                        .HasForeignKey("ToppingIdToppingsId");

                    b.Navigation("PizzaId");

                    b.Navigation("ToppingId");
                });

            modelBuilder.Entity("PizzaCore.Entity.Order.OrderDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.Customer.CustomerDto", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCusId");

                    b.HasOne("PizzaCore.Entity.DeliveryOptions.DeliveryOptionDto", "DeliveryOption")
                        .WithMany()
                        .HasForeignKey("DeliveryOptionMethodId");

                    b.HasOne("PizzaCore.Entity.AuthenticationDto.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Customer");

                    b.Navigation("DeliveryOption");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PizzaCore.Entity.Order.OrderStatusDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.Order.OrderDto", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PizzaCore.Entity.Pizza.PizzaDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.SubCategory.SubCategoryDto", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("PizzaCore.Entity.PizzaOrderDetails.ExtraToppings", b =>
                {
                    b.HasOne("PizzaCore.Entity.PizzaOrderDetails.PizzaOrderDetailsDto", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaOrderDetailsId");

                    b.HasOne("PizzaCore.Entity.ToppingPrices.ToppingPricesDto", "Topping")
                        .WithMany()
                        .HasForeignKey("ToppingPriceId");

                    b.Navigation("Pizza");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzaCore.Entity.PizzaOrderDetails.PizzaOrderDetailsDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.CrustPrices.CrustPricesDto", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustPriceId");

                    b.HasOne("PizzaCore.Entity.Order.OrderDto", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("PizzaCore.Entity.PizzaSizes.PizzaSizesDto", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaSizeId");

                    b.Navigation("Crust");

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaCore.Entity.PizzaSizes.PizzaSizesDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.Pizza.PizzaDto", "PizzaId")
                        .WithMany()
                        .HasForeignKey("PizzaId1");

                    b.HasOne("PizzaCore.Entity.Sizes.SizesDto", "SizeId")
                        .WithMany()
                        .HasForeignKey("SizeIdSizesId");

                    b.Navigation("PizzaId");

                    b.Navigation("SizeId");
                });

            modelBuilder.Entity("PizzaCore.Entity.SubCategory.SubCategoryDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.Category.CategoryDto", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("PizzaCore.Entity.Types.Types", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Category");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("PizzaCore.Entity.ToppingPrices.ToppingPricesDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.Sizes.SizesDto", "ToppingSize")
                        .WithMany()
                        .HasForeignKey("ToppingSizeSizesId");

                    b.HasOne("PizzaCore.Entity.Toppings.ToppingsDto", "Topping")
                        .WithMany()
                        .HasForeignKey("ToppingsId");

                    b.Navigation("Topping");

                    b.Navigation("ToppingSize");
                });

            modelBuilder.Entity("PizzaCore.Entity.Toppings.ToppingsDto", b =>
                {
                    b.HasOne("PizzaCore.Entity.SubCategory.SubCategoryDto", "Category")
                        .WithMany()
                        .HasForeignKey("CategorySubCategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
