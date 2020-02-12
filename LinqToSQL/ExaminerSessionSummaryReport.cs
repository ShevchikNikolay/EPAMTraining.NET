using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LinqToSQL
{
    /// <summary>
    /// Class represents set of records, that descrbes some statistics on average marks.
    /// </summary>
    public class ExaminerSessionSummaryReport : List<ExaminerSessionSummaryRecord>
    {
        /// <summary>
        /// Constructor creates an instance of report.
        /// </summary>
        /// <param name="db">Argument represents a database context.</param>
        /// <param name="sessionId">Argument represents an identity code.</param>
        public ExaminerSessionSummaryReport(MapingDataContext db, int sessionId)
        {
            var query =
                from Result in db.Result
                group new { Result.Exam.Examner, Result.Exam, Result } by new
                {
                    Result.Exam.Examner.lastName,
                    Result.Exam.Examner.firstName,
                    Result.Exam.Examner.patronymic,
                    Result.Exam.sessionId
                } into g
                where g.Key.sessionId == sessionId
                orderby
                  g.Key.lastName,
                  g.Key.firstName,
                  g.Key.patronymic
                select new
                {
                    LastName = g.Key.lastName,
                    FirstName = g.Key.firstName,
                    Patronymic = g.Key.patronymic,
                    Average = (double?)g.Average(p => p.Result.mark)
                };
            foreach (var r in query)
                Add(new ExaminerSessionSummaryRecord(
                    r.LastName, r.FirstName, r.Patronymic, r.Average));
        }

    }
}
