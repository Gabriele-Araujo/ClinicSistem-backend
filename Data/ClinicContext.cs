using ClinicSistem_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Data
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> opt) : base (opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            /*BUILDER FOR RELASHIOSHIPS ONE TO ONE*/
            builder.Entity<Agenda>()
                .HasOne(agenda => agenda.Paciente)
                .WithOne(paciente => paciente.Agenda)
                .HasForeignKey<Agenda>(agenda => agenda.PacienteId);

            /*BUILDER FOR RELASHIOSHIPS ONE TO MANY*/
            builder.Entity<Agenda>()
                .HasOne(agenda => agenda.Dentista)
                .WithMany(dentista => dentista.Agenda)
                .HasForeignKey(agenda => agenda.DentistaId);

            builder.Entity<Dentista>()
                .HasOne(dentista => dentista.Clinica)
                .WithMany(clinica => clinica.Dentista)
                .HasForeignKey(dentista => dentista.ClinicaId);

            builder.Entity<Cronograma>()
                .HasOne(cronograma => cronograma.Dentista)
                .WithMany(dentista => dentista.Cronograma)
                .HasForeignKey(cronograma => cronograma.DentistaId);

            builder.Entity<Procedimento>()
                .HasOne(procedimento => procedimento.Paciente)
                .WithMany(paciente => paciente.Procedimentos)
                .HasForeignKey(procedimento => procedimento.PacienteId);

            builder.Entity<Procedimento>()
                .HasOne(procedimento => procedimento.Dentista)
                .WithMany(dentista => dentista.Procedimentos)
                .HasForeignKey(procedimento => procedimento.DentistaId);

        }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Cronograma> Cronogramas { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
    }
}
