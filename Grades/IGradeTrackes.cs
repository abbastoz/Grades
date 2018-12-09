using System.Collections;
using System.IO;

namespace Grades
{
    internal interface IGradeTrackes: IEnumerable//interfaces just define methods without any public, protected, private things
    {
         GradeStatistics ComputeStatistics();
        void AddGrade(float grade);
         void WriteGrades(TextWriter destination);
        new IEnumerator GetEnumerator();// 
        string Name { get; set; }

    }
}