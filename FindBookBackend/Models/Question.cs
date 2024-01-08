using System.Collections.Generic;

namespace FindBookBackend.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
