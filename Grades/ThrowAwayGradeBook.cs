using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook:GradeBook
    {
        public override GradeStatistics ComputeStatistics()//i overrided this mettod because i have define the computestatistic as virtual.
        {
            Console.WriteLine("ThrowAwayGradeBook:GradeBook");
            float lowest = float.MaxValue;
            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }           
            grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}
