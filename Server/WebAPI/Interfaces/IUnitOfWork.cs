namespace WebAPI.Interfaces
{
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        ICityRepository cityRepository { get; }

        Task<bool> SaveAsync();
    }
}
