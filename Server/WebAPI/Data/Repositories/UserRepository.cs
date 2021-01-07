namespace WebAPI.Data.Repositories
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using WebAPI.Interfaces;
    using WebAPI.Models;

    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await this.dataContext
                            .Users
                            .FirstOrDefaultAsync(x => x.Username == username 
                                           && x.Password == password);


        }
    }
}
