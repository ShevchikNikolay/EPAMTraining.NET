using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataModel;

namespace ORM
{
    /// <summary>
    /// Class represens set of records about statistics on marks in diferent groups.
    /// </summary>
    public class GroupSessionSummaryReport : List<GroupSessionSummaryRecord>
    {
        /// <summary>
        /// Constructor creates an instance of report.
        /// </summary>
        /// <param name="sessionId">Argument represents an identity code.</param>
        public GroupSessionSummaryReport(int sessionId)
        {
            using (var db = new DBContext())
            {
                var query =
                    from result in db.Results
                    join student in db.Students on result.StudentId equals student.Id
                    join grup in db.Groups on student.GroupId equals grup.Id
                    join exam in db.Exams on result.ExamId equals exam.Id
                    join session in db.Sessions on exam.SessionId equals session.Id
                    group new { grup, session, result } by new
                    {
                        grup.Name,
                        session.Id
                    } into g
                    where g.Key.Id == sessionId
                    orderby
                      g.Key.Name
                    select new
                    {
                        g.Key.Name,
                        Averege = (double?)g.Average(item => item.result.Mark),
                        Minimal = (int?)g.Min(item => item.result.Mark),
                        Maximal = (int?)g.Max(item => item.result.Mark)
                    };


                foreach (var item in query)
                    Add(new GroupSessionSummaryRecord(
                        item.Name, item.Averege, item.Minimal, item.Maximal));
            }
        }
    }
}
