using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataModel;
using DataAccess;

namespace ORM
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
        public StudentsToExpulsionReport(int sessionId)
        {
            using (DBContext db = new DBContext())
            {

                var query = from result in db.Results
                            join student in db.Students on result.StudentId equals student.Id
                            join grup in db.Groups on student.GroupId equals grup.Id
                            join exam in db.Exams on result.ExamId equals exam.Id
                            join session in db.Sessions on exam.SessionId equals session.Id
                            group new
                            {
                                grup,
                                student,
                                exam,
                                result
                            } by new
                            {
                                grup.Name,
                                student.LastName,
                                student.FirstName,
                                student.Patronymic,
                                exam.SessionId
                            } into g
                            where g.Min(item => item.result.Mark) < 4 &&
                                  g.Key.SessionId == sessionId
                            orderby
                                g.Key.Name,
                                g.Key.LastName,
                                g.Key.FirstName,
                                g.Key.Patronymic

                            select new
                            {
                                GroupName = g.Key.Name,
                                g.Key.LastName,
                                g.Key.FirstName,
                                g.Key.Patronymic
                            };

                foreach (var item in query)
                    Add(new StudentsToExpulsionRecord(
                        item.GroupName, item.LastName, item.FirstName, item.Patronymic));
            }
        }
    }
}
