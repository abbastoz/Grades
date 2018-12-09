using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
  public abstract class GradeTrackes:IGradeTrackes // i created this as an abstract class and i use this when as a abstract class and i use interface for this. 
    {      
        public abstract GradeStatistics ComputeStatistics();
        public abstract void AddGrade(float grade);
        public abstract void WriteGrades(TextWriter destination);//abstract methods have to use abstract keywords. and override in child classes
        public abstract IEnumerator GetEnumerator();//i want to reach the grades in grade book. Thats why i have to use c# collectioons IEnumerator

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name Can not be null Ms. Abbas");
                }
                else
                {
                    if (_name != value && NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;
                        NameChanged(this, args);//namechanged has two parameters as you check the delegate
                    }
                    _name = value;
                }

            }
        }
        protected string _name;
        protected List<float> grades;
        public event NameChangedDelegate NameChanged;// i have created a new namechanged delegate NameChanged

    }
}
