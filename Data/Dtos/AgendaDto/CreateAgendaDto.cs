using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Data.Dtos.AgendaDto
{
    public class CreateAgendaDto
    {
        public DateTime DataConsulta { get; set; }
        public int DentistaId { get; set; }
        public int PacienteId { get; set; }
    }
}

