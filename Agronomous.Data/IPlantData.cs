using Agronomous.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agronomous.Data
{
    public interface IPlantData
    {
        public plant add(plant plant);
        public plant delete(int id);
        public plant update(plant updatedPlant);
        public plant getById(int id);
        public int commit();
        public List<plant> aggregateGarden(Guid gardenGuid);
    }
}
