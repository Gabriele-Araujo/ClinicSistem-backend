using System;
using System.ComponentModel.DataAnnotations;
using ClinicSistem_backend.Models;

namespace ClinicSistem_backend.Data.Dtos.AgendaDto
{
    public class ReadAgendaDto
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }
        public virtual Dentista Dentista { get; set; }
        public int DentistaId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
    }
}
