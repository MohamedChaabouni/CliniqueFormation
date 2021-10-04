using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domains
{
    public class RendezVous : BaseDb
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int DossierId { get; set; }
        [ForeignKey(nameof(DossierId))]
        public virtual Dossier Dossier { get; set; }
    }
}
