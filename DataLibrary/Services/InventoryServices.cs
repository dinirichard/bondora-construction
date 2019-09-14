using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Services
{
    public class InventoryServices
    {

        public static List<InventoryModel> LoadInventory()
        {
            string sql = "select * from Inventory";

            return SqliteDataAccess.LoadData<InventoryModel>(sql);
        }
    }
}
