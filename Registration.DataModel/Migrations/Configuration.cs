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

            countries = context.Countries.ToList();

            var provinces = new List<Province>
            {
                new Province { CountryId = countries.Single(c => c.Name == "Netherlands").Id, Name = "North Holland" },
                new Province { CountryId = countries.Single(c => c.Name == "Netherlands").Id, Name = "South Holland" },
                new Province { CountryId = countries.Single(c => c.Name == "Netherlands").Id, Name = "Limburg" },

                new Province { CountryId = countries.Single(c => c.Name == "Italy").Id, Name = "Siena" },
                new Province { CountryId = countries.Single(c => c.Name == "Italy").Id, Name = "Vicenza" },

                new Province { CountryId = countries.Single(c => c.Name == "Spain").Id, Name = "Salamanca" },
                new Province { CountryId = countries.Single(c => c.Name == "Spain").Id, Name = "Toledo" },
                new Province { CountryId = countries.Single(c => c.Name == "Spain").Id, Name = "Albacete" },
                new Province { CountryId = countries.Single(c => c.Name == "Spain").Id, Name = "Guadalajara" },
            };

            context.Provinces.AddOrUpdate(p => new { p.CountryId, p.Name }, provinces.ToArray());
            context.SaveChanges();
        }
    }
}
