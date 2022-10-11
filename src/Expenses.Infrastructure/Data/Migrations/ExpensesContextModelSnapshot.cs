﻿// <auto-generated />
using System;
using Expenses.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Expenses.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ExpensesContext))]
    partial class ExpensesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Expenses.Infrastructure.Models.AccountDto", b =>
                {
                    b.Property<string>("Iban")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<ushort>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Iban");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Expenses.Infrastructure.Models.CategoryDto", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            Name = "Overig"
                        });
                });

            modelBuilder.Entity("Expenses.Infrastructure.Models.FixedTransactionDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<uint?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CounterParty")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<uint?>("SubcategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("TransactionDirectionId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("TransactionIntervalId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("FixedTransactions");
                });

            modelBuilder.Entity("Expenses.Infrastructure.Models.SubcategoryDto", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint?>("CategoryDtoId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryDtoId");

                    b.ToTable("Subcategories");

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            CategoryId = 1u,
                            Name = "Overig"
                        });
                });

            modelBuilder.Entity("Expenses.Infrastructure.Models.TransactionDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountDtoIban")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<uint?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<string>("CounterIban")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<ushort>("Direction")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsProcessed")
                        .HasColumnType("INTEGER");

                    b.Property<ushort>("Method")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MyIban")
                        .HasColumnType("TEXT");

                    b.Property<uint?>("SubcategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccountDtoIban");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Expenses.Infrastructure.Models.FixedTransactionDto", b =>
                {
                    b.HasOne("Expenses.Infrastructure.Models.CategoryDto", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Expenses.Infrastructure.Models.SubcategoryDto", "Subcategory")
                        .WithMany()
                        .HasForeignKey("SubcategoryId");

                    b.Navigation("Category");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Expenses.Infrastructure.Models.SubcategoryDto", b =>
                {
                    b.HasOne("Expenses.Infrastructure.Models.CategoryDto", null)
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryDtoId");
                });

            modelBuilder.Entity("Expenses.Infrastructure.Models.TransactionDto", b =>
                {
                    b.HasOne("Expenses.Infrastructure.Models.AccountDto", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountDtoIban");

                    b.HasOne("Expenses.Infrastructure.Models.CategoryDto", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Expenses.Infrastructure.Models.SubcategoryDto", "Subcategory")
                        .WithMany()
                        .HasForeignKey("SubcategoryId");

                    b.Navigation("Category");

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("Expenses.Infrastructure.Models.AccountDto", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Expenses.Infrastructure.Models.CategoryDto", b =>
                {
                    b.Navigation("Subcategories");
                });
#pragma warning restore 612, 618
        }
    }
}