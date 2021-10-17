using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class RendezVousDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int DossierId { get; set; }
        public string NomDossier { get; set; }
    }
}
