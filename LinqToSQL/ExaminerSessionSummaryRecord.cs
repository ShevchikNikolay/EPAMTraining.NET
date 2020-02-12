namespace LinqToSQL
{
    /// <summary>
    /// Represents record in statistic report.
    /// </summary>
    public class ExaminerSessionSummaryRecord
    {
        /// <summary>
        /// Creates an instance of record.
        /// </summary>
        /// <param name="lastName">Last name of examiner.</param>
        /// <param name="firstName">First name of examiner.</param>
        /// <param name="patronymic">Patronymic of examiner.</param>
        /// <param name="average">Average mark by examiner.</param>
        public ExaminerSessionSummaryRecord(
            string lastName, string firstName, string patronymic,
            double? average)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            Average = average;
        }
        /// <summary>
        /// Property represents last name of examiner.
        /// </summary>
        public string LastName { get; }
        /// <summary>
        /// Property represents first name of examiner.
        /// </summary>
        public string FirstName { get; }
        /// <summary>
        /// Property represents patronymic of examiner.
        /// </summary>
        public string Patronymic { get; }
        /// <summary>
        /// property represents average mark by examiner.
        /// </summary>
        public double? Average { get; }
    }
}
