using System;
using System.Collections.Generic;

namespace BackEndApp.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public string Name { get; set; } = null!;
        public int Number { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
