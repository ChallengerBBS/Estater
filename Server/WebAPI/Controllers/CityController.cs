namespace WebAPI.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Data.Repositories;
    using Models;
    using WebAPI.Interfaces;

    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CityController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await this.unitOfWork.cityRepository.GetCitiesAsync();
            return this.Ok(cities);
        }

        [HttpPost("add")]
        [HttpPost("add/{cityName}")]

        public async Task<IActionResult> AddCity(City city)
        {
            this.unitOfWork.cityRepository.AddCity(city);
            await this.unitOfWork.SaveAsync();
            return this.StatusCode(201);
        }

        [HttpDelete("delete/{cityId}")]

        public async Task<IActionResult> DeleteCity(int cityId)
        {
            this.unitOfWork.cityRepository.DeleteCity(cityId);
            await this.unitOfWork.SaveAsync();
            return this.Ok(cityId);
        }
    }
}
