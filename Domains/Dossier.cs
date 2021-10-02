using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class Dossier : BaseDb
    {
        public string NumDossier { get; set; }
        public string Nom { get; set; }
        public virtual ICollection<RendezVous> RendezVous { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
