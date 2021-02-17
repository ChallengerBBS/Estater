namespace WebAPI.Interfaces
{   
    using System.Threading.Tasks;

    using Models;

    public interface IUserRepository
    {
        Task<User> Authenticate(string userName, string password);

        void Register(string userName, string password);

        Task<bool> UserAlreadyExists(string userName);
    }
}
