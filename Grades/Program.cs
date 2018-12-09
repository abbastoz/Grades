using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
           IGradeTrackes book = CreateGradeBook();
            GetBookName(book);
            AddGrade(book);
            SaveGrades(book);
            WriteResults(book);
        }

        private static IGradeTrackes CreateGradeBook()
        {
            return new ThrowAwayGradeBook();// i called the child because child inherit everything from the base.
        }

        private static void WriteResults(IGradeTrackes book)
        {
            GradeStatistics statistics = book.ComputeStatistics();
            Console.WriteLine("Grades:");
            foreach(float grade in book)
            {
                Console.WriteLine(grade);
            }
            WriteResult("Average:", statistics.AverageGrade);
            WriteResult("Highest:", statistics.HighestGrade);
            WriteResult("Lowest:", statistics.LowestGrade);
            WriteResult(statistics.Description, statistics.LetterGrade);
        }

        private static void SaveGrades(IGradeTrackes book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);//if i use like this(methods with using keyword) i dont have to use file close method.
                //outputFile.Close();//it otomaticaly close by its self.
            }
        }

        private static void AddGrade(IGradeTrackes book)
        {
            book.AddGrade(70);
            book.AddGrade(75.8f);
            book.AddGrade(48);
        }

        private static void GetBookName(IGradeTrackes book)
        {
            Console.WriteLine(book.Name);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)//i have told the onname changed to write below codes.
        {
            Console.WriteLine($"Grade Book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, string grade)
        {
            Console.WriteLine("Letter Grade:" + description + " " + grade);
        }

        static void WriteResult(string description, float grade)
        {
            Console.WriteLine(description + " " + grade);
        }
    }
}
