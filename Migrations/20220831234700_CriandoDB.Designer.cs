﻿// <auto-generated />
using System;
using ClinicSistem_backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicSistem_backend.Migrations
{
    [DbContext(typeof(ClinicContext))]
    [Migration("20220831234700_CriandoDB")]
    partial class CriandoDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("ClinicSistem_backend.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataConsulta")
                        .HasColumnType("datetime");

                    b.Property<int>("DentistaId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DentistaId");

                    b.HasIndex("PacienteId")
                        .IsUnique();

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Clinica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clinicas");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Cronograma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DentistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioFinal")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("HorarioInicial")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("DentistaId");

                    b.ToTable("Cronogramas");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Dentista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .HasColumnType("text");

                    b.Property<int>("ClinicaId")
                        .HasColumnType("int");

                    b.Property<string>("Cro")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClinicaId");

                    b.ToTable("Dentistas");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<string>("Cep")
                        .HasColumnType("text");

                    b.Property<string>("Cidade")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<DateTime>("PrimeiraConsulta")
                        .HasColumnType("datetime");

                    b.Property<string>("Rua")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Procedimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<int>("DentistaId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Procedimentos")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DentistaId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Procedimentos");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Agenda", b =>
                {
                    b.HasOne("ClinicSistem_backend.Models.Dentista", "Dentista")
                        .WithMany("Agenda")
                        .HasForeignKey("DentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicSistem_backend.Models.Paciente", "Paciente")
                        .WithOne("Agenda")
                        .HasForeignKey("ClinicSistem_backend.Models.Agenda", "PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentista");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Cronograma", b =>
                {
                    b.HasOne("ClinicSistem_backend.Models.Dentista", "Dentista")
                        .WithMany("Cronograma")
                        .HasForeignKey("DentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentista");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Dentista", b =>
                {
                    b.HasOne("ClinicSistem_backend.Models.Clinica", "Clinica")
                        .WithMany("Dentista")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Procedimento", b =>
                {
                    b.HasOne("ClinicSistem_backend.Models.Dentista", "Dentista")
                        .WithMany("Procedimentos")
                        .HasForeignKey("DentistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicSistem_backend.Models.Paciente", "Paciente")
                        .WithMany("Procedimentos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dentista");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Clinica", b =>
                {
                    b.Navigation("Dentista");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Dentista", b =>
                {
                    b.Navigation("Agenda");

                    b.Navigation("Cronograma");

                    b.Navigation("Procedimentos");
                });

            modelBuilder.Entity("ClinicSistem_backend.Models.Paciente", b =>
                {
                    b.Navigation("Agenda");

                    b.Navigation("Procedimentos");
                });
#pragma warning restore 612, 618
        }
    }
}