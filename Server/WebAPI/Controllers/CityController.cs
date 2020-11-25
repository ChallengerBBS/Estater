namespace WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Interfaces;
    using Dtos;
    using WebAPI.Models;

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

            var citiesDto = from c in cities
                            select new CityDto()
                            {
                                Id = c.Id,
                                Name = c.Name
                            };

            return this.Ok(citiesDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = new City
            {
                Name = cityDto.Name,
                LastUpdatedBy = 1,
                LastUpdatedOn = DateTime.Now
            };

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
