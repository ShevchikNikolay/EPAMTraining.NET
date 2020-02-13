using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Exam : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SubjectId { get; set; }
        public int SessionId { get; set; }
    }
}
