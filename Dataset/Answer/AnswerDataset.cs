using System;
using mcq_backend.Dataset.Question;

namespace mcq_backend.Dataset.Answer
{
    public class AnswerDataset
    {
        public Guid AnswerId { get; set; }
        public Guid? QuestionId { get; set; }
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
        public int? Status { get; set; }

        // public virtual QuestionDataset Question { get; set; }
    }
}