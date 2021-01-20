using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class CommentLike
    {
        public Guid Id { get; set; }
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual User User { get; set; }
    }
}
