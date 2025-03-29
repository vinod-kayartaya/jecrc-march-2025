namespace QnA_WebAPI_Project.Model
{
    public class Question
    {
        public Guid Id { get; set; }
        public string? QuestionText { get; set; }
        public string? AnswerText { get; set; }
    }
}
