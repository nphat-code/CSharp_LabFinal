using System;
using System.Collections.Generic;

namespace MyQuizApp;

public class Quiz
{
    private readonly List<IQuestion> _questions;
    private readonly List<AnswerRecord> _records = new List<AnswerRecord>();

    public Quiz(List<IQuestion> questions)
    {
        _questions = questions;
    }

    public void Start()
    {
        for (int i = 0; i < _questions.Count; i++)
        {
            Console.WriteLine($"\nCau {i + 1}:");
            _questions[i].DisplayQuestion();
            string answer = _questions[i].GetValidAnswer();
            bool isCorrect = _questions[i].CheckAnswer(answer);

            if (isCorrect)
            {
                Console.WriteLine("Ket qua: Dung!");
            }
            else
            {
                Console.WriteLine("Ket qua: Sai!");
            }

            _records.Add(new AnswerRecord(
                i + 1,
                _questions[i].Content,
                answer,
                _questions[i].GetCorrectAnswerString(),
                isCorrect
            ));
        }
    }

    public void PrintSummary()
    {
        int correctCount = 0;
        foreach (var record in _records)
        {
            if (record.IsCorrect) correctCount++;
        }

        int totalQuestions = _records.Count;
        int wrongCount = totalQuestions - correctCount;

        double percentage = totalQuestions > 0 ? (double)correctCount / totalQuestions * 100 : 0;
        string grade = "Can co gang";
        if (percentage >= 80) grade = "Gioi";
        else if (percentage >= 65) grade = "Kha";
        else if (percentage >= 50) grade = "Trung binh";

        Console.WriteLine($"\nTong so cau: {totalQuestions}");
        Console.WriteLine($"So cau dung: {correctCount}");
        Console.WriteLine($"So cau sai: {wrongCount}");
        Console.WriteLine($"Diem cuoi cung: {correctCount}/{totalQuestions}");
        Console.WriteLine($"Xep loai: {grade}");
    }

    public void PrintRecentWrongAnswers()
    {
        Console.WriteLine("\n3 cau sai gan nhat:");
        int printedCount = 0;
        for (int i = _records.Count - 1; i >= 0; i--)

        {
            if (!_records[i].IsCorrect)
            {
                Console.WriteLine($"- Cau {_records[i].QuestionNumber}: {_records[i].QuestionContent} | Ban chon: {_records[i].UserAnswer} | Dap an dung: {_records[i].CorrectAnswer}");
                printedCount++;
                if (printedCount == 3) break;
            }
        }
        if (printedCount == 0)
        {
            Console.WriteLine("Khong co cau sai nao!");
        }
    }

    public void PrintLongestCorrectStreak()
    {
        int currentStreak = 0;
        int maxStreak = 0;
        int maxStreakEndIndex = -1;
        int currentStreakStartIndex = -1;
        int maxStreakStartIndex = -1;

        for (int i = 0; i < _records.Count; i++)
        {
            if (_records[i].IsCorrect)
            {
                if (currentStreak == 0)
                {
                    currentStreakStartIndex = i;
                }
                currentStreak++;
                if (currentStreak > maxStreak)
                {
                    maxStreak = currentStreak;
                    maxStreakEndIndex = i;
                    maxStreakStartIndex = currentStreakStartIndex;
                }
            }
            else
            {
                currentStreak = 0;
            }
        }

        if (maxStreak > 0)
        {
            int startQNum = _records[maxStreakStartIndex].QuestionNumber;
            int endQNum = _records[maxStreakEndIndex].QuestionNumber;
            Console.WriteLine($"\nDoan dung lien tiep dai nhat: tu cau {startQNum} den cau {endQNum}, tong cong {maxStreak} cau.");
        }
        else
        {
            Console.WriteLine("\nKhong co doan dung lien tiep nao.");
        }
    }
}
