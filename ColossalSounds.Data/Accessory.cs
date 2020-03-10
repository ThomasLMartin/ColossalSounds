using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Data
{
    public class Accessory
    {
        [Key]
        public int Id { get; set; }

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


      /* Do we need this???
       * public Accessory() { }
        public Accessory(string id, string name, InstrumentType instrumentAssociated, string brand, int quantity, decimal price, string description)
        {
            Id = id;
            Name = name;
            InstrumentType = instrumentAssociated;
            Brand = brand;
            Quantity = quantity;
            Price = price;
            Description = description;
        } */
    }
}
