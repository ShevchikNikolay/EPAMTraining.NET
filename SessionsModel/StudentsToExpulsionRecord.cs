namespace DataModel
{
    /// <summary>
    /// Class represents information about studen, whos minimal mark in session less than 4.
    /// </summary>
    public class StudentsToExpulsionRecord
    {
        /// <summary>
        /// Constructor creates an instance of a record.
        /// </summary>
        /// <param name="groupName">Argument represents name of group.</param>
        /// <param name="lastName">Argument represents last name of student.</param>
        /// <param name="firstName">Argument represents first name of student.</param>
        /// <param name="patronymic">Argument represents patronymic of student.</param>
        public StudentsToExpulsionRecord(
            string groupName, string lastName, string firstName,
            string patronymic)
        {
            GroupName = groupName;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
        }

        /// <summary>
        /// Property represents name of group.
        /// </summary>
        public string GroupName { get; }

        /// <summary>
        /// Property represents last name of student.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Property represents first name of student.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Property represents patronymic of student.
        /// </summary>
        public string Patronymic { get; }
    }
}
