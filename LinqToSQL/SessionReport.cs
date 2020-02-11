using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    public class SessionReport
    {
        
        public void GetSummaryByGrope(int sessionId)
        {
            using (var db = new MapingDataContext())
            {
                
                var report = from Result in db.Result
                             where
                               Result.Exam.Session.id == sessionId
                             group new { Result.Student.Group, Result } by new
                             {
                                 Result.Student.Group.name
                             } into g
                             select new
                             {
                                 AvgMark = (double?)g.Average(p => p.Result.mark),
                                 Minimal = (int?)g.Min(p => p.Result.mark),
                                 Maximal = (int?)g.Max(p => p.Result.mark),
                                 GroupName = g.Key.name
                             };
            }
        }

        public void GetSummaryBySpecialty(int sessionId)
        {
            using(var db= new MapingDataContext())
            {
                var report = from Result in db.Result
                             where
                               Result.Exam.Session.id == sessionId
                             group new { Result.Student.Group, Result } by new
                             {
                                 Result.Student.Group.specialty
                             } into g
                             select new
                             {
                                 AvgMark = (double?)g.Average(p => p.Result.mark),
                                 g.Key.specialty
                             };
            }
        }

        public void GetSummaryByExaminer(int sessionId)
        {
            using (var db = new MapingDataContext())
            {

                var report = from Result in db.Result
                             where
                               Result.Exam.Session.id == sessionId
                             group new { Result.Exam.Session, Result.Exam.Examner, Result } by new
                             {
                                 Result.Exam.Session.id,
                                 Result.Exam.Examner.lastName,
                                 Result.Exam.Examner.firstName,
                                 Result.Exam.Examner.patronymic
                             } into g
                             orderby
                               g.Key.id
                             select new
                             {
                                 g.Key.id,
                                 AvgMark = (double?)g.Average(p => p.Result.mark),
                                 g.Key.lastName,
                                 g.Key.firstName,
                                 g.Key.patronymic
                             };
            }
        }

        public void GetStudentsToExpulsion (int sessionId)
        {
            using (var db = new MapingDataContext())
            {

                var report = from Result in db.Result
                             where
                               Result.Exam.Session.id == sessionId
                             group new { Result.Student.Group, Result.Student, Result } by new
                             {
                                 Result.Student.Group.name,
                                 Result.Student.firstName,
                                 Result.Student.lastName,
                                 Result.Student.patronymic
                             } into g
                             where g.Min(p => p.Result.mark) < 4
                             orderby
                               g.Key.name,
                               g.Key.firstName,
                               g.Key.lastName,
                               g.Key.patronymic
                             select new
                             {
                                 g.Key.name,
                                 g.Key.firstName,
                                 g.Key.lastName,
                                 g.Key.patronymic
                             };
            }
        }
    }
}
