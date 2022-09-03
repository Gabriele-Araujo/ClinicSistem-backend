using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Data.Dtos.CronogramaDto
{
    public class ReadCronogramaDto
    {
        public int Id { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        public virtual Dentista Dentista { get; set; }
        public int DentistaId { get; set; }
    }
}
