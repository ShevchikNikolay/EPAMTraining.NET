using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LinqToSQL
{
    /// <summary>
    /// Class represens set of records about statistics on marks in diferent groups.
    /// </summary>
    public class GroupSessionSummaryReport : List<GroupSessionSummaryRecord>
    {
        /// <summary>
        /// Constructor creates an instance of report.
        /// </summary>
        /// <param name="db">Argument represens a database context.</param>
        /// <param name="sessionId">Argument represents an identity code.</param>
        public GroupSessionSummaryReport(MapingDataContext db, int sessionId)
        {
            var query =
                from Result in db.Result
                group new { Result.Student.Group, Result.Exam.Session, Result } by new
                {
                    Result.Student.Group.name,
                    Result.Exam.Session.id
                } into g
                where g.Key.id == sessionId
                orderby
                  g.Key.name
                select new
                {
                    g.Key.name,
                    Averege = (double?)g.Average(p => p.Result.mark),
                    Minimal = (int?)g.Min(p => p.Result.mark),
                    Maximal = (int?)g.Max(p => p.Result.mark)
                };
            foreach (var r in query)
                Add(new GroupSessionSummaryRecord(
                    r.name, r.Averege, r.Minimal, r.Maximal));
        }

    }
}
