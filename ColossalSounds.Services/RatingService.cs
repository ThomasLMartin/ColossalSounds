using ColossalSounds.Data;
using ColossalSounds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColossalSounds.Data.RatingClass;

namespace ColossalSounds.Services
{
    //create an array or rates for each accessory and instrument
    //add a rate to the specified array
    //return the average of the array as the rating for the item
    public class RatingService
    { 
        public double Average(int rating)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ratings.Where(e => e.StarRating == rating).Select(e => new Rate { StarRating = e.StarRating });
                var list = query.ToList();
                List<int> intList = new List<int>();
                foreach (Rate rate in query)
                {
                    intList.Add((int)rate.StarRating);
                }
                double average = intList.Average();
                return average;
            }
        }
    }
}
