using C_trainee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace C_trainee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartphonesController : ControllerBase
    {
        private static List<Smartphone> _smartphones = new()
        {
            new Smartphone
            {
                Id = 1,
                Model = "Galaxy S23",
                Manufacturer = "Samsung",
                PriceRUB = 89990.00m,  // Цена в рублях
                StorageGB = 256,
                Has5G = true,
                ReleaseDate = new DateTime(2023, 2, 1)
            },
            new Smartphone
            {
                Id = 2,
                Model = "iPhone 15",
                Manufacturer = "Apple",
                PriceRUB = 99990.00m,  // Цена в рублях
                StorageGB = 128,
                Has5G = true,
                ReleaseDate = new DateTime(2023, 9, 1)
            }
        };

        // GET /smartphones
        [HttpGet]
        public IEnumerable<Smartphone> GetAll() => _smartphones;

        // GET /smartphones/1
        [HttpGet("{id:int}")]
        public ActionResult<Smartphone> GetById([FromRoute] int id)
        {
            var phone = _smartphones.FirstOrDefault(p => p.Id == id);
            return phone == null ? NotFound() : phone;
        }

        // POST /smartphones
        [HttpPost]
        public IActionResult Create([FromBody] CreateSmartphoneRequest request)
        {
            var phone = new Smartphone
            {
                Id = _smartphones.Max(p => p.Id) + 1,
                Model = request.Model,
                Manufacturer = request.Manufacturer,
                PriceRUB = request.PriceRUB,
                StorageGB = request.StorageGB,
                Has5G = request.Has5G,
                ReleaseDate = request.ReleaseDate
            };

            _smartphones.Add(phone);
            return Ok(new { Id = phone.Id });
        }

        // PUT /smartphones/1
        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Smartphone smartphone)
        {
            var phone = _smartphones.FirstOrDefault(p => p.Id == id);
            if (phone == null) return NotFound();

            phone.Model = smartphone.Model;
            phone.Manufacturer = smartphone.Manufacturer;
            phone.PriceRUB = smartphone.PriceRUB;
            phone.StorageGB = smartphone.StorageGB;
            phone.Has5G = smartphone.Has5G;
            phone.ReleaseDate = smartphone.ReleaseDate;

            return NoContent();
        }

        // DELETE /smartphones/1
        [HttpDelete("{id:int}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var phone = _smartphones.FirstOrDefault(p => p.Id == id);
            if (phone == null) return NotFound();

            var isSmartphoneDeleted = _smartphones.Remove(phone);
            return isSmartphoneDeleted ? NoContent() : NotFound();
        }
    }

    public class CreateSmartphoneRequest
    {
        public required string Model { get; set; }
        public required string Manufacturer { get; set; }
        public decimal PriceRUB { get; set; }
        public int StorageGB { get; set; }
        public bool Has5G { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}