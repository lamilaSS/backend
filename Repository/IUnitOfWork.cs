using System.Threading.Tasks;
using mcq_backend.Repository.Answer;
using mcq_backend.Repository.Game;
using mcq_backend.Repository.GameQuestion;
using mcq_backend.Repository.History;
using mcq_backend.Repository.Lifeline;
using mcq_backend.Repository.Question;
using mcq_backend.Repository.ScoreDetail;
using mcq_backend.Repository.User;

namespace mcq_backend.Repository
{
    public interface IUnitOfWork
    {
        IAnswerRepository AnswerRepository { get; }
        IGameRepository GameRepository { get; }
        IGameQuestionRepository GameQuestionRepository { get; }
        IHistoryRepository HistoryRepository { get; }
        ILifelineRepository LifelineRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IScoreDetailRepository ScoreDetailRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveAsync();
    }
}