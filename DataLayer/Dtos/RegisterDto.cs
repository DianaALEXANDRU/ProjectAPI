﻿using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos
{
    public class RegisterDto
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}
