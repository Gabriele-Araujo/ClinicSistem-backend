using System;
using System.Collections.Generic;
using ClinicSistem_backend.Models;

namespace ClinicSistem_backend.Data.Dtos.ClinicaDto
{
    public class ReadClinicaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public virtual List<Dentista> Dentista { get; set; }
    }
}
