using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class ContactsDump
    {
        [Key]
        public int DumpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Organization { get; set; }
        public string CommonOrganizationName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string Revenue { get; set; }
        public string Employees { get; set; }
        public string Industries { get; set; }
        public string SICCode { get; set; }
        public string SICDescription { get; set; }
        public string Accuracy { get; set; }
        public string JobFunction { get; set; }



    }
}
