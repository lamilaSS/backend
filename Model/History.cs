using System;
using System.Collections.Generic;
using mcq_backend.Model.DefaultModel;

#nullable disable

namespace mcq_backend
{
    public record History: DefaultEntity
    {
        public Guid HistoryId { get; set; }
        public string UserId { get; set; }
        public Guid? GameId { get; set; }
        public int? Score { get; set; }
        public string Session { get; set; }
        public string TimeFinished { get; set; }
        public DateTime? Date { get; set; }
        public int? TotalQuestion { get; set; }
        public int? NumOfCorrect { get; set; }
        public Guid? ScoreDetailId { get; set; }
        public int? Status { get; set; }

        public virtual Game Game { get; set; }
        public virtual ScoreDetail ScoreDetail { get; set; }
        public virtual User User { get; set; }
    }
}
