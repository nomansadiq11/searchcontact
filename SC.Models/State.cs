using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        [MaxLength(200)]
        public string Code { get; set; }
    }
}
