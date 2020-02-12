namespace LinqToSQL
{
    public class GroupSessionSummaryRecord
    {
        public GroupSessionSummaryRecord(
            string name, double? averege, int? minimal, int? maximal)
        {
            Name = name;
            Averege = averege;
            Minimal = minimal;
            Maximal = maximal;
        }
        public string Name { get; }
        public double? Averege { get; }
        public int? Minimal { get; }
        public int? Maximal { get; }
    }
}
