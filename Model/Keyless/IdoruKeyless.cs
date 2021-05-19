using mcq_backend.Model.DefaultModel;
using Microsoft.EntityFrameworkCore;

namespace mcq_backend.Model.Keyless
{
    [Keyless]
    public record IdoruKeyless : DefaultEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public short Age { get; set; }

        public string Addr { get; set; }

        public bool Gender { get; set; }
    }
}