using System;

namespace MyQuizApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== QUIZ CONSOLE APP =====");

        QuestionBank<IQuestion> bank = new QuestionBank<IQuestion>();
        bank.Add(new MultipleChoiceQuestion("Tu khoa nao dung de khai bao class trong C#?", new List<string> { "struct", "class", "object", "method" }, 2));
        bank.Add(new TrueFalseQuestion("C# la ngon ngu lap trinh huong doi tuong?", true));
        bank.Add(new MultipleChoiceQuestion("Kieu du lieu nao sau day la kieu tham tri (value type) trong C#?", new List<string> { "string", "int", "object", "class" }, 2));
        bank.Add(new TrueFalseQuestion("Trong C#, mot class co the ke thua tu nhieu class khac cung luc?", false));
        bank.Add(new MultipleChoiceQuestion("Ky hieu nao duoc su dung de ke thua tu mot class khac trong C#?", new List<string> { "extends", "inherits", ":", "implements" }, 3));
        bank.Add(new MultipleChoiceQuestion("Phuong thuc nao la diem bat dau cua mot chuong trinh C# Console?", new List<string> { "Start", "Init", "Main", "Run" }, 3));
        bank.Add(new TrueFalseQuestion("Interface trong C# co the chua cac truong (fields)?", false));
        bank.Add(new MultipleChoiceQuestion("Tinh chat nao cua OOP cho phep mot doi tuong co nhieu hinh thai khac nhau?", new List<string> { "Encapsulation (Dong goi)", "Inheritance (Ke thua)", "Polymorphism (Da hinh)", "Abstraction (Truu tuong)" }, 3));
        bank.Add(new TrueFalseQuestion("Tu khoa 'virtual' duoc dung de cho phep phuong thuc co the bi ghi de (override) o class con?", true));
        bank.Add(new MultipleChoiceQuestion("Tu khoa nao dung de ngan cam viec ke thua tu mot class trong C#?", new List<string> { "static", "sealed", "final", "abstract" }, 2));

        Quiz quiz = new Quiz(bank.GetAll());
        quiz.Start();

        Console.WriteLine("\n===== KET QUA ======");
        quiz.PrintSummary();
        quiz.PrintRecentWrongAnswers();
        quiz.PrintLongestCorrectStreak();
    }
}
