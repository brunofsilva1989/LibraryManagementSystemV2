﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.DTOs
{
    public class UserDto
    {
       public string CPF { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }        
        public string Role { get; set; }
    }
}
