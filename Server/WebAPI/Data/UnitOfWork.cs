namespace WebAPI.Data
{
    using System.Threading.Tasks;

    using Interfaces;
    using WebAPI.Data.Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public ICityRepository cityRepository => 
            new CityRepository(dataContext);

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
