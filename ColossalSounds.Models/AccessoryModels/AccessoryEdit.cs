using ColossalSounds.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Models.AccessoryModels
{
    public class AccessoryEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public InstrumentClassification InstrumentAssociated { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
