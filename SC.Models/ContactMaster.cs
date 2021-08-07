using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC.Models
{
    public class ContactMaster
    {
        public int ContactID { get; set; }

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

        public string CountryName { get; set; }
        public string StateCode { get; set; }
        public string CityName { get; set; }
        public string PostCode { get; set; }
        public string JobFunctionName { get; set; }
        public string AccuracyName { get; set; }
        public string SICDetails { get; set; }
        public string IndustriesName { get; set; }
        public string EmployeeName { get; set; }
        public string RevenueName { get; set; }
        public string CountyName { get; set; }
    }

    public class ContactResponseMaster
    {
        public List<ContactMaster> contactMaster { get; set; }
        public int TotalContact { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
