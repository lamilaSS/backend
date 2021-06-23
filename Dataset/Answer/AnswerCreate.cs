using System;

namespace mcq_backend.Dataset.Answer
{
    public class AnswerCreate
    {
        public Guid? QuestionId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
        public int? Status { get; set; }
    }
}