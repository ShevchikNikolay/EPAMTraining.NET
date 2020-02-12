using System.Collections.Generic;
using System.Linq;

namespace LinqToSQL
{
    class GroupSessionSummaryReport : List<GroupSessionSummaryRecord>
    {
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
