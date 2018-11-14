using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication1.Models
{
    public class CustomizeUser:IdentityUser
    {
        [PersonalData]
        public string FullName { get; set; }
        [PersonalData]
        public string Address { get; set; }
        public object Role { get; internal set; }
    }
}
