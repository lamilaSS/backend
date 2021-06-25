using System.Threading.Tasks;
using mcq_backend.Dataset.User;

namespace mcq_backend.Service.User
{
    public interface IUserService
    {
        Task<UserDataset> GetById(string userId);
        Task<UserDataset> UpdateUser(string userId, UserUpdateDataset userUpdateDataset);
        
    }
}