namespace Registration.DataModel.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Registration.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<RegistrationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RegistrationDbContext context)
        {
            var countries = new List<Country>
            {
                new Country { Name = "Netherlands" },
                new Country { Name = "Italy" },
                new Country { Name = "Spain" },
            };

            context.Countries.AddOrUpdate(c => c.Name, countries.ToArray());
            context.SaveChanges();
        }
    }
}
