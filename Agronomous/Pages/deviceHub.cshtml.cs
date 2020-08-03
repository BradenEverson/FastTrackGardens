using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agronomous.Core;
using Agronomous.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agronomous
{
    public class deviceHubModel : PageModel
    {
        public IPlantData plants { get; set; }
        public plant hardwarePlant { get; set; }
        public deviceHubModel(IPlantData plants)
        {
            this.plants = plants;
        }
        public void OnGet(string hardwareGuid)
        {
            Console.WriteLine("Id: " + hardwareGuid);
            hardwarePlant = plants.getByHardwareId(hardwareGuid);
        }
    }
}