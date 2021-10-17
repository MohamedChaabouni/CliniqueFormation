using AutoMapper;
using Data.Interfaces;
using Domains;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class RendezVousService : BaseService, IRendezVousService
    {
        private readonly IDbRepository db;

        public RendezVousService(IDbRepository db, IMapper mapper) : base(mapper)
        {
            this.db = db;
        }
        public IList<RendezVousDTO> GetList()
        {
            var rendezVous = db.List<RendezVous>()
                .ToList();
            var result = Mapper.Map<List<RendezVousDTO>>(rendezVous);
            return result;
        }
    }
}
