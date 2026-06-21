namespace MyQuizApp;

public class AnswerRecord
{
    public int QuestionNumber { get; set; }
    public string QuestionContent { get; set; }
    public string UserAnswer { get; set; }
    public string CorrectAnswer { get; set; }
    public bool IsCorrect { get; set; }

    public AnswerRecord(int questionNumber, string questionContent, string userAnswer, string correctAnswer, bool isCorrect)
    {
        QuestionNumber = questionNumber;
        QuestionContent = questionContent;
        UserAnswer = userAnswer;
        CorrectAnswer = correctAnswer;
        IsCorrect = isCorrect;
    }
}
