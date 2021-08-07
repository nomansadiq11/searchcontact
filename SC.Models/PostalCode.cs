using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class PostalCode
    {
        [Key]
        public int PCID { get; set; }
        [MaxLength(100)]
        public string PostCode { get; set; }

    }
}
