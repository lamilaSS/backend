using System;
using System.Collections;

namespace mcq_backend.Dataset.Answer
{
    public class AnswerCreate
    {
        public string AnswerContent { get; set; }
        public bool IsCorrect { get; set; }
        public int? Status { get; set; }
    }
}