namespace WebAPI.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Models;
    public class CityRepository : ICityRepository
    {
        private readonly DataContext dataContext;

        public CityRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddCity(City city)
        {
            this.dataContext.Cities.AddAsync(city);
        }

        public void DeleteCity(int cityId)
        {
            var city = this.dataContext.Cities.FindAsync(cityId);
            this.dataContext.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await this.dataContext.Cities.ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await this.dataContext.SaveChangesAsync() > 0;
        }
    }
}
