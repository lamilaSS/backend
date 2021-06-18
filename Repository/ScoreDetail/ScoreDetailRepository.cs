using mcq_backend.Helper.Context;

namespace mcq_backend.Repository.ScoreDetail
{
    public class ScoreDetailRepository : GenericRepository<Model.ScoreDetail>, IScoreDetailRepository
    {
        public ScoreDetailRepository(DBContext context) : base(context)
        {
        }
    }
}