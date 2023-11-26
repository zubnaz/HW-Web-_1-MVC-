using System;
using System.Collections.Generic;

public class User : IdentityUser
{
    public DateTime Birthday { get; set; }
    public ICollection<Order> Orders { get; set; }
}
