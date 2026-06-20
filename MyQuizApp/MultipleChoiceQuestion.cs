public class MultipleChoiceQuestion : IQuestion
{
    public string Content { get; set; }

    private List<string> Options;
    private int CorrectIndex;

    public MultipleChoiceQuestion(
        string content,
        List<string> options,
        int correctIndex)
    {
        Content = content;
        Options = options;
        CorrectIndex = correctIndex;
    }

    public void Display()
    {
        Console.WriteLine(Content);

        for (int i = 0; i < Options.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
    }

    public string GetUserAnswer()
    {
        while (true)
        {
            Console.Write("Nhap lua chon: ");

            string input = Console.ReadLine()!;

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Gia tri khong hop le.");
                continue;
            }

            if (choice < 1 || choice > Options.Count)
            {
                Console.WriteLine("Lua chon ngoai pham vi.");
                continue;
            }

            return input;
        }
    }

    public bool CheckAnswer(string answer)
    {
        return int.Parse(answer) == CorrectIndex;
    }

    public string GetCorrectAnswerText()
    {
        return $"{CorrectIndex}. {Options[CorrectIndex - 1]}";
    }
}