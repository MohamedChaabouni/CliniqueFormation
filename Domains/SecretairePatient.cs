using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domains
{
    public class SecretairePatient : BaseDb
    {
        public int SecretaireInfirmerieId { get; set; }
        [ForeignKey(nameof(SecretaireInfirmerieId))]
        public SecretaireInfirmiere SecretaireInfirmerie { get; set; }


        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }
    }
}
