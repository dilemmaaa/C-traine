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
        public IEnumerable<Smartphone> Get() => _smartphones;

        // GET /smartphones/1
        [HttpGet("{id}")]
        public ActionResult<Smartphone> Get(int id)
        {
            var phone = _smartphones.FirstOrDefault(p => p.Id == id);
            return phone == null ? NotFound() : phone;
        }

        // POST /smartphones
        [HttpPost]
        public ActionResult<Smartphone> Post(Smartphone phone)
        {
            phone.Id = _smartphones.Max(p => p.Id) + 1;
            _smartphones.Add(phone);
            return CreatedAtAction(nameof(Get), new { id = phone.Id }, phone);
        }

        // PUT /smartphones/1
        [HttpPut("{id}")]
        public ActionResult<Smartphone> Put(int id, Smartphone updatedPhone)
        {
            var phone = _smartphones.FirstOrDefault(p => p.Id == id);
            if (phone == null) return NotFound();

            phone.Model = updatedPhone.Model;
            phone.Manufacturer = updatedPhone.Manufacturer;
            phone.PriceRUB = updatedPhone.PriceRUB;
            phone.StorageGB = updatedPhone.StorageGB;
            phone.Has5G = updatedPhone.Has5G;
            phone.ReleaseDate = updatedPhone.ReleaseDate;

            return phone;
        }

        // DELETE /smartphones/1
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var phone = _smartphones.FirstOrDefault(p => p.Id == id);
            if (phone == null) return false;

            return _smartphones.Remove(phone);
        }
    }
}