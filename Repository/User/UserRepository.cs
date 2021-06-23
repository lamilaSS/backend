using mcq_backend.Helper.Context;

namespace mcq_backend.Repository.User
{
    public class UserRepository : GenericRepository<Model.User>, IUserRepository
    {
        public UserRepository(DBContext context) : base(context)
        {
        }
    }
}