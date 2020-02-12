using System.Collections.Generic;
using System.Linq;

namespace LinqToSQL
{
    class StudentsToExpulsionReport : List<StudentToExpulsionRecord>
    {
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
                Add(new StudentToExpulsionRecord(
                    r.GroupName, r.LastName, r.FirstName, r.Patronymic));
        }
    }

}
