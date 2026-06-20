public class Quiz
{
    private List<IQuestion> questions;

    private List<AnswerRecord> records = new();

    private int score = 0;

    public Quiz(List<IQuestion> questions)
    {
        this.questions = questions;
    }

    public void Start()
    {
        Console.WriteLine("===== QUIZ CONSOLE APP =====");

        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine($"\nCau {i + 1}");

            questions[i].Display();

            string answer = questions[i].GetUserAnswer();

            bool correct = questions[i].CheckAnswer(answer);

            if (correct)
            {
                Console.WriteLine("Dung!");
                score++;
            }
            else
            {
                Console.WriteLine("Sai!");
            }

            records.Add(new AnswerRecord
            {
                QuestionNumber = i + 1,
                QuestionContent = questions[i].Content,
                UserAnswer = answer,
                CorrectAnswer = questions[i].GetCorrectAnswerText(),
                IsCorrect = correct
            });
        }

        ShowResult();
    }

    private void ShowResult()
    {
        int total = questions.Count;
        int wrong = total - score;

        Console.WriteLine("\n===== KET QUA =====");
        Console.WriteLine($"Tong cau: {total}");
        Console.WriteLine($"Dung: {score}");
        Console.WriteLine($"Sai: {wrong}");
        Console.WriteLine($"Diem: {score}/{total}");

        double percent = score * 100.0 / total;

        if (percent >= 80)
            Console.WriteLine("Xep loai: Gioi");
        else if (percent >= 65)
            Console.WriteLine("Xep loai: Kha");
        else if (percent >= 50)
            Console.WriteLine("Xep loai: Trung Binh");
        else
            Console.WriteLine("Xep loai: Can co gang");

        ShowLastWrongAnswers();
        ShowLongestCorrectStreak();
    }

    private void ShowLastWrongAnswers()
    {
        Console.WriteLine("\n3 cau sai gan nhat:");

        var wrongs = records
            .Where(x => !x.IsCorrect)
            .TakeLast(3);

        foreach (var item in wrongs.Reverse())
        {
            Console.WriteLine(
                $"- Cau {item.QuestionNumber}: {item.QuestionContent}" +
                $" | Ban chon: {item.UserAnswer}" +
                $" | Dap an dung: {item.CorrectAnswer}");
        }
    }

    private void ShowLongestCorrectStreak()
    {
        int maxLength = 0;
        int currentLength = 0;

        int start = 0;
        int end = 0;

        int tempStart = 0;

        for (int i = 0; i < records.Count; i++)
        {
            if (records[i].IsCorrect)
            {
                if (currentLength == 0)
                    tempStart = i;

                currentLength++;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    start = tempStart;
                    end = i;
                }
            }
            else
            {
                currentLength = 0;
            }
        }

        if (maxLength == 0)
        {
            Console.WriteLine(
                "\nKhong co cau tra loi dung nao.");
        }
        else
        {
            Console.WriteLine(
                $"\nDoan dung lien tiep dai nhat: " +
                $"tu cau {start + 1} den cau {end + 1}, " +
                $"tong cong {maxLength} cau.");
        }
    }
}