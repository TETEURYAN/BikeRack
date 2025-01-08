﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using BikeRack.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BikeRack.Migrations
{
    [DbContext(typeof(AluguelContext))]
    [Migration("20250105225320_Adicionado a tabela gestao aluguel")]
    partial class Adicionadoatabelagestaoaluguel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MicrosservicoAluguel.Models.CartaoDeCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CiclistaId")
                        .HasColumnType("integer");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeTitular")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Validade")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CiclistaId")
                        .IsUnique();

                    b.ToTable("CartoesDeCredito");
                });

            modelBuilder.Entity("MicrosservicoAluguel.Models.Ciclista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nacionalidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UrlFotoDocumento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("nascimento")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Ciclistas");
                });

            modelBuilder.Entity("MicrosservicoAluguel.Models.Funcionario", b =>
                {
                    b.Property<string>("Matricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ConfirmacaoSenha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Funcao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Idade")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Matricula");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("MicrosservicoAluguel.Models.GestaoAluguel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Bicicleta")
                        .HasColumnType("integer");

                    b.Property<int>("Ciclista")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Cobranca")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("HoraFim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("TrancaFim")
                        .HasColumnType("integer");

                    b.Property<int>("TrancaInicio")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Ciclista");

                    b.ToTable("GestaoAluguel");
                });

            modelBuilder.Entity("MicrosservicoAluguel.Models.Passaporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CiclistaId")
                        .HasColumnType("integer");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Validade")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CiclistaId")
                        .IsUnique();

                    b.ToTable("Passaportes");
                });

            modelBuilder.Entity("MicrosservicoAluguel.Models.CartaoDeCredito", b =>
                {
                    b.HasOne("MicrosservicoAluguel.Models.Ciclista", null)
                        .WithOne("CartaoDeCredito")
                        .HasForeignKey("MicrosservicoAluguel.Models.CartaoDeCredito", "CiclistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MicrosservicoAluguel.Models.GestaoAluguel", b =>
                {
                    b.HasOne("MicrosservicoAluguel.Models.Ciclista", null)
                        .WithMany()
                        .HasForeignKey("Ciclista")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MicrosservicoAluguel.Models.Passaporte", b =>
                {
                    b.HasOne("MicrosservicoAluguel.Models.Ciclista", null)
                        .WithOne("Passaporte")
                        .HasForeignKey("MicrosservicoAluguel.Models.Passaporte", "CiclistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MicrosservicoAluguel.Models.Ciclista", b =>
                {
                    b.Navigation("CartaoDeCredito")
                        .IsRequired();

                    b.Navigation("Passaporte")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
