using mcq_backend.Helper.Context;

namespace mcq_backend.Repository.Answer
{
    public class AnswerRepository : GenericRepository<Model.Answer>, IAnswerRepository
    {
        public AnswerRepository(DBContext context) : base(context)
        {
        }
    }
}