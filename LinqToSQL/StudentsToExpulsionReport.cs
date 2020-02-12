using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LinqToSQL
{
    /// <summary>
    /// Class represents set of records about students in diferent groups,
    /// whos minimal mark in the session less than 4.
    /// </summary>
    public class StudentsToExpulsionReport : List<StudentsToExpulsionRecord>
    {
        /// <summary>
        /// Constructor creates an instance of report.
        /// </summary>
        /// <param name="db">Argument represents a database context.</param>
        /// <param name="sessionId">Argument represents an identity code.</param>
        public StudentsToExpulsionReport(MapingDataContext db, int sessionId)
        {
            var query =
                from Result in db.Result
                group new { Result.Student.Group, Result.Student, Result.Exam, Result } by new
                {
                    Result.Student.Group.name,
                    Result.Student.lastName,
                    Result.Student.firstName,
                    Result.Student.patronymic,
                    Result.Exam.sessionId
                } into g
                where g.Min(p => p.Result.mark) < 4 &&
                  g.Key.sessionId == sessionId
                orderby
                  g.Key.name,
                  g.Key.lastName,
                  g.Key.firstName,
                  g.Key.patronymic
                select new
                {
                    GroupName = g.Key.name,
                    LastName = g.Key.lastName,
                    FirstName = g.Key.firstName,
                    Patronymic = g.Key.patronymic
                };
            foreach (var r in query)
                Add(new StudentsToExpulsionRecord(
                    r.GroupName, r.LastName, r.FirstName, r.Patronymic));
        }
    }
}
