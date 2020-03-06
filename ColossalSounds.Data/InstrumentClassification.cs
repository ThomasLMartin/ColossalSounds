using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CategoryType {Brass = 1, Woodwind = 2, Percussion = 3, Strings = 4 }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum InstrumentType { Trumpet = 1 , Trombone = 2, Tuba = 3, French_Horn = 4, Baritone = 5, Sousaphone = 6, Soprano_Saxophone = 7, Alto_Saxophone = 8, Tenor_Saxophone = 9, Baritone_Saxophone = 10, Clarinet = 11, Bass_Clarinet = 12, Flute = 13, Piccolo = 14, Obeo = 15, Basson = 16, Acoustic_Guitar = 17, Electric_Guitar = 18, Electric_Bass = 19, StandUp_Bass = 20,  Snare_Drum = 21, Drum_Kit = 22, Piano = 23, Keyboard = 24, Bells = 25, Marimba = 26, Xylophone = 27, Cymbol = 28 }


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

    public class EnumContents
    {
        public string enumName { get; set; }
        public int enumNumber { get; set; }
    }
}
