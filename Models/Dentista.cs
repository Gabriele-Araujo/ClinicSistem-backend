using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClinicSistem_backend.Models
{
    public class Dentista
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cro { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        [JsonIgnore]
        public virtual Clinica Clinica { get; set; }
        public int ClinicaId { get; set; }

        [JsonIgnore]
        public virtual List<Agenda> Agenda { get; set; }
        [JsonIgnore]
        public virtual List<Cronograma> Cronograma { get; set; }
        [JsonIgnore]
        public virtual List<Procedimento> Procedimentos { get; set; }

    }
}
