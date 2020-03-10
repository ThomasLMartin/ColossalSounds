using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Data
{
    public class RatingClass
    {
        public class Rate
        {
            [Key]
            public int Id { get; set; }
            public double StarRating { get; set; }
        }
        public class Rating
        {
            List<Rate> _rates = new List<Rate>();
        }

    }

}
