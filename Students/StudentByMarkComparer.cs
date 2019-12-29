using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class StudentByMarkComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Mark.CompareTo(y.Mark);
        }
    }
}
