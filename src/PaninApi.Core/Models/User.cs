using System.Collections.Generic;

namespace PaninApi.Core.Models
{
    public class User : BaseUser
    {
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}