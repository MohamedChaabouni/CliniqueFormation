using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class SecretaireInfirmiere : BaseDb
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string NumAssMaladie { get; set; }
        public string Addresse { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }
        public virtual ICollection<SecretairePatient> SecretairePatients { get; set; }
    }
}
