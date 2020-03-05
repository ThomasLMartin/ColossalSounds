using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Models.AccessoryModels
{
    public class AccessoryListItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public InstrumentType InstrumentAssociated { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
