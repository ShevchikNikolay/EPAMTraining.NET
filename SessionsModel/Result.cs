using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Result : IEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int Mark { get; set; }
        public int ExamId { get; set; }
    }
}
