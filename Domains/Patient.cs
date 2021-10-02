using Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domains
{
    public class Patient : BaseDb
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public DateTime NumAssMaladie { get; set; }
        public string Addresse { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }
        public Sexe Sexe { get; set; }
        [ForeignKey(nameof(Dossier))]
        public int? DossierId { get; set; }
        public virtual Dossier Dossier { get; set; }
        public virtual ICollection<Hospitalisation> Hospitalisations { get; set; }
        public virtual ICollection<SecretairePatient> SecretairePatients { get; set; }
    }
}
