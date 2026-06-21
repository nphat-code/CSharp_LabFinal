using System;
using System.Collections.Generic;

namespace MyQuizApp;

public class MultipleChoiceQuestion : IQuestion
{
    private readonly List<string> _choices;
    private readonly int _correctChoiceIndex;

    public string Content { get; }

    public MultipleChoiceQuestion(string content, List<string> choices, int correctChoiceIndex)
    {
        Content = content;
        _choices = choices;
        _correctChoiceIndex = correctChoiceIndex;
    }

    public void DisplayQuestion()
    {
        Console.WriteLine(Content);
        for (int i = 0; i < _choices.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_choices[i]}");
        }
    }

    public string GetValidAnswer()
    {
        while (true)
        {
            Console.Write("Nhap lua chon cua ban: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                if (choice >= 1 && choice <= _choices.Count)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Lua chon nam ngoai pham vi. Vui long nhap lai.");
                }
            }
            else
            {
                Console.WriteLine("Gia tri khong hop le. Vui long nhap lai.");
            }
        }
    }

    public bool CheckAnswer(string answer)
    {
        if (int.TryParse(answer, out int choice))
        {
            return choice == _correctChoiceIndex;
        }
        return false;
    }

    public string GetCorrectAnswerString()
    {
        return _correctChoiceIndex.ToString();
    }
}
