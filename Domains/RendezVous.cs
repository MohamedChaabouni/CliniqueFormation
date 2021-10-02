using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class RendezVous : BaseDb
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public virtual Dossier Dossier { get; set; }
    }
}
