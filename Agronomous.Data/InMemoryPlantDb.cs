using Agronomous.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agronomous.Data
{
    public class InMemoryPlantDb : IPlantData
    {
        private readonly List<plant> plantMemory;
        public InMemoryPlantDb()
        {
            plantMemory = new List<plant>();
        }
        public plant add(plant plant)
        {
            plantMemory.Add(plant);
            return plant;
        }

        public List<plant> aggregateGarden(Guid gardenGuid)
        {
            List<plant> garden = plantMemory.Where(r => r.gardenGuid == gardenGuid).Cast<plant>().ToList();
            return (garden != null) ? garden : null;
        }

        public int commit()
        {
            return 0;
        }

        public plant delete(int id)
        {
            var deletedPlant = plantMemory.FirstOrDefault(r => r.id == id);
            if(deletedPlant != null)
            {
                plantMemory.Remove(deletedPlant);
            }
            return deletedPlant;
        }

        public plant getById(int id)
        {
            var plant = plantMemory.FirstOrDefault(r => r.id == id);
            if(plant != null)
            {
                return plant;
            }
            else
            {
                return null;
            }
        }

        public plant update(plant updatedPlant)
        {
            var plant = plantMemory.FirstOrDefault(r => r.id == updatedPlant.id);
            if(plant != null)
            {
                plant.soilType = updatedPlant.soilType;
                plant.sunExposure = updatedPlant.sunExposure;
                plant.ph = updatedPlant.ph;
            }
            return plant;
        }
    }
}
