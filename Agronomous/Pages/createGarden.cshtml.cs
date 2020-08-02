using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agronomous.Data;
using Agronomous.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agronomous
{
    public class createGardenModel : PageModel
    {
        private readonly ApplicationDbContext db;
        private readonly IPlantData plants;
        public createGardenModel(ApplicationDbContext db, IPlantData plants)
        {
            this.db = db;
            this.plants = plants;
        }
        public void OnGet()
        {
            Console.WriteLine(db.Users.FirstOrDefault(r => r.UserName == User.Identity.Name).plantGuid);
        }
        public IActionResult OnPost()
        {

            return Redirect("/garden");
        }
    }
}