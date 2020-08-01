using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agronomous
{
    public class user : IdentityUser
    {
        public Guid plantGuid { get; set; }
    }
}
