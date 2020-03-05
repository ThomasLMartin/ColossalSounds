using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Data
{
    public class InstrumentClassification
    {
        public enum CategoryType {Brass, Woodwind, Percussion, Strings }

        public enum InstrumentType { Trumpet, Trombone, Alto_Saxophone, Tenor_Saxophone, Soprano_Saxophone, Baritone_Saxophone, Clarinet, Bass_Clarinet, Acoustic_Guitar, Electric_Guitar, Electric_Bass, StandUp_Bass, Flute, Piccolo, Snare_Drum, Drum_Kit, Piano, Keyboard, Obeo, Basson, French_Horn, Baritone, Tuba, Sousaphone, Bells, Marimba, Xylophone, Cymbol, }


        //Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public CategoryType TypeOfCategory { get; set; }

        [Required]
        public InstrumentType TypeOfInstrument { get; set; }


        public InstrumentClassification() { }

        public InstrumentClassification(CategoryType typeOfCategory, InstrumentType typeOfInstrument)
        {
           TypeOfCategory = typeOfCategory;
            TypeOfInstrument = typeOfInstrument; 
        } 

    }
}
