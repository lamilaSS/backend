using System.Threading.Tasks;

namespace mcq_backend.Repository
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
    }
}