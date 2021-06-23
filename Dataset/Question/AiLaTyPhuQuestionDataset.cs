using System;
using System.Collections.Generic;
using mcq_backend.Dataset.Answer;
using mcq_backend.Model;
using Newtonsoft.Json;

namespace mcq_backend.Dataset.Question
{
    public class AiLaTyPhuQuestionDataset
    {
        [JsonProperty(PropertyName = "id")]
        public Guid QuestionId { get; set; }
        
        [JsonProperty(PropertyName = "question")]
        public string QuestionContent { get; set; }
        
        [JsonProperty(PropertyName = "difficulty")]
        public string Difficulty { get; set; }
        [JsonProperty(PropertyName = "point")]
        public double Points { get; set; }

        [JsonProperty(PropertyName = "answer")]
        public virtual List<AiLaTyPhuAnswerDataset> Answers { get; set; }
    }

    public class AiLaTyPhuAnswerDataset
    {
        [JsonProperty(PropertyName = "id")]
        public Guid AnswerId { get; set; }
        public Guid? QuestionId { get; set; }
        [JsonProperty(PropertyName = "answer")]
        public string AnswerContent { get; set; }
        [JsonProperty(PropertyName = "isAnswer")]
        public bool IsCorrect { get; set; }
    }
}