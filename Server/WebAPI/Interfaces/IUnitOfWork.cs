namespace WebAPI.Interfaces
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }

        Task<bool> SaveAsync();
    }
}
