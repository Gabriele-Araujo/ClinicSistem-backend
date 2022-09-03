using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Models
{
    public class Cronograma
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HorarioFinal { get; set; }
        [JsonIgnore]
        public virtual Dentista Dentista { get; set; }
        public int DentistaId { get; set; }
    }
}
