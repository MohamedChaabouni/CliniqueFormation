using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domains
{
    public class Hospitaliser : BaseDb
    {
        public DateTime Date { get; set; }
        public DateTime HeureArrivee { get; set; }
        public DateTime HeureDepart { get; set; }
        
        public int MedecinId { get; set; }
        [ForeignKey(nameof(MedecinId))]
        public virtual Medecin Medecin { get; set; }

        public int HospitalisationId { get; set; }

        [ForeignKey(nameof(HospitalisationId))]
        public virtual Hospitalisation Hospitalisation { get; set; }
    }
}
