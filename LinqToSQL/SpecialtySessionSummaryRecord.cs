namespace LinqToSQL
{
    /// <summary>
    /// Class represents some statistical information about marks on any specialty.
    /// </summary>
    public class SpecialtySessionSummaryRecord
    {
        /// <summary>
        /// Constructor creates an instance of record.
        /// </summary>
        /// <param name="specialty">Argument represents name of specialty.</param>
        /// <param name="average">Argument represents average mark in the specialty.</param>
        public SpecialtySessionSummaryRecord(
            string specialty, double? average)
        {
            Specialty = specialty;
            Average = average;
        }
        /// <summary>
        /// Property represents name of specialty.
        /// </summary>
        public string Specialty { get; }
        /// <summary>
        /// Property represents average mark in the specialty.
        /// </summary>
        public double? Average { get; }
    }
}
