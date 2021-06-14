using System;
using System.Collections.Generic;
using System.Collections;
using mcq_backend.Model.DefaultModel;

#nullable disable

namespace mcq_backend
{
    public record ScoreDetail: DefaultEntity
    {
        public ScoreDetail()
        {
            Histories = new HashSet<History>();
        }

        public Guid ScoreDetailId { get; set; }
        public Guid? QuestionId { get; set; }
        public BitArray IsCorrect { get; set; }

        public virtual Game Question { get; set; }
        public virtual Question QuestionNavigation { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
