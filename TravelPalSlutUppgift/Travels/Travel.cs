﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPalSlutUppgift.Enums;

namespace TravelPalSlutUppgift.Travels
{
    public class Travel
    {
        public string Destination { get; set; }
        public Countries Countrys { get; set; }
        public int Travelers { get; set; }

        public Travel()
        {
            // props
        }
    }
}