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
    public class addDeviceModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string modelNumber { get; set; }
        public plant userPlant { get; set; }
        public readonly IPlantData plants;
        public addDeviceModel(IPlantData plants)
        {
            this.plants = plants;
        }
        public IActionResult OnGet(Guid PlantId)
        {
            userPlant = plants.getById(PlantId);
            if(userPlant == null)
            {
                return Redirect("./error");
            }
            if (!string.IsNullOrEmpty(modelNumber))
            {
                userPlant.hardwareGuid = modelNumber;
                Console.WriteLine("Hardware id: " + userPlant.hardwareGuid);;
                Console.WriteLine(plants.update(userPlant).hardwareGuid);
                Console.WriteLine(plants.getByHardwareId(modelNumber).hardwareGuid);
            }
            return Page();
        }
    }
}