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
            

            context.Users.AddOrUpdate(p => p.Email, new ApplicationUser { Email = "party@partytown.com", PasswordHash = "Test2!", UserName = "part@partytown.com" });
            context.Users.AddOrUpdate(p => p.Email, new ApplicationUser { Email = "joehallam23@gmail.com", PasswordHash = "PuppyDog123:)", UserName = "joehallam23@gmail.com" });
            context.Classifications.AddOrUpdate(
                p => p.ClassificationId,
                new InstrumentClassification { TypeOfCategory = InstrumentClassification.CategoryType.brass, TypeOfInstrument = InstrumentClassification.InstrumentType.trombone, ClassificationId = 1 },
                new InstrumentClassification { TypeOfCategory = InstrumentClassification.CategoryType.percussion, TypeOfInstrument = InstrumentClassification.InstrumentType.drum_kit, ClassificationId = 2 },
                new InstrumentClassification { TypeOfCategory = InstrumentClassification.CategoryType.strings, TypeOfInstrument = InstrumentClassification.InstrumentType.guitar, ClassificationId = 3 },
                new InstrumentClassification { TypeOfCategory = InstrumentClassification.CategoryType.woodwind, TypeOfInstrument = InstrumentClassification.InstrumentType.oboe, ClassificationId = 4 }
                );
            context.Accessories.AddOrUpdate(
                p => p.Brand,
                new Accessory { Brand = "Vandoren", Description = "Pack of 5 size 3 clarinet reeds", InstrumentAssociated = (InstrumentClassification.InstrumentType)8, Name = "CR103", Price = 26.99m, Quantity = 30 },
                  new Accessory { Brand = "Ernie Ball", Description = "3 Pack Custom Gauge Nickel Wound Guitar Strings", InstrumentAssociated = (InstrumentClassification.InstrumentType)13, Name = "Regular Slinky", Price = 13.99m, Quantity = 50 },
                    new Accessory { Brand = "Vic Firth", Description = "Classic Vic Firth Design with Wood Tips", InstrumentAssociated = (InstrumentClassification.InstrumentType)16, Name = "American Classic 5A", Price = 9.99m, Quantity = 25 }
                    );
            context.Instruments.AddOrUpdate(
                p => p.Name,
                new Instrument { Name = "Tenor Trombone", ModelName = "I45 - 290", Brand = "CONN", ExpLvl = ExperienceLevel.Intermediate, Quantity = 4, Description = "An intermediate horn that plays like a professional", Price = 789.99m, ClassificationId = 1 },
                new Instrument { Name = "5 Piece Drum Kit", ModelName = "Careter Bueaford Deluxe Edition", Brand = "Gretch", ExpLvl = ExperienceLevel.Beginner, Quantity = 2, Description = "Everything you could ever want out of a drum kit. Includes: snare, three toms, bass drum, hit-hat, and while supplies last two crash cymbols.", Price = 1289.99m, ClassificationId = 2 },
                new Instrument { Name = "Electric Guitar", ModelName = "Telecaster", Brand = "Fender", ExpLvl = ExperienceLevel.Expert, Quantity = 1, Description = "Chet Akins Limited Edition Telecaster that will melt you face.", Price = 3250.00m, ClassificationId = 3 },
                new Instrument { Name = "Oboe", ModelName = "123FB", Brand = "Selmer", ExpLvl = ExperienceLevel.Intermediate, Quantity = 2, Description = "Great for studnets taking the step up from beginner to intermidate", Price = 2724.00m, ClassificationId = 4 }
                );
            context.Reviews.AddOrUpdate(
                new Review { InstrumentId = null, AccessoryId = 1, Content = "This set is great for beginner and intermediate players who prefer a little resistance in their reed to produce a sharper and clearer sound.", Title = "Great beginner reeds!", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Review { InstrumentId = null, AccessoryId = 1, Content = "Purchased this set for my son who has been playing for 3 years. These reeds were mush after 5 days of regular play.", Title = "Terrible Quality", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Review { InstrumentId = 4, AccessoryId = null, Content = "I have a lot of personal attachment with this guitar. It was the guitar I used with my first band, Good Kid. It's an excellent pick for anyone who knows what they're doing with a guitar", Title = "My Experience with the Fender Telecaster", DateCreated = DateTime.Now, DateModified = DateTime.Now },
                new Review { InstrumentId = 4, AccessoryId = null, Content = "This guitar is amazing. I've been playing for well over 12 years, and this guitar is one of the finest I've ever played on. Highly recommended to any mid-level to professional player.", Title = "Fender TeleMASTER", DateCreated = DateTime.Now, DateModified = DateTime.Now }
                );
            context.Classifications.AddOrUpdate(p => p.ClassificationId, new InstrumentClassification { TypeOfCategory = InstrumentClassification.CategoryType.woodwind, TypeOfInstrument = InstrumentClassification.InstrumentType.clarinet });
            context.Instruments.AddOrUpdate(p => p.Name, new Instrument { Brand = "Yamaha", ModelName = "YCL-221", ExpLvl = ExperienceLevel.Intermediate, Price = 599.99m, Quantity = 3, Description = "A great student-class bass clarinet.", Name = "Yamah YCL-221 Bass Clarinet", InstrumentId = 1 });
            context.Customers.AddOrUpdate(p => p.CustomerId, new Customer { FirstName = "John", LastName = "Smith", StreetAddress = "123 Fake Street", City = "Holland", State = "Michigan", Email = "johnsmith123@gmail.com", PhoneNumber = "0123456789", Zipcode = "46038" });



        }
    }
}
