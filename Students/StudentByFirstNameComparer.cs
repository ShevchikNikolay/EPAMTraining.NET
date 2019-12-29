using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class StudentByFirstNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }
}
