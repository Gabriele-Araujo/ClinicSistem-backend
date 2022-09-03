using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Data.Dtos.DentistaDto
{
    public class ReadDentistaDto
    {
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
        public virtual Clinica Clinica { get; set; }
        public int ClinicaId { get; set; }

        public virtual List<Agenda> Agenda { get; set; }
        public virtual List<Cronograma> Cronograma { get; set; }
        public virtual List<Procedimento> Procedimentos { get; set; }
    }
}
