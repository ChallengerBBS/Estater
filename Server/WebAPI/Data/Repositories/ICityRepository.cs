namespace WebAPI.Data.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models;
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();

        void AddCity(City city);

        void DeleteCity(int cityId);

        Task<bool> SaveAsync();
    }
}
