using System;

namespace DataModel
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int GroupId { get; set; }


    }
}
