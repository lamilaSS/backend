using mcq_backend.Helper.Context;

namespace mcq_backend.Repository.Lifeline
{
    public class LifelineRepository : GenericRepository<Model.Lifeline>, ILifelineRepository
    {
        public LifelineRepository(DBContext context) : base(context)
        {
        }
    }
}