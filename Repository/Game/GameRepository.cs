using mcq_backend.Helper.Context;

namespace mcq_backend.Repository.Game
{
    public class GameRepository : GenericRepository<Model.Game>, IGameRepository
    {
        public GameRepository(DBContext context) : base(context)
        {
        }
    }
}