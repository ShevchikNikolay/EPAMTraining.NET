using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Students
{
    /// <summary>
    /// Describes student.
    /// </summary>
    [Serializable]
    public class Student : IComparable<Student>, IEquatable<Student>
    {
        /// <summary>
        /// Constructor without parameters.
        /// </summary>
        public Student()
        {
            FirstName = "";
            LastName = "";
            TestName = "";
            TestDate = DateTime.MinValue;
            Mark = 0;
        }

        /// <summary>
        /// First name of student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of student.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Name of test.
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// Testing date.
        /// </summary>
        public DateTime TestDate { get; set; }

        /// <summary>
        /// Mark received for the test.
        /// </summary>
        public int Mark { get; set; }

        /// <summary>
        /// Default comparaton method
        /// </summary>
        /// <param name="other"> student to compare.</param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            return LastName.CompareTo(other.LastName);
        }

        /// <summary>
        /// Method for checking equality students.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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
