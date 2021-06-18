using mcq_backend.Helper.Context;

namespace mcq_backend.Repository.Question
{
    public class QuestionRepository : GenericRepository<Model.Question>, IQuestionRepository
    {
        public QuestionRepository(DBContext context) : base(context)
        {
        }
    }
}