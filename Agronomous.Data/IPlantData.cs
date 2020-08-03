using Agronomous.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agronomous.Database
{
    public interface IPlantData
    {
        public plant add(plant plant);
        public plant delete(Guid id);
        public plant update(plant updatedPlant);
        public plant getById(Guid id);
        public int commit();
        public List<plant> aggregateGarden(Guid gardenGuid);
    }
}
