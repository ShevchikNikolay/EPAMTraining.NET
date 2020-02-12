namespace LinqToSQL
{
    public class ExaminerSessionSummaryRecord
    {
        public ExaminerSessionSummaryRecord(
            string lastName, string firstName, string patronymic,
            double? average)
        {
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            Average = average;
        }
        public string LastName { get; }
        public string FirstName { get; }
        public string Patronymic { get; }
        public double? Average { get; }
    }
}
