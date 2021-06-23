using System;
using System.Collections.Generic;
using mcq_backend.Dataset.Answer;
using mcq_backend.Model;

namespace mcq_backend.Dataset.Question
{
    public class QuestionDataset
    {
        public Guid QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public QuestionDifficulty? Difficulty { get; set; }
        public string Creator { get; set; }

        public virtual List<AnswerDataset> Answers { get; set; }
        // public virtual ICollection<GameQuestion> GameQuestions { get; set; }
        // public virtual ICollection<ScoreDetail> ScoreDetails { get; set; }
    }
}