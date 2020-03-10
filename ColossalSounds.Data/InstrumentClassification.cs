using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColossalSounds.Data
{
    public class InstrumentClassification
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CategoryType {brass = 1, woodwind = 2, percussion = 3, strings = 4 }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum InstrumentType { trumpet = 1 , trombone = 2, tuba = 3, french_horn = 4, baritone = 5, sousaphone = 6, saxophone = 7, clarinet = 8, flute = 9, piccolo = 10, obeo = 11, basson = 12, guitar = 13, bass = 14, snare_drum = 15, drum_kit = 16, piano = 17, keyboard = 18, bells = 19, marimba = 20, xylophone = 21, cymbol = 22 }


        //Properties

        [Key]
        public int Id { get; set; }

        public CategoryType TypeOfCategory { get; set; }

        public InstrumentType TypeOfInstrument { get; set; }

        //public virtual ICollection<Instrument> Instruments { get; set; }



        public InstrumentClassification() { }

        public InstrumentClassification(CategoryType typeOfCategory, InstrumentType typeOfInstrument)
        {
           TypeOfCategory = typeOfCategory;
            TypeOfInstrument = typeOfInstrument; 
        } 

    }

    public class EnumContents
    {
        public string enumName { get; set; }
        public int enumNumber { get; set; }
    }
}
