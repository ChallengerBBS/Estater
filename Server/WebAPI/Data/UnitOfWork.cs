namespace WebAPI.Data
{
    using System.Threading.Tasks;

    using Interfaces;
    using WebAPI.Data.Repositories;
    using WebAPI.Models;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public ICityRepository CityRepository => 
            new CityRepository(dataContext);

        public IUserRepository UserRepository => new UserRepository(dataContext);

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<bool> SaveAsync()
        {
           return await this.dataContext.SaveChangesAsync()>0;
        }
    }
}
