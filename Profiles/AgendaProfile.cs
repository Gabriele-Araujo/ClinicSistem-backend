using AutoMapper;
using ClinicSistem_backend.Data.Dtos.AgendaDto;
using ClinicSistem_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicSistem_backend.Profiles
{
    public class AgendaProfile : Profile
    {
        public AgendaProfile()
        {
            CreateMap<CreateAgendaDto, Agenda>();
            CreateMap<Agenda, ReadAgendaDto>();
            CreateMap<UpdateAgendaDto, Agenda>();
        }
    }
}
