using System;
using System.Collections.Generic;
using mcq_backend.Model.DefaultModel;

#nullable disable

namespace mcq_backend.Model
{
    public record GameQuestion : DefaultEntity
    {
        public Guid GameQuestionId { get; set; }
        public Guid? GameId { get; set; }
        public Guid? QuestionId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Question Question { get; set; }
    }
}
