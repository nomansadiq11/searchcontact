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

        public string RecordID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string ContactPhone1 { get; set; }
        public string ContactPhone2 { get; set; }
        public string PrimaryJobFunction { get; set; }
        public string AllJobFunctions { get; set; }
        public string JobLevel { get; set; }
        public string CompanyName { get; set; }
        public string D_U_N_S { get; set; }
        public string CompanyPhone { get; set; }
        public string LocationType { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string WebAddress { get; set; }
        public string Revenue { get; set; }
        public string RevenueRange { get; set; }
        public string Employees { get; set; }
        public string EmployeeRange { get; set; }
        public string PrimaryIndustry { get; set; }
        public string AllIndustries { get; set; }
        public string PrimarySICCode { get; set; }
        public string PrimarySICDescription { get; set; }
        public string PrimaryNAICS1_1 { get; set; }




    }
}
