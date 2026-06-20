public class TrueFalseQuestion : IQuestion
{
    public string Content { get; set; }

    private bool CorrectAnswer;

    public TrueFalseQuestion(string content, bool correctAnswer)
    {
        Content = content;
        CorrectAnswer = correctAnswer;
    }

    public void Display()
    {
        Console.WriteLine(Content + " (Y/N)");
    }

    public string GetUserAnswer()
    {
        while (true)
        {
            Console.Write("Nhap lua chon: ");

            string input = Console.ReadLine()!.Trim().ToUpper();

            if (input == "Y" || input == "N")
                return input;

            Console.WriteLine("Chi duoc nhap Y hoac N.");
        }
    }

    public bool CheckAnswer(string answer)
    {
        bool userAnswer = answer.ToUpper() == "Y";
        return userAnswer == CorrectAnswer;
    }

    public string GetCorrectAnswerText()
    {
        return CorrectAnswer ? "Y" : "N";
    }
}