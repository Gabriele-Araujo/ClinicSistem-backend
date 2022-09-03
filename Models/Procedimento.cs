using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Models
{
    public class Procedimento
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [JsonIgnore]
        public virtual Dentista Dentista { get; set; }
        public int DentistaId { get; set; }
        [JsonIgnore]
        public virtual Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public DateTime Data { get; set; }
        public string Procedimentos { get; set; }
    }
}
