using AutoMapper;
using ClinicSistem_backend.Data.Dtos.PacienteDto;
using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Profiles
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<CreatePacienteDto, Paciente>();
            CreateMap<Paciente, ReadPacienteDto>();
            CreateMap<UpdatePacienteDto, Paciente>();
        }
    }
}
