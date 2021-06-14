using System;
using System.Collections.Generic;
using mcq_backend.Model.DefaultModel;

#nullable disable

namespace mcq_backend
{
    public record User: DefaultEntity
    {
        public User()
        {
            Histories = new HashSet<History>();
        }

        public string UserId { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Feedback { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public int? UserStatus { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
