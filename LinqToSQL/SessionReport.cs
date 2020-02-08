using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    class SessionReport
    {
        MapingDataContext dbContext;
        
        void getSummary(int sessionId)
        {
            dbContext = new MapingDataContext();
            var summary = from s in dbContext.Session
                          join e in dbContext.Exam on s.id equals e.sessionId
                          join r in dbContext.Result on e.id equals r.examId
                          join st in dbContext.Student on r.studentId equals st.id
                          join g in dbContext.Group on st.groupId equals g.id
                          where s.id == sessionId select new { name = g.name};
                          
                          
                       
        }
    }
}
