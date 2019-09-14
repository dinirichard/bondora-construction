﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class InventoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int RentDays { get; set; }
    }
}
