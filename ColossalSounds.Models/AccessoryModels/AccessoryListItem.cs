using ColossalSounds.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColossalSounds.Data.InstrumentClassification;

namespace ColossalSounds.Models.AccessoryModels
{
    public class AccessoryListItem
    {
        public int AccessoryId { get; set; }
        public string Name { get; set; }
        public InstrumentClassification.InstrumentType InstrumentAssociated { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double AverageRating { get; set; }
    }
}
