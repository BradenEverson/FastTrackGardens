using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agronomous.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agronomous
{
    public class createGardenModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public createGardenModel(ApplicationDbContext db)
        {
            this.db = db;
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