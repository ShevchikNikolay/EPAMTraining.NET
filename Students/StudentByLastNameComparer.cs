using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class StudentByLastNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.LastName.CompareTo(y.LastName);
        }
    }
}
