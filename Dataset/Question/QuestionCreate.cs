using System;
using System.Collections.Generic;
using mcq_backend.Dataset.Answer;

namespace mcq_backend.Dataset.Question
{
    public class QuestionCreate
    {
        public string QuestionContent { get; set; }
        public int? Difficulty { get; set; }
        public string Creator { get; set; }
        public virtual ICollection<AnswerCreate> Answers { get; set; }
    }
}