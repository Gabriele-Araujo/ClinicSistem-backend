using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Data.Dtos.DentistaDto
{
    public class CreateDentistaDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cro { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int ClinicaId { get; set; }

    }
}

