QuestionBank<IQuestion> bank = new();

bank.Add(new MultipleChoiceQuestion(
    "Tu khoa nao dung de khai bao class trong C#?",
    new List<string>
    {
        "struct",
        "class",
        "object",
        "method"
    },
    2));

bank.Add(new TrueFalseQuestion(
    "C# la ngon ngu huong doi tuong?",
    true));

bank.Add(new MultipleChoiceQuestion(
    "Kieu du lieu luu so nguyen?",
    new List<string>
    {
        "int",
        "string",
        "bool",
        "char"
    },
    1));

bank.Add(new TrueFalseQuestion(
    "Interface co the khoi tao bang new?",
    false));

bank.Add(new MultipleChoiceQuestion(
    "Tu khoa ke thua?",
    new List<string>
    {
        "extends",
        "inherits",
        ":",
        "implements"
    },
    3));

bank.Add(new TrueFalseQuestion(
    "Abstract class co the chua method abstract?",
    true));

bank.Add(new MultipleChoiceQuestion(
    "List<T> nam trong namespace nao?",
    new List<string>
    {
        "System.IO",
        "System.Collections.Generic",
        "System.Text",
        "System.Net"
    },
    2));

bank.Add(new TrueFalseQuestion(
    "String la kieu tham chieu?",
    true));

bank.Add(new MultipleChoiceQuestion(
    "Tu khoa tao doi tuong?",
    new List<string>
    {
        "make",
        "create",
        "object",
        "new"
    },
    4));

bank.Add(new TrueFalseQuestion(
    "Constructor co the trung ten class?",
    true));

Quiz quiz = new Quiz(bank.GetAll());

quiz.Start();