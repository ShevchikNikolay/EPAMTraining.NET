using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LinqToSQL
{
    public class ExaminerSessionSummaryReport : List<ExaminerSessionSummaryRecord>
    {
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
