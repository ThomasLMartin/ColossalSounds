using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Data
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        [ForeignKey(nameof(Instrument))]
        public int? InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set; }
        [ForeignKey(nameof(Accessory))]
        public int? AccessoryId { get; set; }
        public virtual Accessory Accessory { get; set; }
    }
}
