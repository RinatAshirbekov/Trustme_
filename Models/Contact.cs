using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class Contact
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public Guid OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }
    }
}
