using ColossalSounds.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColossalSounds.Data.InstrumentClassification;

namespace ColossalSounds.Models.AccessoryModels
{
    public class AccessoryDetail
    {
        public int AccessoryId { get; set; }

        [Display(Name = "Accessory name:")]
        public string Name { get; set; }

        [Display(Name = "Accessory for:")]
        public InstrumentClassification.InstrumentType InstrumentAssociated { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Display(Name = "Qauntity in stock:")]
        public int Quantity { get; set; }

        [Display(Name = "Cost:")]
        public decimal Price { get; set; }

        public string Description { get; set; }

    }
}
