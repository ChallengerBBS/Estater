namespace WebAPI.Interfaces
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }

        IUserRepository UserRepository { get; }

        Task<bool> SaveAsync();
    }
}
