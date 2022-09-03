using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Data.Dtos.ProcedimentoDto
{
    public class ReadProcedimentoDto
    {
        public int Id { get; set; }
        public virtual Dentista Dentista { get; set; }
        public int DentistaId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public DateTime Data { get; set; }
        public string Procedimentos { get; set; }
    }
}
