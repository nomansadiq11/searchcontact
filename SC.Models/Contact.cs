using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class Contact
    {
        [Key]
        public Int64 ContactID { get; set; }
        
        public string Title { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Phone1 { get; set; }
        
        public string Phone2 { get; set; }
        
        public string Street { get; set; }
        
        public string Website { get; set; }
        
        public string Organization { get; set; }
        
        public string CommonOrganizationName { get; set; }

        public int CountryID { get; set; }
        public Int64 StateID { get; set; }
        
        public Int64 CityID { get; set; }
        public Int64 PostalID { get; set; }
        public Int64 JobFunctionID { get; set; }
        public Int64 AccuracyID { get; set; }
        public Int64 SICID { get; set; }
        public Int64 IndustriesID { get; set; }
        public Int64 EmployeesID { get; set; }
        public Int64 RevenueID { get; set; }
        public Int64 COUNTYID { get; set; }




    }
}
