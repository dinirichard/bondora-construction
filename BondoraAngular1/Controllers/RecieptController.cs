using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BondoraAngular1.Models;
using BondoraAngular1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BondoraAngular1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecieptController : ControllerBase
    {
        
        List<InvoiceModel> invoices = new List<InvoiceModel>();

        private readonly InvoiceServices _invoiceServices;


        public RecieptController(IOptions<InvoiceServices> invoiceServices)
        {
            this._invoiceServices = invoiceServices.Value;
        }

        // GET: api/Reciept
        [HttpGet("{id}")]
        public async Task<Object> Get(int id)
        { 

            List<InvoiceModel> list = invoices;

            foreach (InvoiceModel voice in invoices)
            {
                if (voice.Id.Equals(id))
                {
                    return new
                    {
                        voice.Id,
                        voice.BonusPoints,
                        voice.TotalPrice,
                        voice.PurchaseDate,
                        voice.UserId,
                        voice.Inventories
                    };
                }
            }

            var invoice = invoices.FirstOrDefault(s => s.Id == id);

            return new
            {
                invoice.Id,
                invoice.BonusPoints,
                invoice.TotalPrice,
                invoice.PurchaseDate,
                invoice.UserId,
                invoice.Inventories
            };
        }

        // POST: api/
        [AllowAnonymous]
        [Route("post")]
        [HttpPost]
        public async Task<Object> Post(dynamic model)
        {
            InvoiceModel c = JsonConvert.DeserializeObject<InvoiceModel>(model.ToString());

            InvoiceModel reciept = _invoiceServices.Calculate(c);
            
            invoices.Add(reciept);

            List<InvoiceModel> list = invoices;

            using (StreamWriter writer = new StreamWriter($"{reciept.Id}_invoice.txt"))
            {
                writer.WriteLine($"\t INVOICE #{reciept.Id} ");
                writer.WriteLine();
                writer.WriteLine($"Bonus Point = {reciept.BonusPoints}. ");
                writer.WriteLine();
                writer.WriteLine($@"\t---------Products Rented---------");
                writer.WriteLine();
                foreach (InventoryModel product in reciept.Inventories)
                {
                    writer.WriteLine($@"{product.Name}          {product.RentDays} days             ${product.Cost}.00 ");
                }

                writer.WriteLine();
                writer.WriteLine();
                writer.WriteLine($"\t Total \t : \t${reciept.TotalPrice}.00");

            }
                                        
            return new
            {
                reciept.Id,
                reciept.BonusPoints,
                reciept.TotalPrice,
                reciept.PurchaseDate,
                reciept.UserId,
                reciept.Inventories
            };            
        }

        
    }
}
