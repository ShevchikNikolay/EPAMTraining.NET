namespace DataModel
{
    /// <summary>
    /// Class represents an entity of th group.
    /// </summary>
    public class Group : IEntity
    {
        /// <summary>
        /// Identity code of the group.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the group.
        /// </summary>
        public string Name { get; set; }
    }
}
