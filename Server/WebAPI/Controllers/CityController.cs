namespace WebAPI.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Data.Repositories;
    using Models;

    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly ICityRepository cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await this.cityRepository.GetCitiesAsync();
            return this.Ok(cities);
        }

        [HttpPost("add")]
        [HttpPost("add/{cityName}")]

        public async Task<IActionResult> AddCity(City city)
        {
            this.cityRepository.AddCity(city);
            await this.cityRepository.SaveAsync();
            return this.StatusCode(201);
        }

        [HttpDelete("delete/{cityId}")]

        public async Task<IActionResult> DeleteCity(int cityId)
        {
            this.cityRepository.DeleteCity(cityId);
            await this.cityRepository.SaveAsync();
            return this.Ok(cityId);
        }
    }
}
