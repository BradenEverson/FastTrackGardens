using System;
using System.Collections.Generic;
using System.Text;

namespace Agronomous.Core
{
    public enum plantType
    {
        vegetable,
        fruit,
        herb,
        bulb,
        flower,
        foliage,
        shrub,
        houseplant
    }
    public enum sunExposure
    {
        Full,
        half,
        none,
        unknown
    }
    public enum soilType
    {
        sandy,

    }
    public enum ph
    {
        acidic,
        slightlyAcidic,
        neutral,
        slightlyBasic,
        basic
    }
    public enum bloomTime
    {
        spring,
        summer,
        fall,
        winter
    }
    public class plant
    {
        public int id { get; set; }
        public string name { get; set; }
        public int moisture { get; set; }
        public plantType plantType { get; set; }
        public sunExposure sunExposure { get; set; }
        public soilType soilType { get; set; }
        public ph ph { get; set; }
        public bloomTime bloomTime { get; set; }
        public garden parentGarden { get; set; }
    }
}
