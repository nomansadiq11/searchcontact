using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
