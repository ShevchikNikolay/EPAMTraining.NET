namespace DataModel
{
    /// <summary>
    /// Class represent a result of session.
    /// </summary>
    public class Result : IEntity
    {
        /// <summary>
        /// Identity code of the result.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identity code of the student.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// Mark for the exam.
        /// </summary>
        public int Mark { get; set; }

        /// <summary>
        /// Identity code of the exam.
        /// </summary>
        public int ExamId { get; set; }
    }
}
