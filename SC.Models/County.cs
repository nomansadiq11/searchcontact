using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class County
    {
        [Key]
        public int ID { get; set; }
        
        public int StateID { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
