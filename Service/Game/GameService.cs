using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using mcq_backend.Dataset.Game;
using mcq_backend.Dataset.Question;
using mcq_backend.Helper.Context;
using mcq_backend.Helper.Exception;
using mcq_backend.Model;
using mcq_backend.Model.Keyless;
using mcq_backend.Repository;
using mcq_backend.Repository.Game;
using mcq_backend.Repository.Question;
using Microsoft.EntityFrameworkCore;

namespace mcq_backend.Service.Game
{
    public class GameService : IGameService
    {
        private const int NO_OF_ALTP_QUESTIONS = 15;
        private const int NO_OF_EASY_ALTP_QUESTIONS = 5;
        private const int NO_OF_MEDIUM_ALTP_QUESTIONS = 5;
        private const int NO_OF_HARD_ALTP_QUESTIONS = 5;

        private readonly IMapper _mapper;
        private readonly DBContext _ctx;
        private IGenericRepository<QuestionKeyless> _questionKeyless;
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper, DBContext ctx)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _ctx = ctx;
            _questionKeyless = new GenericRepository<QuestionKeyless>(_ctx);
        }

        public async Task<AiLaTyPhuGameDataset> CreateALTPGameSession(string userId)
        {
            if (_unitOfWork.QuestionRepository.GetTotalCount() < 15)
                throw new CommonException(
                    $"Not enough {NO_OF_ALTP_QUESTIONS} questions in database to create new \"Ai la ty phu\" game session!");
            
            Model.Game game = new Model.Game()
            {
                GameDescription = "This is ai la ty phu game",
                Status = 1,
            };
            //load 5 questions for each difficulties
            var easyLoadedQuestions = _questionKeyless.RawSelect(altpQuestionQueryBuilder(QuestionDifficulty.EASY));
            if (easyLoadedQuestions.Count < NO_OF_EASY_ALTP_QUESTIONS)
                throw new CommonException(
                    $"Not enough {NO_OF_EASY_ALTP_QUESTIONS} easy questions to build question pack for the game");
            
            var mediumLoadedQuestions = _questionKeyless.RawSelect(altpQuestionQueryBuilder(QuestionDifficulty.MEDIUM));
            if (mediumLoadedQuestions.Count < NO_OF_MEDIUM_ALTP_QUESTIONS)
                throw new CommonException(
                    $"Not enough {NO_OF_MEDIUM_ALTP_QUESTIONS} medium questions to build question pack for the game");
            
            var hardLoadedQuestions = _questionKeyless.RawSelect(altpQuestionQueryBuilder(QuestionDifficulty.HARD));
            if (hardLoadedQuestions.Count < NO_OF_HARD_ALTP_QUESTIONS)
                throw new CommonException(
                    $"Not enough {NO_OF_HARD_ALTP_QUESTIONS} hard questions to build question pack for the game");
            //load answers
            ICollection<Model.Question> easyQuestions = _mapper.Map<List<Model.Question>>(easyLoadedQuestions);
            ICollection<Model.Question> mediumQuestions = _mapper.Map<List<Model.Question>>(mediumLoadedQuestions);
            ICollection<Model.Question> hardQuestions = _mapper.Map<List<Model.Question>>(hardLoadedQuestions);
            ICollection<Model.Question> questions = easyQuestions.Concat(mediumQuestions).Concat(hardQuestions).ToList();

            foreach (var question in questions)
            {
                var answers = await _unitOfWork.AnswerRepository.Get(a => a.QuestionId.Equals(question.QuestionId));
                question.Answers = answers;
            }

            //add GameQuestion to the game
            game.GameQuestions = questions.Select(question => new Model.GameQuestion() {Question = question}).ToList();
            //save new game
            // _unitOfWork.GameRepository.Insert(game);
            // if (await _unitOfWork.SaveAsync() <= 0) throw new CommonException("Save new game failed."); 
            
            
            //return result
            //questions returned is different from GameQuestion
            var mappedGame = _mapper.Map<AiLaTyPhuGameDataset>(game);
            
            if (mappedGame != null)
            {
                mappedGame.Questions =
                    _mapper.Map<List<AiLaTyPhuQuestionDataset>>(questions).ToList();
                // mappedGame.Questions = mappedGame.Questions.OrderBy(q => q.Difficulty).ToList();
                var ezScore = 1000;
                var norScore = 6000;
                var hardScore = 11000;
                foreach (var question in mappedGame.Questions)
                {
                    
                    switch (question.Difficulty)
                    {
                        case "EASY":
                            question.Points = ezScore;
                            ezScore += 1000;
                            break;
                        case "MEDIUM":
                            question.Points = norScore;
                            norScore += 1000;
                            break;
                        case "HARD":
                            question.Points = hardScore;
                            hardScore += 1000;
                            break;
                    }
                }
                
            }
            return mappedGame;
        }

        /// <summary>
        /// Build query to get random questions based on difficulty, for ALTP game only
        /// Each difficulty will have 5 questions, as defined in NO_OF_*difficulty*_ALTP_QUESTION
        /// </summary>
        /// <param name="difficulty"></param>
        /// <returns></returns>
        private FormattableString altpQuestionQueryBuilder(QuestionDifficulty difficulty)
        {
            var limitNumber = difficulty switch
            {
                QuestionDifficulty.EASY => NO_OF_EASY_ALTP_QUESTIONS,
                QuestionDifficulty.MEDIUM => NO_OF_MEDIUM_ALTP_QUESTIONS,
                QuestionDifficulty.HARD => NO_OF_HARD_ALTP_QUESTIONS,
                _ => 0
            };

            var noOfQuestionCount = _questionKeyless.RawSelect($"(SELECT * FROM \"Question\" WHERE \"difficulty\" = {difficulty})").Count - limitNumber;
            // var noOfQuestionCount = _ctx.Questions
            //                 .FromSqlRaw($"(SELECT COUNT(\"questionID\") AS cnt FROM \"Question\" WHERE \"difficulty\" = 0)");
            
            return $"SELECT * FROM \"Question\" WHERE \"difficulty\" = {difficulty} ORDER BY random() LIMIT {limitNumber} OFFSET random()*{noOfQuestionCount};";
        } 
    }
}