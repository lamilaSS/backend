using System;
using System.Threading.Tasks;
using mcq_backend.Helper.Context;
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
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext _context;
        private bool disposed = false;
        private IAnswerRepository _answerRepository;
        private IGameRepository _gameRepository;
        private IGameQuestionRepository _gameQuestionRepository;
        private IHistoryRepository _historyRepository;
        private ILifelineRepository _lifelineRepository;
        private IQuestionRepository _questionRepository;
        private IScoreDetailRepository _scoreDetailRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(DBContext context)
        {
            _context = context;
        }

        public IAnswerRepository AnswerRepository
        {
            get
            {
                return _answerRepository ??= new AnswerRepository(_context);
            }
        }

        public IGameRepository GameRepository
        {
            get
            {
                return _gameRepository ??= new GameRepository(_context);
            }
        }

        public IGameQuestionRepository GameQuestionRepository
        {
            get
            {
                return _gameQuestionRepository ??= new GameQuestionRepository(_context);
            }
        }

        public IHistoryRepository HistoryRepository { get
            {
                return _historyRepository ??= new HistoryRepository(_context);
            } }
        public ILifelineRepository LifelineRepository { get
            {
                return _lifelineRepository ??= new LifelineRepository(_context);
            } }
        public IQuestionRepository QuestionRepository { get
            {
                return _questionRepository ??= new QuestionRepository(_context);
            } }
        public IScoreDetailRepository ScoreDetailRepository { get
            {
                return _scoreDetailRepository ??= new ScoreDetailRepository(_context);
            } }
        public IUserRepository UserRepository { get
            {
                return _userRepository ??= new UserRepository(_context);
            } }

        public async Task<int> SaveAsync()
        {
            var resp = await _context.SaveChangesAsync();
            return resp;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}