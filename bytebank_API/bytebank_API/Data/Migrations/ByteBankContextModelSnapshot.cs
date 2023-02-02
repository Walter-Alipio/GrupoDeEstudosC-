﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bytebank_API.Data;

#nullable disable

namespace bytebankAPI.Data.Migrations
{
    [DbContext(typeof(ByteBankContext))]
    partial class ByteBankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("bytebank_API.Models.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeAgencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroAgencia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Agencia", (string)null);
                });

            modelBuilder.Entity("bytebank_API.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("bytebank_API.Models.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<string>("ChavePix")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroConta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Conta", (string)null);
                });

            modelBuilder.Entity("bytebank_API.Models.EnderecoAgencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId")
                        .IsUnique()
                        .HasFilter("[AgenciaId] IS NOT NULL");

                    b.ToTable("EnderecoAgencia", (string)null);
                });

            modelBuilder.Entity("bytebank_API.Models.EnderecoCliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique()
                        .HasFilter("[ClienteId] IS NOT NULL");

                    b.ToTable("EnderecoCliente", (string)null);
                });

            modelBuilder.Entity("bytebank_API.Models.Conta", b =>
                {
                    b.HasOne("bytebank_API.Models.Agencia", null)
                        .WithMany()
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bytebank_API.Models.Cliente", null)
                        .WithMany("Contas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bytebank_API.Models.EnderecoAgencia", b =>
                {
                    b.HasOne("bytebank_API.Models.Agencia", null)
                        .WithOne("Endereco")
                        .HasForeignKey("bytebank_API.Models.EnderecoAgencia", "AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bytebank_API.Models.EnderecoCliente", b =>
                {
                    b.HasOne("bytebank_API.Models.Cliente", null)
                        .WithOne("Endereco")
                        .HasForeignKey("bytebank_API.Models.EnderecoCliente", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bytebank_API.Models.Agencia", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();
                });

            modelBuilder.Entity("bytebank_API.Models.Cliente", b =>
                {
                    b.Navigation("Contas");

                    b.Navigation("Endereco")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
