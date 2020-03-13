using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Data
{
    public class ProductRating
    {
        [Key]
        public int Id { get; set; }
        public int StarRating { get; set; }

        [ForeignKey(nameof(Instrument))]
        public int InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set; }

        [ForeignKey(nameof(Accessory))]
        public int AccessoryId { get; set; }
        public virtual Accessory Accessory { get; set; }

    }
    public class Rating
    {
        List<ProductRating> _rates = new List<ProductRating>();
    }

}
