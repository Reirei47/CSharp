public interface IQuestion
{
    string Content { get; }

    void Display();

    string GetUserAnswer();

    bool CheckAnswer(string answer);

    string GetCorrectAnswerText();
}