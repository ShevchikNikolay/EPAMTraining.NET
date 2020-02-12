namespace LinqToSQL
{
    /// <summary>
    /// Class represents some statistical information about marks in an group.
    /// </summary>
    public class GroupSessionSummaryRecord
    {
        /// <summary>
        /// Constructor creates an instance of record.
        /// </summary>
        /// <param name="name">Argument represents name of group.</param>
        /// <param name="averege">Argument represents average mark in group.</param>
        /// <param name="minimal">Argument represents minimal mark in group.</param>
        /// <param name="maximal">Argument represents maximal mark in group.</param>
        public GroupSessionSummaryRecord(
            string name, double? averege, int? minimal, int? maximal)
        {
            Name = name;
            Averege = averege;
            Minimal = minimal;
            Maximal = maximal;
        }
        /// <summary>
        /// Property represents name of group.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Property represents average mark in group.
        /// </summary>
        public double? Averege { get; }
        /// <summary>
        /// Property represents minimal mark in group.
        /// </summary>
        public int? Minimal { get; }
        /// <summary>
        /// Property represents maximal mark in group.
        /// </summary>
        public int? Maximal { get; }
    }
}
