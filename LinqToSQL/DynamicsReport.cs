using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    public class DynamicsReport
    {
        public DynamicsReport(
            DateTime year, double? maths, double? visualProgramming,
            double? oOP, double? dBEngeneering, double? modeling,
            double? cryptology)
        {
            Year = year;
            Maths = maths;
            VisualProgramming = visualProgramming;
            OOP = oOP;
            DBEngeneering = dBEngeneering;
            Modeling = modeling;
            Cryptology = cryptology;
        }
        public DateTime Year { get; }
        public double? Maths { get; }
        public double? VisualProgramming { get; }
        public double? OOP { get; }
        public double? DBEngeneering { get; }
        public double? Modeling { get; }
        public double? Cryptology { get; }
    }
    public class DynamicsReportList : List<DynamicsReport>
    {
        public DynamicsReportList(MapingDataContext db)
        {
            var query =
                from Session in db.Session
                join Averege_1 in (
                    (from Result in db.Result
                     group new { Result.Exam.Session, Result.Exam.Subject, Result } by new
                     {
                         Result.Exam.Session.year,
                         Result.Exam.Subject.id
                     } into g
                     where g.Key.id == 1
                     orderby
                   g.Key.year
                     select new
                     {
                         year = g.Key.year,
                         average = (double?)g.Average(p => p.Result.mark)
                     })) on new { year = Session.year } equals new { year = Convert.ToDateTime(Averege_1.year) }
                join Averege_2 in (
                    (from Result in db.Result
                     group new { Result.Exam.Session, Result.Exam.Subject, Result } by new
                     {
                         Result.Exam.Session.year,
                         Result.Exam.Subject.id
                     } into g
                     where g.Key.id == 2
                     orderby
                   g.Key.year
                     select new
                     {
                         year = g.Key.year,
                         average = (double?)g.Average(p => p.Result.mark)
                     })) on new { year = Session.year } equals new { year = Convert.ToDateTime(Averege_2.year) }
                join Averege_3 in (
                    (from Result in db.Result
                     group new { Result.Exam.Session, Result.Exam.Subject, Result } by new
                     {
                         Result.Exam.Session.year,
                         Result.Exam.Subject.id
                     } into g
                     where g.Key.id == 3
                     orderby
                   g.Key.year
                     select new
                     {
                         year = g.Key.year,
                         average = (double?)g.Average(p => p.Result.mark)
                     })) on new { year = Session.year } equals new { year = Convert.ToDateTime(Averege_3.year) }
                join Averege_4 in (
                    (from Result in db.Result
                     group new { Result.Exam.Session, Result.Exam.Subject, Result } by new
                     {
                         Result.Exam.Session.year,
                         Result.Exam.Subject.id
                     } into g
                     where g.Key.id == 4
                     orderby
                   g.Key.year
                     select new
                     {
                         year = g.Key.year,
                         average = (double?)g.Average(p => p.Result.mark)
                     })) on new { year = Session.year } equals new { year = Convert.ToDateTime(Averege_4.year) }
                join Averege_5 in (
                    (from Result in db.Result
                     group new { Result.Exam.Session, Result.Exam.Subject, Result } by new
                     {
                         Result.Exam.Session.year,
                         Result.Exam.Subject.id
                     } into g
                     where g.Key.id == 5
                     orderby
                   g.Key.year
                     select new
                     {
                         year = g.Key.year,
                         average = (double?)g.Average(p => p.Result.mark)
                     })) on new { year = Session.year } equals new { year = Convert.ToDateTime(Averege_5.year) }
                join Averege_6 in (
                    (from Result in db.Result
                     group new { Result.Exam.Session, Result.Exam.Subject, Result } by new
                     {
                         Result.Exam.Session.year,
                         Result.Exam.Subject.id
                     } into g
                     where g.Key.id == 6
                     orderby
                   g.Key.year
                     select new
                     {
                         year = g.Key.year,
                         average = (double?)g.Average(p => p.Result.mark)
                     })) on new { year = Session.year } equals new { year = Convert.ToDateTime(Averege_6.year) }
                select new
                {
                    Session.year,
                    Maths = Averege_1.average,
                    VisualProgramming = Averege_2.average,
                    OOP = Averege_3.average,
                    DBEngeneering = Averege_4.average,
                    Modeling = Averege_5.average,
                    Cryptology = Averege_6.average
                };
            foreach (var r in query)
                Add(new DynamicsReport(
                    r.year, r.Maths, r.VisualProgramming, r.OOP, r.DBEngeneering,
                    r.Modeling, r.Cryptology));
        }
    }
}
