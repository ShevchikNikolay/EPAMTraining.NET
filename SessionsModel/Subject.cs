namespace DataModel
{
    /// <summary>
    /// Class represents the entity of the subject.
    /// </summary>
    public class Subject : IEntity
    {
        /// <summary>
        /// Identity code of the subject.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the subject.
        /// </summary>
        public string Name { get; set; }
    }
}
