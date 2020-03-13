using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Models
{
    public class RatingCreate
    {
        public int InstrumentId { get; set; }

        public int? AccessoryId { get; set; }

        public int? StarRating { get; set; }
    }

    public class RatingListItem
    {
        public int StarRating { get; set; }

        public string AccessoryName { get; set; }

        public string InstrumentName { get; set; }

    }

    public class RatingEdit
    {
        public int Id { get; set; }
        public int StarRating { get; set; }
    }
}
