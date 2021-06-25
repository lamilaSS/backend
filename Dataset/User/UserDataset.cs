using System;
using System.Collections.Generic;
using mcq_backend.Dataset.History;

namespace mcq_backend.Dataset.User
{
    public class UserDataset
    {
        public string UserId { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Feedback { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Image { get; set; }
        public int? UserStatus { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<HistoryDataset> Histories { get; set; }
    }
}