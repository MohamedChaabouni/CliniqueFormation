using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domains
{
    public abstract class BaseDb
    {
        [Key]
        public int Id { get; set; }
        public DateTime _CreatedAt { get; set; }
        public DateTime _LastModiedAt { get; set; }
        public string _ModifiedBy { get; set; }
    }
}
