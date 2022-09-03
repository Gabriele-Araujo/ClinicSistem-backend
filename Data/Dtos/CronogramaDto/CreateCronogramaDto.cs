using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Data.Dtos.CronogramaDto
{ 
    public class CreateCronogramaDto
    {
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public int DentistaId { get; set; }
    }
}

