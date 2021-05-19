using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcq_backend.Model.DefaultModel
{
    public record DefaultEntity
    {
        [Required]
        [Column(name:"created")]
        public DateTime Created { get; set; }
        [Required]
        [Column(name:"lastupdated")]
        public DateTime LastUpdated { get; set; }
    }
}