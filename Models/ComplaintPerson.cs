using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class ComplaintPerson
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public int ComplaintId { get; set; }
        public string Text { get; set; }

        public virtual Complaint Complaint { get; set; }
    }
}
