using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Models
{
    public class Paciente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime PrimeiraConsulta { get; set; }
        [JsonIgnore]
        public virtual Agenda Agenda { get; set; }
        [JsonIgnore]
        public virtual List<Procedimento> Procedimentos { get; set; }

    }
}
