namespace LinqToSQL
{
    public class StudentToExpulsionRecord
    {
        public StudentToExpulsionRecord(
            string groupName, string lastName, string firstName,
            string patronymic)
        {
            GroupName = groupName;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
        }
        public string GroupName { get; }
        public string LastName { get; }
        public string FirstName { get; }
        public string Patronymic { get; }
    }
}
