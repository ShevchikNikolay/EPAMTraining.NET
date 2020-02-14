using System;

namespace DataModel
{
    /// <summary>
    /// Class represents the entity of the session.
    /// </summary>
    public class Session : IEntity
    {
        /// <summary>
        /// Identity code of the session.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Year of the session.
        /// </summary>
        public DateTime Year { get; set; }

        /// <summary>
        /// Number of the session in the year.
        /// </summary>
        public int Number { get; set; }
    }
}
