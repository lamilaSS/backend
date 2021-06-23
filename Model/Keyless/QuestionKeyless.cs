using System;
using mcq_backend.Model.DefaultModel;
using Microsoft.EntityFrameworkCore;

namespace mcq_backend.Model.Keyless
{
    [Keyless]
    public record QuestionKeyless : DefaultEntity
    {
        public Guid questionID { get; set; }
        public string questionContent { get; set; }
        public QuestionDifficulty? difficulty { get; set; }
        public string creator { get; set; }
    }
}