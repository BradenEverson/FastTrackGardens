using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agronomous.Core;
using Agronomous.Data;
using Agronomous.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agronomous
{
    public class gardenModel : PageModel
    {
        private readonly IPlantData plants;
        private readonly ApplicationDbContext db;
        public List<plant> userGarden;
        public gardenModel(IPlantData plants, ApplicationDbContext db)
        {
            this.plants = plants;
            this.db = db;
        }
        public void OnGet()
        {
            userGarden = plants.aggregateGarden(Guid.Parse(db.Users.FirstOrDefault(r => r.UserName == User.Identity.Name).plantGuid));
        }
        public IActionResult OnPost()
        {
            return Redirect("/createGarden");
        }
    }
}