using System.Collections.Generic;

namespace MyQuizApp;

public class QuestionBank<T> where T : IQuestion
{
    private readonly List<T> _questions = new List<T>();

    public void Add(T question)
    {
        _questions.Add(question);
    }

    public List<T> GetAll()
    {
        return _questions;
    }
}
