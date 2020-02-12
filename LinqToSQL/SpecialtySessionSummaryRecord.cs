namespace LinqToSQL
{
    public class SpecialtySessionSummaryRecord
    {
        public SpecialtySessionSummaryRecord(
            string specialty, double? average)
        {
            Specialty = specialty;
            Average = average;
        }
        public string Specialty { get; }
        public double? Average { get; }
    }
}
