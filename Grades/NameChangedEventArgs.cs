using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
   public class NameChangedEventArgs:EventArgs//if i want to know all event i have to derive all events on the project thats why i inherit it
    {
        public string ExistingName { get; set; }
        public string NewName { get; set; }
    }
}
