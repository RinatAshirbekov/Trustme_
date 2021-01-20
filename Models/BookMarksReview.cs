using System;
using System.Collections.Generic;

#nullable disable

namespace Trustme_.Models
{
    public partial class BookMarksReview
    {
        public Guid Id { get; set; }
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
    }
}
