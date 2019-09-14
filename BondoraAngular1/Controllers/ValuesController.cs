using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BondoraAngular1.Models;
using Microsoft.AspNetCore.Mvc;
using DataLibrary.Services;

namespace BondoraAngular1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        //[HttpGet]
        //public ActionResult<List<InventoryModel>> Get()
        //{
        //    var priceData = InventoryServices.LoadInventory();
        //    List<InventoryModel> inventory = new List<InventoryModel>();

        //    foreach (var row in priceData)
        //    {
        //        inventory.Add(new InventoryModel
        //        {
        //            Id = row.Id,
        //            Name = row.Name,
        //            Type = row.Type,
        //            RentDays = row.RentDays
        //        });
        //    }

        //    return inventory;
        //}

        //// GET api/invent
        //[HttpGet]
        //public ActionResult<List<InventoryModel>> GetInvent()
        //{
        //    var priceData = InventoryServices.LoadInventory();
        //    List<InventoryModel> inventory = new List<InventoryModel>();

        //    foreach (var row in priceData)
        //    {
        //        inventory.Add(new InventoryModel
        //        {
        //            Id = row.Id,
        //            Name = row.Name,
        //            Type = row.Type,
        //            RentDays = row.RentDays
        //        });
        //    }

        //    return inventory;
        //}

        

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
