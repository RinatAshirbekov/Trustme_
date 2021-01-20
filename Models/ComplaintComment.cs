using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class ComplaintComment
    {
        public Guid Id { get; set; }
        public int ComplaintId { get; set; }
        public string Text { get; set; }
        public Guid CommentId { get; set; }

        public virtual Complaint Complaint { get; set; }
    }
}
