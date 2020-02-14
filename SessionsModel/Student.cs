using System;

namespace DataModel
{
    /// <summary>
    /// Class represents the entity of the student.
    /// </summary>
    public class Student : IEntity
    {
        /// <summary>
        /// Identity code of the student.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the student.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the student.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Patronymic of the student.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Gender of the student.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Birth date of the student.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Identity code of the student.
        /// </summary>
        public int GroupId { get; set; }
    }
}
