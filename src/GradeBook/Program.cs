using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = null;

            // IBook book = new DiskBook("Class");
            book.AddGrade(90);
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();
            System.Console.WriteLine($"Bookname is {stats.Name}");
            System.Console.WriteLine($"The lowest grade is {stats.Low}");
            System.Console.WriteLine($"The highest grade is {stats.High}");
            System.Console.WriteLine($"The average grade is {stats.Average}");
            System.Console.WriteLine($"The Letter is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a number or q to quit");
                string input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs eventArgs){
            System.Console.WriteLine($"Grade Added");
        }
    }
}
