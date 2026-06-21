namespace MyQuizApp;

public interface IQuestion
{
    string Content { get; }
    void DisplayQuestion();
    string GetValidAnswer();
    bool CheckAnswer(string answer);
    string GetCorrectAnswerString();
}
