using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class Oked
    {
        public Oked()
        {
            Companies = new HashSet<Company>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
