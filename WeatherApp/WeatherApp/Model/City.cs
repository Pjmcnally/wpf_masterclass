﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    class City
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public Region Country { get; set; }
        public Region AdministrativeArea { get; set; }
    }


    public class Region
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }
}
