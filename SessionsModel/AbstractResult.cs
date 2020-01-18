using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public abstract class AbstractResult
    {
        public int StudentId { get; set; }
        public int SessionId { get; set; }
        public int SubjectId { get; set; }
    }
}
