using ColossalSounds.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Models.InstrumentModel
{
    public class InstrumentCreate
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public ExperienceLevel ExpLvl { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ClassificationId { get; set; }
    }
}
