using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        
        public async Task<bool> CreateQuestions(List<QuestionCreate> newQuestions, string userId)
        {
            foreach (var newQuestion in newQuestions)
            {
                //TODO: check for question duplication
                Model.Question question = _mapper.Map<Model.Question>(newQuestion);
                question.Creator = userId;
                //TODO: check question difficulty
                question.Difficulty = QuestionDifficulty.EASY;
                question.Answers = _mapper.Map<ICollection<Model.Answer>>(newQuestion.Answers);
                
                _unitOfWork.QuestionRepository.Insert(question);
            }

            if (await _unitOfWork.SaveAsync() <= 0)
            {
                throw new CommonException("QUESTION_ADD", "Error in CreateQuestion");
                // return _mapper.Map<QuestionCreate>(await _unitOfWork.QuestionRepository.Get());
            }
            return true;
        }

        public async Task GetQuestions(List<Guid> questionIds)
        {
            throw new NotImplementedException();
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