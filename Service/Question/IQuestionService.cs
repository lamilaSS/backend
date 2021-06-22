using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using mcq_backend.Dataset.Question;

namespace mcq_backend.Service.Question
{
    public interface IQuestionService
    {
        Task<bool> CreateQuestions(List<QuestionCreate> newQuestions, string userId);
        Task GetQuestions(List<Guid> questionIds);
        Task UpdateQuestion(List<QuestionCreate> updateQuestions);
        Task DeleteQuestion(Guid questionId);
    }
}