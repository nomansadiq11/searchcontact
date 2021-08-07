using SC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SC.Data
{
    public class SCContext : DbContext
    {

        public SCContext() : base("name=SearchContact")
        {

        }

        public DbSet<Contact> tblContact { get; set; }
        public DbSet<ContactsDump> tblContactsDump { get; set; }
        public DbSet<City> tblCity { get; set; }
        public DbSet<State> tblState { get; set; }
        public DbSet<Country> tblCountry { get; set; }

        public DbSet<Accuracy> tblAccuracy { get; set; }

        public DbSet<County> tblCounty { get; set; }
        public DbSet<Employees> tblEmployees { get; set; }
        public DbSet<Industries> tblIndustries { get; set; }

        public DbSet<JobFunction> tblJobFunction { get; set; }
        public DbSet<Revenue> tblRevenue { get; set; }
        public DbSet<SIC> tblSIC { get; set; }
        public DbSet<Postal> tblPostal { get; set; }
        public DbSet<SelectedSearch> tblSelectedSearch { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }



    }
}
