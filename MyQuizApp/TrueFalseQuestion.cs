using System;

namespace MyQuizApp;

public class TrueFalseQuestion : IQuestion
{
    private readonly bool _correctAnswer;

    public string Content { get; }

    public TrueFalseQuestion(string content, bool correctAnswer)
    {
        Content = content;
        _correctAnswer = correctAnswer;
    }

    public void DisplayQuestion()
    {
        Console.WriteLine($"{Content} (Y/N)");
    }

    public string GetValidAnswer()
    {
        while (true)
        {
            Console.Write("Nhap lua chon cua ban: ");
            string input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;


            if (input == "y" || input == "yes" || input == "true" || input == "n" || input == "no" || input == "false")
            {
                if (input == "y" || input == "yes" || input == "true") return "True";
                return "False";
            }
            else
            {
                Console.WriteLine("Gia tri khong hop le (chi nhap Y hoac N). Vui long nhap lai.");
            }
        }
    }

    public bool CheckAnswer(string answer)
    {
        if (bool.TryParse(answer, out bool result))
        {
            return result == _correctAnswer;
        }
        return false;
    }

    public string GetCorrectAnswerString()
    {
        return _correctAnswer ? "True (Y)" : "False (N)";
    }
}
