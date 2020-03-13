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

        public bool RateAProduct(ProductRating model)
        {
            var entity =
                new ProductRating()
                {
                    StarRating = model.StarRating,
                    InstrumentId = model.InstrumentId,
                    AccessoryId = model.AccessoryId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(entity);
                ctx.SaveChanges();

                RatingService productRating = new RatingService();
                productRating.AverageRating(model.InstrumentId, model.AccessoryId);
                return ctx.SaveChanges() == 0;
            }
        }


        public bool AverageRating(int instrumentId, int accessoryId)
        {
            //double avgRate = 0;
            using (var ctx = new ApplicationDbContext())
            {
                var productRatingList = ctx.Ratings.Where(e => e.InstrumentId == e.InstrumentId || e.AccessoryId == e.AccessoryId).ToList();
                
                List<int> intList = new List<int>();

                foreach (ProductRating rate in productRatingList)
                {
                    intList.Add((int)rate.StarRating); //avgRate += rate.StarRating;
                }

                double averageRating = intList.Average();  //avgRate = avgRate / productRatingList.Count();

                Instrument instrumentRating = new Instrument();
                Accessory accessoryRating = new Accessory();

                
                ctx.Ratings.Where(e => e.InstrumentId == e.InstrumentId);
                
                instrumentRating = ctx.Instruments.Single(e => e.InstrumentId == e.InstrumentId);
                instrumentRating.AverageRating = averageRating; //.ToString().Substring(0, 3);

                ctx.Ratings.Where(e => e.AccessoryId == e.AccessoryId);
                
                accessoryRating = ctx.Accessories.Single(e => e.Id == e.Id);
                accessoryRating.AverageRating = averageRating;


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
                    .Single(e => e.Id == model.Id);

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
                            .Ratings.Single(e => e.Id == ratingId);
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
