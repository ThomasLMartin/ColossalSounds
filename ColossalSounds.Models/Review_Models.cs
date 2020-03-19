using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Models
{
    public class ReviewCreate
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int? AccessoryId { get; set; }
        public int? InstrumentId { get; set; }
    }
    public class ReviewListItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
    public class ReviewEdit
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int Id { get; set; }
    }
}
