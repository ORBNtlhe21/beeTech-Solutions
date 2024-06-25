﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace beeTechSolutions_API_.Models
{
    public class Gaming_Console
    {
        [Key]
        public int gamingConsole_id { get; set; }

        public string gamingConsoleBrand { get; set; } = String.Empty;

        public decimal price { get; set; }
    }
}