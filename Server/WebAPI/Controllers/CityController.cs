namespace WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Interfaces;
    using Dtos;
    using Models;

    [Authorize]
    public class CityController : BaseController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCities()
        {
            var cities = await this.unitOfWork.CityRepository.GetCitiesAsync();
            var citiesDto = this.mapper.Map<IEnumerable<CityDto>>(cities);

            return this.Ok(citiesDto);

        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {

            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;
            this.unitOfWork.CityRepository.AddCity(city);
            await unitOfWork.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            if (id != cityDto.Id)
            {
                return this.BadRequest("Update failed.");

            }

            var city = await this.unitOfWork.CityRepository.FindCity(id);
            if (city == null)
            {
                return this.BadRequest("Update failed.");
            }
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, city);
            await this.unitOfWork.SaveAsync();
            return this.StatusCode(200);
        }


        [HttpDelete("delete/{cityId}")]

        public async Task<IActionResult> DeleteCity(int cityId)
        {
            this.unitOfWork.CityRepository.DeleteCity(cityId);
            await this.unitOfWork.SaveAsync();
            return this.Ok(cityId);
        }
    }
}