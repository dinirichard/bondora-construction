using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BondoraAngular1.Models
{
    public class InventoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int RentDays { get; set; }

        public int Cost { get; set; }
    }
}
