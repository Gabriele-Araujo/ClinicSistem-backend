using AutoMapper;
using ClinicSistem_backend.Data.Dtos.DentistaDto;
using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Profiles
{
    public class DentistaProfile : Profile
    {
        public DentistaProfile()
        {
            CreateMap<CreateDentistaDto, Dentista>();
            CreateMap<Dentista, ReadDentistaDto>();
            CreateMap<UpdateDentistaDto, Dentista>();
        }
    }

}
