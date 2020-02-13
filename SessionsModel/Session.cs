using System;

namespace DataModel
{
    public class Session : IEntity
    {
        public int Id { get; set; }
        public DateTime Year { get; set; }
        public int Number { get; set; }
    }
}
