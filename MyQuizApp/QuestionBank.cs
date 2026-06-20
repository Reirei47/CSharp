public class QuestionBank<T> where T : IQuestion
{
    private List<T> questions = new();

    public void Add(T question)
    {
        questions.Add(question);
    }

    public List<T> GetAll()
    {
        return questions;
    }
}