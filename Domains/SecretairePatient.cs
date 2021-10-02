using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domains
{
    public class SecretairePatient : BaseDb
    {
        [ForeignKey(nameof(SecretaireInfirmiere))]
        public int SecretaireInfirmerieId { get; set; }
        public SecretaireInfirmiere SecretaireInfirmerie { get; set; }


        [ForeignKey(nameof(SecretaireInfirmiere))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
