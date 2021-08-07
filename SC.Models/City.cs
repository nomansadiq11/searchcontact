using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public int StateID { get; set; }

    }
}
