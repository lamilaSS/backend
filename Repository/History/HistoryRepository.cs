using mcq_backend.Helper.Context;

namespace mcq_backend.Repository.History
{
    public class HistoryRepository : GenericRepository<Model.History>, IHistoryRepository
    {
        public HistoryRepository(DBContext context) : base(context)
        {
        }
    }
}