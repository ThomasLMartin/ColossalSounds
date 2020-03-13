using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColossalSounds.Data.ProductRating;

namespace ColossalSounds.Data
{
    public class Accessory
    {
        [Key]
        public int AccessoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public InstrumentClassification.InstrumentType InstrumentAssociated { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public double AverageRating { get; set; }
    }
}
