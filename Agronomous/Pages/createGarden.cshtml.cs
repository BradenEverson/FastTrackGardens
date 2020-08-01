using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agronomous
{
    public class createGardenModel : PageModel
    {
        Guid userGuid;
        public void OnGet()
        {
            userGuid = User.editGardenGuid();
        }
        public IActionResult OnPost()
        {

            return Redirect("/garden");
        }
    }
}