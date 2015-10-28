using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Registration.Entities;

namespace Registration.DataModel
{
    public class RegistrationDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }
}
