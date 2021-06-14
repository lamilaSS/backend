using System;
using System.Collections.Generic;
using mcq_backend.Model.DefaultModel;

#nullable disable

namespace mcq_backend
{
    public record Question: DefaultEntity
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            GameQuestions = new HashSet<GameQuestion>();
            ScoreDetails = new HashSet<ScoreDetail>();
        }

        public Guid QuestionId { get; set; }
        public string QuestionContent { get; set; }
        public int? Difficulty { get; set; }
        public string Creator { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<GameQuestion> GameQuestions { get; set; }
        public virtual ICollection<ScoreDetail> ScoreDetails { get; set; }
    }
}
