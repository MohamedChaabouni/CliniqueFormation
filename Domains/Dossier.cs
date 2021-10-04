using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domains
{
    public class Dossier : BaseDb
    {
        public string NumDossier { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<RendezVous> RendezVous { get; set; }
        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
