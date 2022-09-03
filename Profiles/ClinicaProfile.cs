using AutoMapper;
using ClinicSistem_backend.Data.Dtos.ClinicaDto;
using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Profiles
{
    public class ClinicaProfile : Profile
    {
        public ClinicaProfile()
        {
            CreateMap<CreateClinicaDto, Clinica>();
            CreateMap<Clinica, ReadClinicaDto>();
            CreateMap<UpdateClinicaDto, Clinica>();
        }
    }

}
