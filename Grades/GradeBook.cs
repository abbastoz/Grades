using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook :GradeTrackes
    {
        public GradeBook()
        {
            _name = "Abbas's Grade Book";//this is my constructor method i use this to give values at the first.
            grades = new List<float>();
        }
        public override GradeStatistics ComputeStatistics()//i creatde this method as virtual bc i want to use this in throwawaygradebook class.
        {
            Console.WriteLine("GradeBook:GradeTrackers Gradebook");
            GradeStatistics statistics = new GradeStatistics();
            float sum = 0;
            statistics.LowestGrade = float.MaxValue;
            foreach (float grade in grades)
            {
                sum = sum + grade;
                statistics.HighestGrade = Math.Max(grade, statistics.HighestGrade);
                statistics.LowestGrade = Math.Min(grade, statistics.LowestGrade);                
            }
            statistics.AverageGrade = sum / grades.Count;

            return statistics;
        }
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }
       
        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }
        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }




    }

}
