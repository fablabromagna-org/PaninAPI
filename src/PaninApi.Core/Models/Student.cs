using System.Collections.Generic;

namespace PaninApi.Core.Models
{
    public class Student : BaseUser
    {
        public virtual IEnumerable<Order> Orders { get; set; }
        
        public 
    }
}