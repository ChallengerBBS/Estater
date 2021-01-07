namespace WebAPI.Interfaces
{   
    using System.Threading.Tasks;

    using WebAPI.Models;

    public interface IUserRepository
    {
        Task<User> Authenticate(string user, string password);
    }
}
