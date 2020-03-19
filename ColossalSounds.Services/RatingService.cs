using ColossalSounds.Data;
using ColossalSounds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColossalSounds.Data.ProductRating;

namespace ColossalSounds.Services
{
    //create an array or rates for each accessory and instrument
    //add a rate to the specified array
    //return the average of the array as the rating for the item
    public class RatingService
    {
        //Alright gents... here we go... 

        //A few notes. First, we made was in the data assembly --> Ratings Class there were two classes inside of another class. We removed the class the was housing the two classes and commented out the one with the list in it. 

        //Second, We also updated some names for clarification and added two Foreign Keys so that the ratings get connected to the specific instrument or product. 

        //Third, I also changes the ID in accessory data table to "AccessoryId" for clarification

        //Fourth, we created an "AverageRating" property in both Instrument and Accessory data models


        //Directly below is the create a Product rating that takes in the values passed in through Postman and then calls in the AverageRating method (directly below) which creates the average and then saves it. Jess helped us so this a hybrid of the one he shared and the average method that was originally in here. 
        
        //I'll note out steps
        public bool CreatingProductRating(RatingCreate model)
        {
            // Here is like all our other create functins just passing in the model
            var entity =
                new ProductRating()
                {
                    StarRating = model.StarRating,
                    InstrumentId = model.InstrumentId,
                    AccessoryId = model.AccessoryId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                //Opened the Dbcontext and then "entity" passes in the model directly above
                ctx.Ratings.Add(entity);

                //This saves the changes the "entity" model passes into the Ratings Dbcontext before we send it to the AverageRating method. Jess wasn't sure why this step was needed, but I think it adds it to the table.
                ctx.SaveChanges(); 

                //This send the info to the averaging method below
                AverageRating(model.InstrumentId, model.AccessoryId);

                //It's odd everything actually runs through the Averaging method before it hits this step
                return ctx.SaveChanges() == 0;
            }
        }


        //Notice the int? --> I wanted to be able to only have write out this method once for both instrument and accesory ratings. Right now it is set up to really only handle rating one or the other, at least to my knowledge. 
        //So I had to make them nullable and took me a while to figure out that I had to notate these as "int?" as well! 
        public bool AverageRating(int? instrumentId, int? accessoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {

                if (instrumentId != null)
                {
                    //This adds everything to a list. By everything. I mean everything in the RatingClass database table 
                    var productRatingList = ctx.Ratings.Where(e => e.InstrumentId == instrumentId).ToList();

                    List<int> intList = new List<int>();

                    //This parses through the list and pulls out all the ratings and adds it to the list creaed above 
                    foreach (ProductRating rate in productRatingList)
                    {
                        intList.Add((int)rate.StarRating); 
                    }

                    double averageRating = intList.Average();  

                    //This calls in the Instrument database and then places the average into the "AverageRating" spot in the Instrument table, which is then saved to the database in the step after the else if block
                    var instrumentRating = ctx.Instruments.Single(e => e.InstrumentId == instrumentId);
                    instrumentRating.AverageRating = averageRating; 
                }
                else if (accessoryId != null)
                {
                    var accessoryRatingList = ctx.Ratings.Where(e => e.AccessoryId == accessoryId).ToList();

                    List<int> intList = new List<int>();

                    foreach (ProductRating rate in accessoryRatingList)
                    {
                        intList.Add((int)rate.StarRating); 
                    }

                    double averageRating = intList.Average();  

                    var accessoryRating = ctx.Accessories.Single(e => e.AccessoryId == accessoryId);
                    accessoryRating.AverageRating = averageRating;
                }

                return ctx.SaveChanges() == 1;
            }
        }

        //public double AverageRating(int rating)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx.Ratings.Where(e => e.StarRating == rating).Select(e => new ProductRating { StarRating = e.StarRating });
        //        var list = query.ToList();
        //        List<int> intList = new List<int>();
        //        foreach (ProductRating rate in query)
        //        {
        //            intList.Add((int)rate.StarRating);
        //        }
        //        double average = intList.Average();
        //        return average;
        //    }
        //}


        public IEnumerable<RatingListItem> GetRating()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ratings
                        .Select(
                            e =>
                                new RatingListItem
                                {
                                    StarRating = e.StarRating,
                                    AccessoryName = e.Accessory.Name,
                                    InstrumentName = e.Instrument.Name
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    ctx
                    .Ratings
                    .Single(e => e.RatingId == model.RatingId);

                entity.StarRating = model.StarRating;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRating(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity =
                        ctx
                            .Ratings.Single(e => e.RatingId == ratingId);
                    ctx.Ratings.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
}
