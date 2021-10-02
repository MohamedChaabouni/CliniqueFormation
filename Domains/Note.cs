using System;
using System.Collections.Generic;
using System.Text;

namespace Domains
{
    public class Note : BaseDb
    {
        public string Code { get; set; }
        public string Content { get; set; }
        public virtual Dossier Dossier { get; set; }
    }
}
