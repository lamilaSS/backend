using System;
using System.Collections.Generic;
using mcq_backend.Model.DefaultModel;

#nullable disable

namespace mcq_backend
{
    public record Game : DefaultEntity
    {
        public Game()
        {
            GameQuestions = new HashSet<GameQuestion>();
            Histories = new HashSet<History>();
            Lifelines = new HashSet<Lifeline>();
            ScoreDetails = new HashSet<ScoreDetail>();
        }

        public Guid GameId { get; set; }
        public string GameDescription { get; set; }
        public string Time { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<GameQuestion> GameQuestions { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Lifeline> Lifelines { get; set; }
        public virtual ICollection<ScoreDetail> ScoreDetails { get; set; }
    }
}
