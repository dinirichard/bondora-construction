using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BondoraAngular1.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }

        public int TotalPrice { get; set; }

        public int BonusPoints { get; set; }

        public string PurchaseDate { get; set; }

        public int UserId { get; set; }

        public List<InventoryModel> Inventories { get; set; }

    }
}
