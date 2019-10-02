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
                  p => p.StudentFirstName,
                  new Student { StudentFirstName = "Andrew", StudentLastName= "Peters", StudentId = 11 },
                  new Student { StudentFirstName = "Brice", StudentLastName= "Lambson", StudentId = 12 },
                  new Student { StudentFirstName = "Rowan", StudentLastName= "Miller", StudentId = 13 },
                  new Student { StudentFirstName = "Rosie", StudentLastName = "Fitzgerald", StudentId = 14 }
                );
            //

        }


    }
}
