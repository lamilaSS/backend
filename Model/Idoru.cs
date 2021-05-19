using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mcq_backend.Model.DefaultModel;

namespace mcq_backend.Model
{
    [Table("idoru")]
    public record Idoru : DefaultEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name:"id")]
        [Key]
        public int Id { get; set; }
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Column(name:"age")]
        public short Age { get; set; }
        [Column(name:"addr")]
        [MaxLength(1000)]
        public string Addr { get; set; }
        [Column(name:"gender")]
        public bool Gender { get; set; }
    }
}