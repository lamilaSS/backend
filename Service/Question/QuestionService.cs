using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using mcq_backend.Dataset.Question;
using mcq_backend.Helper.Exception;
using mcq_backend.Model;
using mcq_backend.Repository;

namespace mcq_backend.Service.Question
{
    public class QuestionService : IQuestionService
    {
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateQuestions(List<QuestionCreate> newQuestions, string userId)
        {
            foreach (var newQuestion in newQuestions)
            {
                //TODO: check for question duplication
                Model.Question question = _mapper.Map<Model.Question>(newQuestion);
                question.Creator = userId;
                //TODO: check question difficulty
                question.Difficulty ??= QuestionDifficulty.EASY;
                //TODO: check question type (multiple correct answer, non-select answer, single correct answer...)
                question.Answers = _mapper.Map<ICollection<Model.Answer>>(newQuestion.Answers);

                _unitOfWork.QuestionRepository.Insert(question);
                // _unitOfWork.AnswerRepository.InsertMany(question.Answers);
            }

            if (await _unitOfWork.SaveAsync() <= 0)
            {
                throw new CommonException("QUESTION_ADD", "Error in CreateQuestion");
                // return _mapper.Map<QuestionCreate>(await _unitOfWork.QuestionRepository.Get());
            }

            return true;
        }

        public async Task<List<QuestionDataset>> GetQuestions(List<Guid> questionIds)
        {
            Expression<Func<Model.Question, bool>> filter = null;
            if (questionIds.Count > 0)
            {
                 filter = question => questionIds.Contains(question.QuestionId);
            }
                

            return _mapper.Map<List<QuestionDataset>>(
                await _unitOfWork.QuestionRepository.Get(filter: filter, includeProperties: "Answers"));
        }

        public async Task UpdateQuestion(List<QuestionCreate> updateQuestions)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteQuestion(Guid questionId)
        {
            throw new NotImplementedException();
        }
    }
}