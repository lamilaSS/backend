using System;
using System.Collections.Generic;
using mcq_backend.Model.DefaultModel;

#nullable disable

namespace mcq_backend
{
    public record Lifeline: DefaultEntity
    {
        public Guid LifelineId { get; set; }
        public Guid? GameId { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }

        public virtual Game Game { get; set; }
    }
}
