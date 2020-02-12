using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LinqToSQL
{
    /// <summary>
    /// Class represens set of records about statistics on marks in diferent specialties.
    /// </summary>
    public class SpecialtySessionSummaryReport : List<SpecialtySessionSummaryRecord>
    {
        /// <summary>
        /// Constructor creates an instance of report.
        /// </summary>
        /// <param name="db">Argument represens a database context.</param>
        /// <param name="sessionId">Argument represents an identity code.</param>
        public SpecialtySessionSummaryReport(MapingDataContext db, int sessionId)
        {
            var query =
                from Result in db.Result
                group new { Result.Student.Group, Result.Exam.Session, Result } by new
                {
                    Result.Student.Group.specialty,
                    Result.Exam.Session.id
                } into g
                where g.Key.id == sessionId
                select new
                {
                    Specialty = g.Key.specialty,
                    Average = (double?)g.Average(p => p.Result.mark)
                };
            foreach (var r in query)
                Add(new SpecialtySessionSummaryRecord(
                    r.Specialty, r.Average));
        }
    }
}
