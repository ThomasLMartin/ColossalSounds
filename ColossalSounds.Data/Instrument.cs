﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ColossalSounds.Data.InstrumentClassification;

namespace ColossalSounds.Data
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ExperienceLevel { Beginner = 1, Intermediate = 2, Expert = 3 }
    public class Instrument
    {
        [Key]
        public int InstrumentId { get; set; }

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

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(InstrumentClassification))]
        public int ClassificationId { get; set; }
        public virtual InstrumentClassification InstrumentClassification { get; set; }

        public double AverageRating { get; set; }

    }
}
