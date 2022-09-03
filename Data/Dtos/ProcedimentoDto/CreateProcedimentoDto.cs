using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Data.Dtos.ProcedimentoDto
{
    public class CreateProcedimentoDto
    {
        public int DentistaId { get; set; }
        public int PacienteId { get; set; }
        public DateTime Data { get; set; }
        public string Procedimentos { get; set; }
    }
}

