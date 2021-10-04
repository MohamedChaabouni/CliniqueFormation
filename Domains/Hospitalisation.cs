using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domains
{
    public class Hospitalisation : BaseDb
    {
        public string Code { get; set; }

        #region Relations
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        
        public int MedecinId { get; set; }
        [ForeignKey(nameof(MedecinId))]
        public virtual Medecin Medecin { get; set; }

        public virtual ICollection<Hospitaliser> Hospitalisers { get; set; }
        #endregion
    }
}
