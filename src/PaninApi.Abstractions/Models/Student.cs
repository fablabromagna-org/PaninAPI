using System.Collections.Generic;

namespace PaninApi.Abstractions.Models
{
    public class Student : BaseUser
    {
        public virtual IEnumerable<Order> Orders { get; set; }
        
        public StudentClass StudentClass { get; set; }
        
        public School School { get; set; }

        public int SchoolId { get; set; }
    }
}