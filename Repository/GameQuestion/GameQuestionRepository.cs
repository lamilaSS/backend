using mcq_backend.Helper.Context;

namespace mcq_backend.Repository.GameQuestion
{
    public class GameQuestionRepository : GenericRepository<Model.GameQuestion>, IGameQuestionRepository
    {
        public GameQuestionRepository(DBContext context) : base(context)
        {
        }
    }
}