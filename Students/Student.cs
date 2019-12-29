using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Students
{
    [Serializable]
    public class Student : IComparable<Student>, IEquatable<Student>
    {
        public Student()
        {
            FirstName = "";
            LastName = "";
            TestName = "";
            TestDate = DateTime.MinValue;
            Mark = 0;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public int Mark { get; set; }

        public int CompareTo(Student other)
        {
            return LastName.CompareTo(other.LastName);
        }

        public bool Equals(Student other)
        {
            return (FirstName.Equals(other.FirstName) &&
                   LastName.Equals(other.LastName) &&
                   TestName.Equals(other.TestName) &&
                   TestDate.Equals(other.TestDate) &&
                   Mark.Equals(other.Mark));
        }
    }
}
