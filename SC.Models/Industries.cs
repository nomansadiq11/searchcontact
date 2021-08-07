using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class Industries
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
