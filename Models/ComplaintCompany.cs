using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class ComplaintCompany
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int ComplaintId { get; set; }
        public string Text { get; set; }

        public virtual Complaint Complaint { get; set; }
    }
}
