namespace Clubber.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Clubber.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Clubber.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Students.AddOrUpdate(
                  p => p.FirstName,
                  new Student { FirstName = "Andrew", LastName= "Peters" },
                  new Student { FirstName = "Brice", LastName= "Lambson" },
                  new Student { FirstName = "Rowan", LastName= "Miller" }
                );
            //

        }


    }
}
