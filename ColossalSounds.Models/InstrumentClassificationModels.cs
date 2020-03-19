using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColossalSounds.Data.InstrumentClassification;

namespace ColossalSounds.Models
{
    public class InstrumentClassificationCreate
    {
      
        [Required]
        public CategoryType TypeOfCategory { get; set; }

        [Required]
        public InstrumentType TypeOfInstrument { get; set; }

    }

    public class InstrumentClassificationDetail
    {
   
        public CategoryType TypeOfCategory { get; set; }
        
        public InstrumentType TypeOfInstrument { get; set; }
    }

    public class InstrumentClassificationEdit
    {
        public int ClassificationId { get; set; }

        public CategoryType TypeOfCategory { get; set; }

        public InstrumentType TypeOfInstrument { get; set; }

    }

    public class InstrumentClassificationListItem
    
    {
        public int ClassificationId { get; set; }

        public CategoryType TypeOfCategory { get; set; }

        public InstrumentType TypeOfInstrument { get; set; }

    }

}
