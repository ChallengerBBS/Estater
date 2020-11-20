namespace WebAPI.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Data;
    using Microsoft.EntityFrameworkCore;
    using WebAPI.Models;

    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly DataContext dbContext;

        public CityController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await this.dbContext.Cities.ToListAsync();
            return this.Ok(cities);
        }

        [HttpPost("add")]
        [HttpPost("add/{cityName}")]

        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
           await this.dbContext.AddAsync(city);
           await this.dbContext.SaveChangesAsync();
            return this.Ok(city);
        }

        [HttpDelete("delete/{cityId}")]

        public async Task<IActionResult> DeleteCity(int cityId)
        {
            var city = await this.dbContext.Cities.FindAsync(cityId);
            this.dbContext.Remove(city);
            await this.dbContext.SaveChangesAsync();
            return this.Ok(cityId);
        }
    }
}
