using System;
using System.Collections.Generic;
using mcq_backend.Dataset.Question;

namespace mcq_backend.Dataset.Game
{
    public class AiLaTyPhuGameDataset
    {
        public Guid GameId { get; set; }
        public string GameDescription { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<AiLaTyPhuQuestionDataset> Questions { get; set; }
    }
}