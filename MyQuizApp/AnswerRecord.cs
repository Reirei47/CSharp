public class AnswerRecord
{
    public int QuestionNumber { get; set; }

    public string? QuestionContent { get; set; }

    public string? UserAnswer { get; set; }

    public string? CorrectAnswer { get; set; }

    public bool IsCorrect { get; set; }
}