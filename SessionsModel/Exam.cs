using System;

namespace DataModel
{
    /// <summary>
    /// Class represents an entity of exam.
    /// </summary>
    public class Exam : IEntity
    {
        /// <summary>
        /// Identity code of the exam.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date of the exam.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Identity code of the subject of the exam.
        /// </summary>
        public int SubjectId { get; set; }

        /// <summary>
        /// Identity code of the session of the exam.
        /// </summary>
        public int SessionId { get; set; }
    }
}
