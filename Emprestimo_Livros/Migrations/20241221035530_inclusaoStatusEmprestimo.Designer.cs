﻿// <auto-generated />
using System;
using Emprestimo_Livros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Emprestimo_Livros.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241221035530_inclusaoStatusEmprestimo")]
    partial class inclusaoStatusEmprestimo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Emprestimo_Livros.Models.EmprestimoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataEmprestimoLivro")
                        .HasColumnType("datetime2");

                    b.Property<string>("FornecedorNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LivroEmprestadoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecebedorNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmprestimoLivros");
                });
#pragma warning restore 612, 618
        }
    }
}
