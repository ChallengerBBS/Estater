namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using Interfaces;
    using Dtos;
    using Models;

    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await this.unitOfWork.cityRepository.GetCitiesAsync();
            var citiesDto = this.mapper.Map<IEnumerable<City>>(cities);

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
