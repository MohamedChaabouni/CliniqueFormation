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
        
        [ForeignKey(nameof(Medecin))]
        public int MedecinId { get; set; }
        public virtual Medecin Medecin { get; set; }

        [ForeignKey(nameof(Hospitalisation))]
        public int HospitalisationId { get; set; }
        public virtual Hospitalisation Hospitalisation { get; set; }
    }
}
