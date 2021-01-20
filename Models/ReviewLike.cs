using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class ReviewLike
    {
        public Guid Id { get; set; }
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }

        public virtual Review Review { get; set; }
        public virtual User User { get; set; }
    }
}
