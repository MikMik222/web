﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ney_Nemovitost.web.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]

        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool LoginFailed { get; set; }
    }
}
