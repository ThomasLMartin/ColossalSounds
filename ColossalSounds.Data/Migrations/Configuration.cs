namespace ColossalSounds.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ColossalSounds.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ColossalSounds.Data.ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(p => p.Email, new ApplicationUser { Email = "joehallam13@gmail.com", PasswordHash = "Payton5353:)", UserName = "joehallam13@gmail.com" });
            context.Classifications.AddOrUpdate(p => p.Id, new InstrumentClassification { Id = 1, TypeOfCategory = InstrumentClassification.CategoryType.woodwind, TypeOfInstrument = InstrumentClassification.InstrumentType.bass_clarinet });
            context.Instruments.AddOrUpdate(p => p.Name, new Instrument { Brand = "Yamaha", ModelName = "YCL-221", ExpLvl = ExperienceLevel.Intermediate, Price = 599.99m, Quantity = 3, Description = "A great student-class bass clarinet.", Name = "Yamah YCL-221 Bass Clarinet", InstrumentId = 1 });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Users.AddOrUpdate(p => p.Email, new ApplicationUser { Email = "joehallam13@gmail.com", PasswordHash = "Payton5353:)", UserName = "joehallam13@gmail.com" });
            context.Classifications.AddOrUpdate(p => p.Id, new InstrumentClassification { Id = 1, TypeOfCategory = InstrumentClassification.CategoryType.woodwind, TypeOfInstrument = InstrumentClassification.InstrumentType.bass_clarinet });
            context.Instruments.AddOrUpdate(p => p.Name, new Instrument { Brand = "Yamaha", ModelName = "YCL-221", ExpLvl = ExperienceLevel.Intermediate, Price = 599.99m, Quantity = 3, Description = "A great student-class bass clarinet.", Name = "Yamah YCL-221 Bass Clarinet", InstrumentId = 1 });
        }
    }
}
