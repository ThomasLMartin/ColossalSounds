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
        public enum InstrumentType { trumpet = 1 , trombone = 2, tuba = 3, french_horn = 4, baritone = 5, sousaphone = 6, soprano_saxophone = 7, alto_saxophone = 8, tenor_saxophone = 9, baritone_saxophone = 10, clarinet = 11, bass_clarinet = 12, flute = 13, piccolo = 14, obeo = 15, basson = 16, acoustic_guitar = 17, electric_guitar = 18, electric_bass = 19, standup_bass = 20,  snare_drum = 21, drum_Kit = 22, piano = 23, keyboard = 24, bells = 25, marimba = 26, xylophone = 27, cymbol = 28 }


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
