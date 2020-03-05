using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Models.AccessoryModels
{
    public class AccessoryCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }

        //[Required]
        //[MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        //[MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        //public InstrumentType InstrumentAssociated { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Brand { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(500, ErrorMessage = "There are too many characters in this field.")]
        public string Description { get; set; }
    }
}
