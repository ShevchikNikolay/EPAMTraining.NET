using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LinqToSQL
{
    class SpecialtySessionSummaryReport : List<SpecialtySessionSummaryRecord>
    {
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
