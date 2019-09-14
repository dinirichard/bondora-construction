using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BondoraAngular1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BondoraAngular1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        List<InventoryModel> inventories = new List<InventoryModel>();

        public InventoryController()
        {
            inventories.Add(new InventoryModel { Id = 1, Name = "Caterpillar bulldozer", Type = "Heavy" });
            inventories.Add(new InventoryModel { Id = 2, Name = "KamAZ truck", Type = "Regular" });
            inventories.Add(new InventoryModel { Id = 3, Name = "Komatsu crane", Type = "Heavy" });
            inventories.Add(new InventoryModel { Id = 4, Name = "Komatsu crane", Type = "Regular" });
            inventories.Add(new InventoryModel { Id = 5, Name = "Bosch jackhammer", Type = "Specialized" });
        }
        

        // GET: api/Inventory
        [HttpGet]
        public List<InventoryModel> Get()
        {
            return inventories;
        }

        [Route("getInventories")]
        [HttpGet]
        public List<InventoryModel> GetInventories()
        {
            return inventories;
        }

        //// GET: api/Inventory/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Inventory
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
