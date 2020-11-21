namespace WebAPI.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Models;
    using Interfaces;

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
            var city = this.dataContext.Cities.Find(cityId);
            this.dataContext.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await this.dataContext.Cities.ToListAsync();
        }
    }
}
