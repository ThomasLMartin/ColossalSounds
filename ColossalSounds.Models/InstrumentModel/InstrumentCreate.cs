﻿using ColossalSounds.Data;
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

        public string Name { get; set; }

        public string ModelName { get; set; }

        public string Brand { get; set; }

        public ExperienceLevel ExpLvl { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int ClassificationId { get; set; }
    }
}
