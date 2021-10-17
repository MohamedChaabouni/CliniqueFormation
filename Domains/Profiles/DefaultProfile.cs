using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Profiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<RendezVous, RendezVousDTO>()
                .ForMember(x => x.NomDossier, e => e.MapFrom(x => x.Dossier.Nom));
            CreateMap<RendezVousDTO, RendezVous>();
        }
    }
}
