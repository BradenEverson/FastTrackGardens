using System;
using System.Collections.Generic;
using System.Text;

namespace Agronomous.Core
{
    public class plant
    {
        public int id { get; set; }
        public string botanicalName { get; set; }
        public string PlantType { get; set; }
        public string SunExposure { get; set; }
        public string SoilType { get; set; }
        public string SoilPh { get; set; }
        public string BloomTime { get; set; }
        public string FlowerColor { get; set; }
        public string HardinessZones { get; set; }
        public string gardenGuid { get; set; }
    }
}
