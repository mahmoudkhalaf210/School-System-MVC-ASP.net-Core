﻿using Microsoft.AspNetCore.Identity;

namespace Day2.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string address { get; set; }
    }
}
