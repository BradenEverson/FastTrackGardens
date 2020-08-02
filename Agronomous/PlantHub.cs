using Agronomous.Core;
using Agronomous.Database;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agronomous
{
    public class PlantHub : Hub
    {
        private readonly IPlantData plantData;
        public PlantHub(IPlantData plantData)
        {
            this.plantData = plantData;
        }
        public async Task ReceivePlant(string bname, string planttype, string sunexposure, string soiltype, string soilph, string bloomtime, string flowercolor, string hardinesszones, string plantGuid)
        {
            plant currentPlant = new plant();
            currentPlant.botanicalName = bname;
            currentPlant.PlantType = planttype;
            currentPlant.SunExposure = sunexposure;
            currentPlant.SoilType = soiltype;
            currentPlant.SoilPh = soilph;
            currentPlant.BloomTime = bloomtime;
            currentPlant.FlowerColor = flowercolor;
            currentPlant.HardinessZones = hardinesszones;
            currentPlant.gardenGuid = plantGuid;
            plantData.add(currentPlant);
            await Clients.Caller.SendAsync("ReceiveMessage","all good chief");
        }
    }
}
