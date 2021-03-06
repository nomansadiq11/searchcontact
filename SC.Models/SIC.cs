using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class SIC
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
