using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }

        public int TotalPrice { get; set; }

        public int BonusPoints { get; set; }

        public int PurchaseDate { get; set; }

        public int UserId { get; set; }

        public IList<InventoryModel> Products { get; set; }
    }
}
