using BondoraAngular1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BondoraAngular1.Services
{
    public class InvoiceServices
    {

        public InvoiceModel Calculate(InvoiceModel Invoice)
        {
            List<InventoryModel> products = Invoice.Inventories;
            int cost = 0;
            int bonus = 0;

            foreach(InventoryModel product in products)
            {
                if (product.Type.Equals("Heavy"))
                {
                    cost += Heavy(product);
                    bonus += 2;
                }
                if (product.Type.Equals("Regular"))
                {
                    cost += Regular(product);
                    bonus += 1;
                }
                if (product.Type.Equals("Specialized"))
                {
                    cost += Specialized(product);
                    bonus += 1;
                }
            }

            Invoice.TotalPrice = cost;
            Invoice.BonusPoints = bonus;

            return Invoice;
        }


        public int Heavy(InventoryModel product)
        {
            int cost = 100;
            cost += product.RentDays * 60;

            product.Cost = cost;
            return cost;
        }

        public int Regular(InventoryModel product)
        {
            int cost = 100;
            int RentDays = product.RentDays;

            if( RentDays > 2)
            {
                cost += 120;
                RentDays -= 2;
            }
            else
            {
                cost += RentDays * 60;
                RentDays -= RentDays;
            }

            if(RentDays > 0)
            {
                cost += RentDays * 40;
            }

            product.Cost = cost;
            return cost;
        }

        public int Specialized(InventoryModel product)
        {
            int cost = 0;
            int RentDays = product.RentDays;

            if (RentDays > 3)
            {
                cost += 60;
                RentDays -= 3;
            }
            else
            {
                cost += RentDays * 60;
                RentDays -= RentDays;
            }

            if (RentDays > 0)
            {
                cost += RentDays * 40;
            }

            product.Cost = cost;
            return cost;
        }

    }
}
