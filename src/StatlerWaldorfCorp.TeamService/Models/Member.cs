using System;

namespace StatlerWaldorfCorp.TeamService.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Member()
        {
        }

        public Member(Guid id): this()
        {
            Id = id;
        }

        public Member(Guid id, string firstName, string lastName):this(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return this.LastName;
        }
    }
}