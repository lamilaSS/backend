using System;
using System.Collections.Generic;
using System.Collections;
using mcq_backend.Model.DefaultModel;

#nullable disable

namespace mcq_backend.Model
{
    public record Answer : DefaultEntity
    {
        public Guid AnswerId { get; set; }
        public Guid? QuestionId { get; set; }
        public string AnswerContent { get; set; }
        public BitArray IsCorrect { get; set; }
        public int? Status { get; set; }

        public virtual Question Question { get; set; }
    }
}
